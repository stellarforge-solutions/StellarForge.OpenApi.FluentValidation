using FluentValidation;

namespace StellarForge.OpenApi.FluentValidation.Tests.Support.ValidatorsForTest;

internal class NotNullArrayValidator : AbstractValidator<TestRequest>
{    
    public NotNullArrayValidator()
    {
        RuleFor(x => x.ArrayProperty).NotNull();
    }
}