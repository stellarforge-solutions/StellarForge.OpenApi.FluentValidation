using FluentValidation;

namespace StellarForge.OpenApi.FluentValidation.Tests.Support.ValidatorsForTest;

internal class RegExValidator : AbstractValidator<TestRequest>
{    
    public RegExValidator(string pattern)
    {
        RuleFor(x => x.StringProperty).Matches(pattern);
    }
}