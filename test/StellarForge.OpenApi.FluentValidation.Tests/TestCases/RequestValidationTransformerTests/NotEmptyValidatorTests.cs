using Microsoft.OpenApi;
using StellarForge.OpenApi.FluentValidation.Tests.Support.ValidatorsForTest;
using StellarForge.OpenApi.FluentValidation.Tests.Support;

namespace StellarForge.OpenApi.FluentValidation.Tests.TestCases.RequestValidationTransformerTests;

public class NotEmptyValidatorTests : TransformerTestBase
{
    [Fact]
    public async Task TransformAsync_NotEmpty_Array()
    {
        // ARRANGE
        const int minItems = 1;
        var validator = new NotEmptyArrayValidator();
        var expectedSchema = new OpenApiSchema
        {
            Type = JsonSchemaType.Array,
            MinItems = minItems,
        };

        var operation = new OpenApiOperation
        {
            Parameters =
            [
                new OpenApiParameter() 
                {
                    Name = nameof(TestRequest.ArrayProperty),
                    Schema = new OpenApiSchema { Type = JsonSchemaType.Array }
                }
            ]
        };

        var transformer = new RequestValidationTransformer<NotEmptyArrayValidator, TestRequest>();

        // ACT
        await transformer.TransformAsync(operation, BuildContext(validator), CancellationToken.None);

        // ASSERT
        var parameter = operation.Parameters?.FirstOrDefault(p => p.Name == nameof(TestRequest.ArrayProperty));
        Assert.NotNull(parameter);
        Assert.Equal(expectedSchema.MinItems, parameter.Schema?.MinItems);
    }

    [Fact]
    public async Task TransformAsync_NotEmpty_Number()
    {
        // ARRANGE
        const int minimum = 1;
        var validator = new NotEmptyNumberValidator();
        var expectedSchema = new OpenApiSchema
        {
            Type = JsonSchemaType.Number,
            Minimum = minimum.ToString(),
        };

        var operation = new OpenApiOperation
        {
            Parameters =
            [
                new OpenApiParameter() 
                {
                    Name = nameof(TestRequest.IntProperty),
                    Schema = new OpenApiSchema { Type = JsonSchemaType.Number }
                }
            ]
        };

        var transformer = new RequestValidationTransformer<NotEmptyNumberValidator, TestRequest>();

        // ACT
        await transformer.TransformAsync(operation, BuildContext(validator), CancellationToken.None);

        // ASSERT
        var parameter = operation.Parameters?.FirstOrDefault(p => p.Name == nameof(TestRequest.IntProperty));
        Assert.NotNull(parameter);
        Assert.Equal(expectedSchema.Minimum, parameter.Schema?.Minimum);
    }

    [Fact]
    public async Task TransformAsync_NotEmpty_String()
    {
        // ARRANGE
        const int minLength = 1;
        var validator = new NotEmptyStringValidator();
        var expectedSchema = new OpenApiSchema
        {
            Type = JsonSchemaType.String,
            MinLength = minLength,
        };

        var operation = new OpenApiOperation
        {
            Parameters =
            [
                new OpenApiParameter() 
                {
                    Name = nameof(TestRequest.StringProperty),
                    Schema = new OpenApiSchema { Type = JsonSchemaType.String }
                }
            ]
        };

        var transformer = new RequestValidationTransformer<NotEmptyStringValidator, TestRequest>();

        // ACT
        await transformer.TransformAsync(operation, BuildContext(validator), CancellationToken.None);

        // ASSERT
        var parameter = operation.Parameters?.FirstOrDefault(p => p.Name == nameof(TestRequest.StringProperty));
        Assert.NotNull(parameter);
        Assert.Equal(expectedSchema.MinLength, parameter.Schema?.MinLength);
    }
}