using Microsoft.OpenApi;
using StellarForge.OpenApi.FluentValidation.Tests.Support.ValidatorsForTest;
using StellarForge.OpenApi.FluentValidation.Tests.Support;
using static StellarForge.OpenApi.FluentValidation.Constants;

namespace StellarForge.OpenApi.FluentValidation.Tests.TestCases.RequestValidationTransformerTests;

public class IPv4ValidatorTests : TransformerTestBase
{
    [Fact]
    public async Task TransformAsync_Format()
    {
        // ARRANGE
        var validator = new IPv4Validator();
        var expectedSchema = new OpenApiSchema
        {
            Type = JsonSchemaType.String,
            Format = StringFormats.IPv4,
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

        var transformer = new RequestValidationTransformer<IPv4Validator, TestRequest>();

        // ACT
        await transformer.TransformAsync(operation, BuildContext(validator), CancellationToken.None);

        // ASSERT
        var parameter = operation.Parameters?.FirstOrDefault(p => p.Name == nameof(TestRequest.StringProperty));
        Assert.NotNull(parameter);
        Assert.Equal(expectedSchema.Format, parameter.Schema?.Format);
    }
}
