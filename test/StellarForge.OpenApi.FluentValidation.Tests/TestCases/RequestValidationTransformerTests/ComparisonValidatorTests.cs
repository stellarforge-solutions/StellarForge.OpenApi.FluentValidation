using Microsoft.OpenApi;
using StellarForge.OpenApi.FluentValidation.Tests.Support;
using StellarForge.OpenApi.FluentValidation.Tests.Support.ValidatorsForTest;

namespace StellarForge.OpenApi.FluentValidation.Tests.TestCases.RequestValidationTransformerTests;

public class ComparisonValidatorTests : TransformerTestBase
{
    private const string parameterName = nameof(TestRequest.IntProperty);
    private static readonly JsonSchemaType parameterType = JsonSchemaType.Integer;

    private static readonly OpenApiOperation operation = new()
    {
        Parameters =
        [
            new OpenApiParameter() 
            {
                Name = parameterName,
                Schema = new OpenApiSchema { Type = parameterType }
            }
        ]
    };

    [Fact]
    public async Task TransformAsync_LessThan()
    {
        // ARRANGE
        const int comparand = 10;
        var validator = new LessThanValidator(comparand);
        var expectedSchema = new OpenApiSchema
        {
            Type = parameterType,
            ExclusiveMaximum = comparand.ToString()
        };

        var transformer = new RequestValidationTransformer<LessThanValidator, TestRequest>();

        // ACT
        await transformer.TransformAsync(operation, BuildContext(validator), CancellationToken.None);

        // ASSERT
        var parameter = operation.Parameters?.FirstOrDefault(p => p.Name == parameterName);
        Assert.NotNull(parameter);
        Assert.Equal(comparand.ToString(), parameter.Schema?.ExclusiveMaximum);
    }

    [Fact]
    public async Task TransformAsync_LessThanOrEqualTo()
    {
        // ARRANGE
        const int comparand = 10;
        var validator = new LessThanOrEqualToValidator(comparand);
        var expectedSchema = new OpenApiSchema
        {
            Type = parameterType,
            Maximum = comparand.ToString()
        };

        var transformer = new RequestValidationTransformer<LessThanOrEqualToValidator, TestRequest>();

        // ACT
        await transformer.TransformAsync(operation, BuildContext(validator), CancellationToken.None);

        // ASSERT
        var parameter = operation.Parameters?.FirstOrDefault(p => p.Name == parameterName);
        Assert.NotNull(parameter);
        Assert.Equal(comparand.ToString(), parameter.Schema?.Maximum);
    }

    [Fact]
    public async Task TransformAsync_GreaterThan()
    {
        // ARRANGE
        const int comparand = 10;
        var validator = new GreaterThanValidator(comparand);
        var expectedSchema = new OpenApiSchema
        {
            Type = parameterType,
            ExclusiveMinimum = comparand.ToString()
        };

        var transformer = new RequestValidationTransformer<GreaterThanValidator, TestRequest>();

        // ACT
        await transformer.TransformAsync(operation, BuildContext(validator), CancellationToken.None);

        // ASSERT
        var parameter = operation.Parameters?.FirstOrDefault(p => p.Name == parameterName);
        Assert.NotNull(parameter);
        Assert.Equal(comparand.ToString(), parameter.Schema?.ExclusiveMinimum);
    }

    [Fact]
    public async Task TransformAsync_GreaterThanOrEqualTo()
    {
        // ARRANGE
        const int comparand = 10;
        var validator = new GreaterThanOrEqualToValidator(comparand);
        var expectedSchema = new OpenApiSchema
        {
            Type = parameterType,
            Minimum = comparand.ToString()
        };

        var transformer = new RequestValidationTransformer<GreaterThanOrEqualToValidator, TestRequest>();

        // ACT
        await transformer.TransformAsync(operation, BuildContext(validator), CancellationToken.None);

        // ASSERT
        var parameter = operation.Parameters?.FirstOrDefault(p => p.Name == parameterName);
        Assert.NotNull(parameter);
        Assert.Equal(comparand.ToString(), parameter.Schema?.Minimum);
    }
}
