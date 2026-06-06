using FluentValidation;

namespace StellarForge.OpenApi.FluentValidation.Tests.Support.ValidatorsForTest;

internal class NotEmptyStringValidator : AbstractValidator<TestRequest>
{    
    public NotEmptyStringValidator()
    {
        RuleFor(x => x.StringProperty).NotEmpty();
    }
}