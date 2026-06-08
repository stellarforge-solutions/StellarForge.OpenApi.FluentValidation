using FluentValidation;

namespace StellarForge.OpenApi.FluentValidation.Tests.Support.ValidatorsForTest;

internal class NoRulesValidator : AbstractValidator<TestRequest>
{
    public NoRulesValidator()
    {
        // No validation rules defined
    }
}