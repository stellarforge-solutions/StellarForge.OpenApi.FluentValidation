using FluentValidation;

namespace StellarForge.OpenApi.FluentValidation.Tests.Support.ValidatorsForTest;

internal class NotNullStringValidator : AbstractValidator<TestRequest>
{    
    public NotNullStringValidator()
    {
        RuleFor(x => x.StringProperty).NotNull();
    }
}