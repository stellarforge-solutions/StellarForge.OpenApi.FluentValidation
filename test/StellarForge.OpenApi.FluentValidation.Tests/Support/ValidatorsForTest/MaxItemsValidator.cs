using FluentValidation;
using StellarForge.OpenApi.FluentValidation.Extensions;

namespace StellarForge.OpenApi.FluentValidation.Tests.Support.ValidatorsForTest;

internal class MaxItemsValidator : AbstractValidator<TestRequest>
{
    public MaxItemsValidator(int maxItems)
    {
        RuleFor(x => x.ArrayProperty).MaxItems(maxItems);
    }
}