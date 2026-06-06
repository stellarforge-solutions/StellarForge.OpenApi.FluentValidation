using FluentValidation;

namespace StellarForge.OpenApi.FluentValidation.Tests.Support.ValidatorsForTest;

internal class InclusiveBetweenValidator : AbstractValidator<TestRequest>
{
    public InclusiveBetweenValidator(int minimum, int maximum)
    {
        RuleFor(x => x.IntProperty).InclusiveBetween(minimum, maximum);
    }
}