using FluentValidation;

namespace StellarForge.OpenApi.FluentValidation.Tests.Support.ValidatorsForTest;

internal class ExactLengthValidator : AbstractValidator<TestRequest>
{
    public ExactLengthValidator(int exactLength)
    {
        RuleFor(x => x.StringProperty).Length(exactLength);
    }
}