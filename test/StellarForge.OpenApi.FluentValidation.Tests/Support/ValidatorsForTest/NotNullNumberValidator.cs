using FluentValidation;

namespace StellarForge.OpenApi.FluentValidation.Tests.Support.ValidatorsForTest;

internal class NotNullNumberValidator : AbstractValidator<TestRequest>
{    
    public NotNullNumberValidator()
    {
        RuleFor(x => x.IntProperty).NotNull();
    }
}