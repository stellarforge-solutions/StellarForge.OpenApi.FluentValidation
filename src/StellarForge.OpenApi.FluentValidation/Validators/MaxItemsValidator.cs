using FluentValidation;
using FluentValidation.Validators;

namespace StellarForge.OpenApi.FluentValidation.Validators;

internal interface IMaxItemsValidator
{
    int MaxItems { get; }
}

internal class MaxItemsValidator<T, TItem>(int maxItems) : PropertyValidator<T, IEnumerable<TItem>>, IMaxItemsValidator
{
    public override string Name => nameof(MaxItemsValidator<,>);

    public int MaxItems => maxItems;

    public override bool IsValid(ValidationContext<T> context, IEnumerable<TItem> value)
    {
        if (value == null) return true;

        return value.Count() <= maxItems;
    }
}