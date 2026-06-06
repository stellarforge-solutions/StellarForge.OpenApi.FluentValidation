using FluentValidation;

namespace StellarForge.OpenApi.FluentValidation.Tests.Support.ValidatorsForTest;

internal class CreditCardValidator : AbstractValidator<TestRequest>
{
    public CreditCardValidator()
    {
        RuleFor(x => x.StringProperty).CreditCard();
    }
}