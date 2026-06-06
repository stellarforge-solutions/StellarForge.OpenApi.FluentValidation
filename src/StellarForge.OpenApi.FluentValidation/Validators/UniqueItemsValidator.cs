using FluentValidation;
using FluentValidation.Validators;

namespace StellarForge.OpenApi.FluentValidation.Validators;

internal interface IUniqueItemsValidator;

internal class UniqueItemsValidator<T, TItem> : PropertyValidator<T, IEnumerable<TItem>>, IUniqueItemsValidator
{
    public override string Name => nameof(UniqueItemsValidator<,>);

    public override bool IsValid(ValidationContext<T> context, IEnumerable<TItem> value)
    {
        if (value == null) return true;

        return value.Distinct().Count() == value.Count();
    }
}