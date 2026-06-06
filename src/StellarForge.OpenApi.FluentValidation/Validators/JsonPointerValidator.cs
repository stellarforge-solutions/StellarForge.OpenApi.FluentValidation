using FluentValidation;
using FluentValidation.Validators;
using Json.Pointer;

namespace StellarForge.OpenApi.FluentValidation.Validators;

internal interface IJsonPointerValidator;

internal class JsonPointerValidator<T>() : PropertyValidator<T, string>, IJsonPointerValidator
{
    public override string Name => nameof(JsonPointerValidator<>);

    public override bool IsValid(ValidationContext<T> context, string value)
    {
        if (value == null) return true;

        return JsonPointer.TryParse(value, out _);
    }
}