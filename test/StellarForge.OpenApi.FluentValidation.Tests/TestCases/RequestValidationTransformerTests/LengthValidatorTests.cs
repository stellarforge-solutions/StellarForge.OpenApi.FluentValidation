using Microsoft.OpenApi;
using StellarForge.OpenApi.FluentValidation.Tests.Support.ValidatorsForTest;
using StellarForge.OpenApi.FluentValidation.Tests.Support;

namespace StellarForge.OpenApi.FluentValidation.Tests.TestCases.RequestValidationTransformerTests;

public class LengthValidatorTests : TransformerTestBase
{
    private const string parameterName = nameof(TestRequest.StringProperty);

    private static readonly OpenApiOperation operation = new()
    {
        Parameters =
        [
            new OpenApiParameter() 
            {
                Name = parameterName,
                Schema = new OpenApiSchema { Type = JsonSchemaType.String }
            }
        ]
    };

    [Fact]
    public async Task TransformAsync_Length()
    {
        // ARRANGE
        const int minLength = 1;
        const int maxLength = 10;
        var validator = new LengthValidator(minLength, maxLength);
        var expectedSchema = new OpenApiSchema
        {
            Type = JsonSchemaType.String,
            MinLength = minLength,
            MaxLength = maxLength
        };

        var transformer = new RequestValidationTransformer<LengthValidator, TestRequest>();

        // ACT
        await transformer.TransformAsync(operation, BuildContext(validator), CancellationToken.None);

        // ASSERT
        var parameter = operation.Parameters?.FirstOrDefault(p => p.Name == parameterName);
        Assert.NotNull(parameter);
        Assert.Equal(expectedSchema.MinLength, parameter.Schema?.MinLength);
        Assert.Equal(expectedSchema.MaxLength, parameter.Schema?.MaxLength);
    }    

    [Fact]
    public async Task TransformAsync_MinLength()
    {
        // ARRANGE
        const int minLength = 10;
        var validator = new MinLengthValidator(minLength);
        var expectedSchema = new OpenApiSchema
        {
            Type = JsonSchemaType.String,
            MinLength = minLength
        };

        var transformer = new RequestValidationTransformer<MinLengthValidator, TestRequest>();

        // ACT
        await transformer.TransformAsync(operation, BuildContext(validator), CancellationToken.None);

        // ASSERT
        var parameter = operation.Parameters?.FirstOrDefault(p => p.Name == parameterName);
        Assert.NotNull(parameter);
        Assert.Equal(expectedSchema.MinLength, parameter.Schema?.MinLength);
    }

    [Fact]
    public async Task TransformAsync_MaxLength()
    {
        // ARRANGE
        const int maxLength = 10;
        var validator = new MaxLengthValidator(maxLength);
        var expectedSchema = new OpenApiSchema
        {
            Type = JsonSchemaType.String,
            MinLength = 0,
            MaxLength = maxLength
        };

        var transformer = new RequestValidationTransformer<MaxLengthValidator, TestRequest>();

        // ACT
        await transformer.TransformAsync(operation, BuildContext(validator), CancellationToken.None);

        // ASSERT
        var parameter = operation.Parameters?.FirstOrDefault(p => p.Name == parameterName);
        Assert.NotNull(parameter);
        Assert.Equal(expectedSchema.MinLength, parameter.Schema?.MinLength);
        Assert.Equal(expectedSchema.MaxLength, parameter.Schema?.MaxLength);
    }
}