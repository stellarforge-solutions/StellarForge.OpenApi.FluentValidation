using FluentValidation;

namespace StellarForge.OpenApi.FluentValidation.Tests.Support.ValidatorsForTest;

internal class EmailValidator : AbstractValidator<TestRequest>
{
    public EmailValidator()
    {
        RuleFor(x => x.StringProperty).EmailAddress();
    }
}