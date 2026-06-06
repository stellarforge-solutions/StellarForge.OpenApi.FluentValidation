using Microsoft.OpenApi;
using StellarForge.OpenApi.FluentValidation.Tests.Support.ValidatorsForTest;
using StellarForge.OpenApi.FluentValidation.Tests.Support;

namespace StellarForge.OpenApi.FluentValidation.Tests.TestCases.RequestValidationTransformerTests;

public class MinItemsValidatorTests : TransformerTestBase
{
    [Fact]
    public async Task TransformAsync()
    {
        // ARRANGE
        const int minItems = 5;
        var validator = new MinItemsValidator(minItems);
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

        var transformer = new RequestValidationTransformer<MinItemsValidator, TestRequest>();

        // ACT
        await transformer.TransformAsync(operation, BuildContext(validator), CancellationToken.None);

        // ASSERT
        var parameter = operation.Parameters?.FirstOrDefault(p => p.Name == nameof(TestRequest.ArrayProperty));
        Assert.NotNull(parameter);
        Assert.Equal(expectedSchema.MinItems, parameter.Schema?.MinItems);
    }
}
