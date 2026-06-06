using FluentValidation;
using StellarForge.OpenApi.FluentValidation.Tests.TestCases.RequestValidationTransformerTests;

namespace StellarForge.OpenApi.FluentValidation.Tests.Support.ValidatorsForTest;

internal class StringEnumValidator : AbstractValidator<TestRequest>
{
    public StringEnumValidator()
    {
        RuleFor(x => x.StringProperty).IsEnumName(typeof(TestEnum));
    }
}