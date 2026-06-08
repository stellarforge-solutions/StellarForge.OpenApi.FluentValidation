using Microsoft.AspNetCore.OpenApi;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi;
using StellarForge.OpenApi.FluentValidation.Tests.Support;
using StellarForge.OpenApi.FluentValidation.Tests.Support.ValidatorsForTest;

namespace StellarForge.OpenApi.FluentValidation.Tests.TestCases.RequestValidationTransformerTests;

public class CommonTests : TransformerTestBase
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
    public async Task ValidatorNotFound()
    {
        // ARRANGE
        var validator = new IPv4Validator();
        var expectedSchema = new OpenApiSchema
        {
            Type = parameterType
            // No additional constraints expected since the validator is not found
        };

        var transformer = new RequestValidationTransformer<IPv4Validator, TestRequest>();
        var context = new OpenApiOperationTransformerContext()
        {
            DocumentName = "test",
            Description = new(),
            ApplicationServices = new ServiceCollection().BuildServiceProvider() // No validators registered
        };

        // ACT
        await transformer.TransformAsync(operation, context, CancellationToken.None);

        // ASSERT
        var parameter = operation.Parameters?.FirstOrDefault(p => p.Name == parameterName);
        Assert.NotNull(parameter);
        Assert.Equivalent(expectedSchema, parameter.Schema);
    }

    [Fact]
    public async Task ValidatorWithNoRules()
    {
        // ARRANGE
        var validator = new NoRulesValidator();
        var expectedSchema = new OpenApiSchema
        {
            Type = parameterType
            // No additional constraints expected since there are no validation rules
        };

        var transformer = new RequestValidationTransformer<NoRulesValidator, TestRequest>();

        // ACT
        await transformer.TransformAsync(operation, BuildContext(validator), CancellationToken.None);

        // ASSERT
        var parameter = operation.Parameters?.FirstOrDefault(p => p.Name == parameterName);
        Assert.NotNull(parameter);
        Assert.Equivalent(expectedSchema, parameter.Schema);
    }
}