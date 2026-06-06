using FluentValidation;
using FluentValidation.Validators;

namespace StellarForge.OpenApi.FluentValidation.Validators;

internal interface IMinItemsValidator
{
    int MinItems { get; }
}

internal class MinItemsValidator<T, TItem>(int minItems) : PropertyValidator<T, IEnumerable<TItem>>, IMinItemsValidator
{
    public override string Name => nameof(MinItemsValidator<,>);

    public int MinItems => minItems;

    public override bool IsValid(ValidationContext<T> context, IEnumerable<TItem> value)
    {
        if (value == null) return true;

        return value.Count() >= minItems;
    }
}