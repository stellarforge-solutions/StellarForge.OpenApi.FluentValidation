using FluentValidation.Validators;
using StellarForge.OpenApi.FluentValidation.Validators;

namespace StellarForge.OpenApi.FluentValidation.Extensions;

internal static class PropertyValidatorExtensions
{
    /// <summary>
    /// Determines if the provided <see cref="IPropertyValidator"/> is a <see cref="IPv4Validator{T}"/>.
    /// </summary>
    /// <param name="propertyValidator"></param>
    /// <returns></returns>
    public static bool IsIPv4Validator(this IPropertyValidator propertyValidator)
    {
        return propertyValidator.Name == nameof(IPv4Validator<>);
    }

    /// <summary>
    /// Determines if the provided <see cref="IPropertyValidator"/> is a <see cref="IPv6Validator{T}"/>.
    /// </summary>
    /// <param name="propertyValidator"></param>
    /// <returns></returns>
    public static bool IsIPv6Validator(this IPropertyValidator propertyValidator)
    {
        return propertyValidator.Name == nameof(IPv6Validator<>);
    }

    /// <summary>
    /// Determines if the provided <see cref="IPropertyValidator"/> is a <see cref="JsonPointerValidator{T}"/>.
    /// </summary>
    /// <param name="propertyValidator"></param>
    /// <returns></returns>
    public static bool IsJsonPointerValidator(this IPropertyValidator propertyValidator)
    {
        return propertyValidator.Name == nameof(JsonPointerValidator<>);
    }

    /// <summary>
    /// Determines if the provided <see cref="IPropertyValidator"/> is a <see cref="IMinItemsValidator{T, TItem}"/>.
    /// </summary>
    /// <param name="propertyValidator"></param>
    /// <returns></returns>
    public static bool IsMinItemsValidator(this IPropertyValidator propertyValidator, out int minItemsOut)
    {
        minItemsOut = default;

        if (propertyValidator.Name != nameof(MinItemsValidator<,>)) return false;

        minItemsOut = propertyValidator.GetType().GetProperty(nameof(MinItemsValidator<,>.MinItems))?.GetValue(propertyValidator) is int minItems
            ? minItems
            : default;

        return true;
    }

    /// <summary>
    /// Determines if the provided <see cref="IPropertyValidator"/> is a <see cref="IMaxItemsValidator{T, TItem}"/>.
    /// </summary>
    /// <param name="propertyValidator"></param>
    /// <returns></returns>
    public static bool IsMaxItemsValidator(this IPropertyValidator propertyValidator, out int maxItemsOut)
    {
        maxItemsOut = default;

        if (propertyValidator.Name != nameof(MaxItemsValidator<,>)) return false;

        maxItemsOut = propertyValidator.GetType().GetProperty(nameof(MaxItemsValidator<,>.MaxItems))?.GetValue(propertyValidator) is int maxItems
            ? maxItems
            : default;

        return true;
    }

    /// <summary>
    /// Determines if the provided <see cref="IPropertyValidator"/> is a <see cref="IUniqueItemsValidator{T, TItem}"/>.
    /// </summary>
    /// <param name="propertyValidator"></param>
    /// <returns></returns>
    public static bool IsUniqueItemsValidator(this IPropertyValidator propertyValidator)
    {
        return propertyValidator.Name == nameof(UniqueItemsValidator<,>);
    }
}