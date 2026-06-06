using FluentValidation;

namespace StellarForge.OpenApi.FluentValidation.Tests.Support.ValidatorsForTest;

internal class PrecisionScaleValidator : AbstractValidator<TestRequest>
{
    public PrecisionScaleValidator(int precision, int scale)
    {
        RuleFor(x => x.DecimalProperty).PrecisionScale(precision, scale, ignoreTrailingZeros: true);
    }
}