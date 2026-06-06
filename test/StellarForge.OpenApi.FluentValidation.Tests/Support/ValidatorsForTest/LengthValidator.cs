using FluentValidation;

namespace StellarForge.OpenApi.FluentValidation.Tests.Support.ValidatorsForTest;

internal class LengthValidator : AbstractValidator<TestRequest>
{
    public LengthValidator(int minimum, int maximum)
    {
        RuleFor(x => x.StringProperty).Length(minimum, maximum);
    }
}