using FluentValidation;

namespace StellarForge.OpenApi.FluentValidation.Tests.Support.ValidatorsForTest;

internal class MinLengthValidator : AbstractValidator<TestRequest>
{
    public MinLengthValidator(int minimum)
    {
        RuleFor(x => x.StringProperty).MinimumLength(minimum);
    }
}