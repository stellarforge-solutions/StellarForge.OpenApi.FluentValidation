using FluentValidation;
using StellarForge.OpenApi.FluentValidation.Validators;

namespace StellarForge.OpenApi.FluentValidation.Extensions;

public static class RuleBuilderExtensions
{
    public static IRuleBuilderOptions<T, string> IPv4<T>(this IRuleBuilder<T, string> ruleBuilder)
    {
        return ruleBuilder.SetValidator(new IPv4Validator<T>());
    }

    public static IRuleBuilderOptions<T, string> IPv6<T>(this IRuleBuilder<T, string> ruleBuilder)
    {
        return ruleBuilder.SetValidator(new IPv6Validator<T>());
    }

    public static IRuleBuilderOptions<T, string> JsonPointer<T>(this IRuleBuilder<T, string> ruleBuilder)
    {
        return ruleBuilder.SetValidator(new JsonPointerValidator<T>());
    }

    public static IRuleBuilderOptions<T, IEnumerable<TItem>> MinItems<T, TItem>(this IRuleBuilder<T, IEnumerable<TItem>> ruleBuilder, int minItems)
    {
        return ruleBuilder.SetValidator(new MinItemsValidator<T, TItem>(minItems));
    }

    public static IRuleBuilderOptions<T, IEnumerable<TItem>> MaxItems<T, TItem>(this IRuleBuilder<T, IEnumerable<TItem>> ruleBuilder, int maxItems)
    {
        return ruleBuilder.SetValidator(new MaxItemsValidator<T, TItem>(maxItems));
    }
    
    public static IRuleBuilderOptions<T, IEnumerable<TItem>> UniqueItems<T, TItem>(this IRuleBuilder<T, IEnumerable<TItem>> ruleBuilder)
    {
        return ruleBuilder.SetValidator(new UniqueItemsValidator<T, TItem>());
    }
}
