using FluentValidation;

namespace StellarForge.OpenApi.FluentValidation.Tests.Support.ValidatorsForTest;

internal class ExclusiveBetweenValidator : AbstractValidator<TestRequest>
{
    public ExclusiveBetweenValidator(int minimum, int maximum)
    {
        RuleFor(x => x.IntProperty).ExclusiveBetween(minimum, maximum);
    }
}