using FluentValidation;
using StellarForge.OpenApi.FluentValidation.Extensions;

namespace StellarForge.OpenApi.FluentValidation.Tests.Support.ValidatorsForTest;

internal class UniqueItemsValidator : AbstractValidator<TestRequest>
{
    public UniqueItemsValidator()
    {
        RuleFor(x => x.ArrayProperty).UniqueItems();
    }
}