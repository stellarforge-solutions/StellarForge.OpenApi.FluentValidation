using FluentValidation;

namespace StellarForge.OpenApi.FluentValidation.Tests.Support.ValidatorsForTest;

internal class LessThanOrEqualToValidator : AbstractValidator<TestRequest>
{    
    public LessThanOrEqualToValidator(int comparand)
    {
        RuleFor(x => x.IntProperty).LessThanOrEqualTo(comparand);
    }
}