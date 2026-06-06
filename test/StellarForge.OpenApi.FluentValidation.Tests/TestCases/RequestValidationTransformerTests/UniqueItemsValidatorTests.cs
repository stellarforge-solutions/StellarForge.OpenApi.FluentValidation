using Microsoft.OpenApi;
using StellarForge.OpenApi.FluentValidation.Tests.Support.ValidatorsForTest;
using StellarForge.OpenApi.FluentValidation.Tests.Support;

namespace StellarForge.OpenApi.FluentValidation.Tests.TestCases.RequestValidationTransformerTests;

public class UniqueItemsValidatorTests : TransformerTestBase
{
    [Fact]
    public async Task TransformAsync()
    {
        // ARRANGE
        var validator = new UniqueItemsValidator();
        var expectedSchema = new OpenApiSchema
        {
            Type = JsonSchemaType.Array,
            UniqueItems = true,
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

        var transformer = new RequestValidationTransformer<UniqueItemsValidator, TestRequest>();

        // ACT
        await transformer.TransformAsync(operation, BuildContext(validator), CancellationToken.None);

        // ASSERT
        var parameter = operation.Parameters?.FirstOrDefault(p => p.Name == nameof(TestRequest.ArrayProperty));
        Assert.NotNull(parameter);
        Assert.Equal(expectedSchema.UniqueItems, parameter.Schema?.UniqueItems);
    }
}
