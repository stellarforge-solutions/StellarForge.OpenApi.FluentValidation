using FluentValidation;

namespace StellarForge.OpenApi.FluentValidation.Tests.Support.ValidatorsForTest;

internal class GreaterThanOrEqualToValidator : AbstractValidator<TestRequest>
{    
    public GreaterThanOrEqualToValidator(int comparand)
    {
        RuleFor(x => x.IntProperty).GreaterThanOrEqualTo(comparand);
    }
}