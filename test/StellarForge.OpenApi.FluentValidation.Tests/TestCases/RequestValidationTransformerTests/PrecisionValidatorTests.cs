using Microsoft.OpenApi;
using StellarForge.OpenApi.FluentValidation.Tests.Support;
using StellarForge.OpenApi.FluentValidation.Tests.Support.ValidatorsForTest;

namespace StellarForge.OpenApi.FluentValidation.Tests.TestCases.RequestValidationTransformerTests;

public class PrecisionValidatorTests : TransformerTestBase
{
    private const string parameterName = nameof(TestRequest.DecimalProperty);

    private static readonly OpenApiOperation operation = new()
    {
        Parameters =
        [
            new OpenApiParameter() 
            {
                Name = parameterName,
                Schema = new OpenApiSchema { Type = JsonSchemaType.Number }
            }
        ]
    };

    [Fact]
    public async Task TransformAsync_Precision()
    {
        // ARRANGE
        var validator = new PrecisionScaleValidator(2, 2);
        var expectedSchema = new OpenApiSchema
        {
            Type = JsonSchemaType.Number,
            MultipleOf = 0.01m
        };

        var transformer = new RequestValidationTransformer<PrecisionScaleValidator, TestRequest>();

        // ACT
        await transformer.TransformAsync(operation, BuildContext(validator), CancellationToken.None);

        // ASSERT
        var parameter = operation.Parameters?.FirstOrDefault(p => p.Name == parameterName);
        Assert.NotNull(parameter);
        Assert.Equal(expectedSchema.MultipleOf, parameter.Schema?.MultipleOf);
    }
}
