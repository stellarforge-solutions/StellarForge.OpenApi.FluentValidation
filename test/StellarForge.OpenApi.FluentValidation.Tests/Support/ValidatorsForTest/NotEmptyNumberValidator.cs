using FluentValidation;

namespace StellarForge.OpenApi.FluentValidation.Tests.Support.ValidatorsForTest;

internal class NotEmptyNumberValidator : AbstractValidator<TestRequest>
{    
    public NotEmptyNumberValidator()
    {
        RuleFor(x => x.IntProperty).NotEmpty();
    }
}