using Microsoft.OpenApi;
using StellarForge.OpenApi.FluentValidation.Tests.Support;
using StellarForge.OpenApi.FluentValidation.Tests.Support.ValidatorsForTest;

namespace StellarForge.OpenApi.FluentValidation.Tests.TestCases.RequestValidationTransformerTests;

public class BetweenValidatorTests : TransformerTestBase
{
    private const string parameterName = nameof(TestRequest.IntProperty);

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
    public async Task TransformAsync_ExclusiveBetween()
    {
        // ARRANGE
        const int minimum = 1;
        const int maximum = 10;
        var validator = new ExclusiveBetweenValidator(minimum, maximum);
        var expectedSchema = new OpenApiSchema
        {
            Type = JsonSchemaType.String,
            ExclusiveMinimum = minimum.ToString(),
            ExclusiveMaximum = maximum.ToString()
        };

        var transformer = new RequestValidationTransformer<ExclusiveBetweenValidator, TestRequest>();

        // ACT
        await transformer.TransformAsync(operation, BuildContext(validator), CancellationToken.None);

        // ASSERT
        var parameter = operation.Parameters?.FirstOrDefault(p => p.Name == parameterName);
        Assert.NotNull(parameter);
        Assert.Equal(minimum.ToString(), parameter.Schema?.ExclusiveMinimum);
        Assert.Equal(maximum.ToString(), parameter.Schema?.ExclusiveMaximum);
    }

    [Fact]
    public async Task TransformAsync_Between()
    {
        // ARRANGE
        const int minimum = 1;
        const int maximum = 10;
        var validator = new InclusiveBetweenValidator(minimum, maximum);
        var expectedSchema = new OpenApiSchema
        {
            Type = JsonSchemaType.Number,
            Minimum = minimum.ToString(),
            Maximum = maximum.ToString()
        };

        var transformer = new RequestValidationTransformer<InclusiveBetweenValidator, TestRequest>();

        // ACT
        await transformer.TransformAsync(operation, BuildContext(validator), CancellationToken.None);

        // ASSERT
        var parameter = operation.Parameters?.FirstOrDefault(p => p.Name == parameterName);
        Assert.NotNull(parameter);
        Assert.Equal(minimum.ToString(), parameter.Schema?.Minimum);
        Assert.Equal(maximum.ToString(), parameter.Schema?.Maximum);
    }
}
