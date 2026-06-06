using Microsoft.OpenApi;
using StellarForge.OpenApi.FluentValidation.Tests.Support.ValidatorsForTest;
using StellarForge.OpenApi.FluentValidation.Tests.Support;

namespace StellarForge.OpenApi.FluentValidation.Tests.TestCases.RequestValidationTransformerTests;

public class RegExValidatorTests : TransformerTestBase
{
    [Fact]
    public async Task TransformAsync_Pattern()
    {
        // ARRANGE
        const string pattern = "^[a-zA-Z0-9_]+$";
        var validator = new RegExValidator(pattern);
        var expectedSchema = new OpenApiSchema
        {
            Type = JsonSchemaType.String,
            Pattern = pattern,
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

        var transformer = new RequestValidationTransformer<RegExValidator, TestRequest>();

        // ACT
        await transformer.TransformAsync(operation, BuildContext(validator), CancellationToken.None);

        // ASSERT
        var parameter = operation.Parameters?.FirstOrDefault(p => p.Name == nameof(TestRequest.StringProperty));
        Assert.NotNull(parameter);
        Assert.Equal(expectedSchema.Pattern, parameter.Schema?.Pattern);
    }
}