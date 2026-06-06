using FluentValidation;

namespace StellarForge.OpenApi.FluentValidation.Tests.Support.ValidatorsForTest;

internal class GreaterThanValidator : AbstractValidator<TestRequest>
{    
    public GreaterThanValidator(int comparand)
    {
        RuleFor(x => x.IntProperty).GreaterThan(comparand);
    }
}