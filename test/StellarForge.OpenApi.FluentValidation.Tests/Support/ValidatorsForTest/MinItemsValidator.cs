using FluentValidation;
using StellarForge.OpenApi.FluentValidation.Extensions;

namespace StellarForge.OpenApi.FluentValidation.Tests.Support.ValidatorsForTest;

internal class MinItemsValidator : AbstractValidator<TestRequest>
{
    public MinItemsValidator(int minItems)
    {
        RuleFor(x => x.ArrayProperty).MinItems(minItems);
    }
}