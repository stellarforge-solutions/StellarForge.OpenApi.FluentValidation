using Microsoft.OpenApi;
using StellarForge.OpenApi.FluentValidation.Tests.Support.ValidatorsForTest;
using StellarForge.OpenApi.FluentValidation.Tests.Support;

namespace StellarForge.OpenApi.FluentValidation.Tests.TestCases.RequestValidationTransformerTests;

public class EnumValidatorTests : TransformerTestBase
{
    [Fact]
    public async Task TransformAsync_Enum()
    {
        // ARRANGE
        const string parameterName = nameof(TestRequest.EnumProperty);
        var validator = new EnumValidator();
        var expectedSchema = new OpenApiSchema
        {
            Type = JsonSchemaType.String,
            Enum = [
                TestEnum.Value1.ToString(),
                TestEnum.Value2.ToString(),
                TestEnum.Value3.ToString()
            ]
        };

        var operation = new OpenApiOperation
        {
            Parameters = 
            [
                new OpenApiParameter
                {
                    Name = parameterName,
                    Schema = new OpenApiSchema { Type = JsonSchemaType.Object }
                }
            ]
        };

        var transformer = new RequestValidationTransformer<EnumValidator, TestRequest>();

        // ACT
        await transformer.TransformAsync(operation, BuildContext(validator), CancellationToken.None);

        // ASSERT
        var parameter = operation.Parameters?.FirstOrDefault(p => p.Name == parameterName);
        Assert.NotNull(parameter);
        Assert.Collection(parameter.Schema?.Enum ?? [], 
            item => Assert.Equal(TestEnum.Value1.ToString(), item.GetValue<string>()),
            item => Assert.Equal(TestEnum.Value2.ToString(), item.GetValue<string>()),
            item => Assert.Equal(TestEnum.Value3.ToString(), item.GetValue<string>())
        );
    }

    [Fact]
    public async Task TransformAsync_StringEnum()
    {
        // ARRANGE
        const string parameterName = nameof(TestRequest.StringProperty);
        var validator = new StringEnumValidator();
        var expectedSchema = new OpenApiSchema
        {
            Type = JsonSchemaType.String,
            Enum = [
                TestEnum.Value1.ToString(),
                TestEnum.Value2.ToString(),
                TestEnum.Value3.ToString()
            ]
        };

        var operation = new OpenApiOperation
        {
            Parameters = 
            [
                new OpenApiParameter
                {
                    Name = parameterName,
                    Schema = new OpenApiSchema { Type = JsonSchemaType.String }
                }
            ]
        };

        var transformer = new RequestValidationTransformer<StringEnumValidator, TestRequest>();

        // ACT
        await transformer.TransformAsync(operation, BuildContext(validator), CancellationToken.None);

        // ASSERT
        var parameter = operation.Parameters?.FirstOrDefault(p => p.Name == parameterName);
        Assert.NotNull(parameter);
        Assert.Collection(parameter.Schema?.Enum ?? [], 
            item => Assert.Equal(TestEnum.Value1.ToString(), item.GetValue<string>()),
            item => Assert.Equal(TestEnum.Value2.ToString(), item.GetValue<string>()),
            item => Assert.Equal(TestEnum.Value3.ToString(), item.GetValue<string>())
        );
    }
}
