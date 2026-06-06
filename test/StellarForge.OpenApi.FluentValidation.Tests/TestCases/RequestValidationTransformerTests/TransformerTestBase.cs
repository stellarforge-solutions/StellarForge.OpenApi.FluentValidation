using Microsoft.AspNetCore.OpenApi;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation;
using StellarForge.OpenApi.FluentValidation.Tests.Support;

namespace StellarForge.OpenApi.FluentValidation.Tests.TestCases.RequestValidationTransformerTests;

public class TransformerTestBase
{
    internal static OpenApiOperationTransformerContext BuildContext<TValidator>(TValidator validator) where TValidator : AbstractValidator<TestRequest> => new()
    {
        DocumentName = "test",
        Description = new(),
        ApplicationServices = new ServiceCollection()
            .AddSingleton(validator)
            .BuildServiceProvider()
    };
}
