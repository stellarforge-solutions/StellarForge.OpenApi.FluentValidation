using Microsoft.OpenApi;
using StellarForge.OpenApi.FluentValidation.Tests.Support.ValidatorsForTest;
using StellarForge.OpenApi.FluentValidation.Tests.Support;

namespace StellarForge.OpenApi.FluentValidation.Tests.TestCases.RequestValidationTransformerTests;

public class NotNullValidatorTests : TransformerTestBase
{
    [Fact]
    public async Task TransformAsync_NotNull_Array()
    {
        // ARRANGE
        var validator = new NotNullArrayValidator();
        var expectedSchema = new OpenApiSchema
        {
            Type = JsonSchemaType.Array,
            Required = new HashSet<string> { nameof(TestRequest.ArrayProperty) }
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

        var transformer = new RequestValidationTransformer<NotNullArrayValidator, TestRequest>();

        // ACT
        await transformer.TransformAsync(operation, BuildContext(validator), CancellationToken.None);

        // ASSERT
        var parameter = operation.Parameters?.FirstOrDefault(p => p.Name == nameof(TestRequest.ArrayProperty));
        var actualRequired = parameter?.Schema?.Required ?? new HashSet<string>();
        Assert.NotNull(parameter);
        Assert.True(expectedSchema.Required.SetEquals(actualRequired));
    }

    [Fact]
    public async Task TransformAsync_NotNull_Number()
    {
        // ARRANGE
        var validator = new NotNullNumberValidator();
        var expectedSchema = new OpenApiSchema
        {
            Type = JsonSchemaType.Number,
            Required = new HashSet<string> { nameof(TestRequest.IntProperty) }
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

        var transformer = new RequestValidationTransformer<NotNullNumberValidator, TestRequest>();

        // ACT
        await transformer.TransformAsync(operation, BuildContext(validator), CancellationToken.None);

        // ASSERT
        var parameter = operation.Parameters?.FirstOrDefault(p => p.Name == nameof(TestRequest.IntProperty));
        var actualRequired = parameter?.Schema?.Required ?? new HashSet<string>();
        Assert.NotNull(parameter);
        Assert.True(expectedSchema.Required.SetEquals(actualRequired));
    }

    [Fact]
    public async Task TransformAsync_NotNull_String()
    {
        // ARRANGE
        var validator = new NotNullStringValidator();
        var expectedSchema = new OpenApiSchema
        {
            Type = JsonSchemaType.String,
            Required = new HashSet<string> { nameof(TestRequest.StringProperty) }
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

        var transformer = new RequestValidationTransformer<NotNullStringValidator, TestRequest>();

        // ACT
        await transformer.TransformAsync(operation, BuildContext(validator), CancellationToken.None);

        // ASSERT
        var parameter = operation.Parameters?.FirstOrDefault(p => p.Name == nameof(TestRequest.StringProperty));
        var actualRequired = parameter?.Schema?.Required ?? new HashSet<string>();
        Assert.NotNull(parameter);
        Assert.True(expectedSchema.Required.SetEquals(actualRequired));
    }
}