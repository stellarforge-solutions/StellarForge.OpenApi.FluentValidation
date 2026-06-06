using FluentValidation;

namespace StellarForge.OpenApi.FluentValidation.Tests.Support.ValidatorsForTest;

internal class MaxLengthValidator : AbstractValidator<TestRequest>
{
    public MaxLengthValidator(int maximum)
    {
        RuleFor(x => x.StringProperty).MaximumLength(maximum);
    }
}