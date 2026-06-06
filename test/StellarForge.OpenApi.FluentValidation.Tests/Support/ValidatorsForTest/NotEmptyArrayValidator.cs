using FluentValidation;

namespace StellarForge.OpenApi.FluentValidation.Tests.Support.ValidatorsForTest;

internal class NotEmptyArrayValidator : AbstractValidator<TestRequest>
{    
    public NotEmptyArrayValidator()
    {
        RuleFor(x => x.ArrayProperty).NotEmpty();
    }
}