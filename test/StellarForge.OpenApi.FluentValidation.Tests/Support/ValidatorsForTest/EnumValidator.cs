using FluentValidation;

namespace StellarForge.OpenApi.FluentValidation.Tests.Support.ValidatorsForTest;

internal class EnumValidator : AbstractValidator<TestRequest>
{
    public EnumValidator()
    {
        RuleFor(x => x.EnumProperty).IsInEnum();
    }
}