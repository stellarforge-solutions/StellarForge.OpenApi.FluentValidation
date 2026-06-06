using FluentValidation;

namespace StellarForge.OpenApi.FluentValidation.Tests.Support.ValidatorsForTest;

internal class LessThanValidator : AbstractValidator<TestRequest>
{    
    public LessThanValidator(int comparand)
    {
        RuleFor(x => x.IntProperty).LessThan(comparand);
    }
}