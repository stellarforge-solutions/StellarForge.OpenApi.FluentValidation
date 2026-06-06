using FluentValidation;
using FluentValidation.Validators;
using Microsoft.AspNetCore.OpenApi;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi;
using StellarForge.OpenApi.FluentValidation.Extensions;
using StellarForge.OpenApi.FluentValidation.Validators;
using System.Text.Json.Nodes;
using static StellarForge.OpenApi.FluentValidation.Constants;
using static System.Reflection.BindingFlags;

namespace StellarForge.OpenApi.FluentValidation;

public class RequestValidationTransformer<TValidator, TRequest> : IOpenApiOperationTransformer where TValidator : IValidator
{
    public Task TransformAsync(OpenApiOperation operation, OpenApiOperationTransformerContext context, CancellationToken cancellationToken)
    {
        if (context.ApplicationServices.GetRequiredService<TValidator>() is not AbstractValidator<TRequest> validator) return Task.CompletedTask;

        var parameterRules = (operation.Parameters ?? [])
            .Join(validator, parameter => parameter.Name, rule => rule.PropertyName, (parameter, rule) => (parameter.Schema as OpenApiSchema, rule))
            .Select(tuple => tuple);

        foreach (var (schema, rule) in parameterRules)
        {
            if (schema is null) continue;

            foreach(var component in rule.Components)
            {
                Action<OpenApiSchema> schemaUpdater = component.Validator switch
                {
                    IBetweenValidator betweenValidator => schema => UpdateSchemaMinMax(schema, betweenValidator),
                    IComparisonValidator comparisonValidator => schema => UpdateSchemaMinMax(schema, comparisonValidator),
                    ICreditCardValidator _ => schema => UpdateSchemaFormat(schema, StringFormats.CreditCard),
                    IEmailValidator _ => schema => UpdateSchemaFormat(schema, StringFormats.Email),
                    IEnumValidator enumValidator => schema => UpdateSchemaEnum(schema, enumValidator),
                    ILengthValidator lengthValidator => schema => UpdateSchemaMinMaxLength(schema, lengthValidator),
                    INotEmptyValidator _ => UpdateSchemaMinimum,
                    INotNullValidator _ => schema => UpdateSchemaRequired(schema, rule.PropertyName),
                    IIPv4Validator _ => schema => UpdateSchemaFormat(schema, StringFormats.IPv4),
                    IIPv6Validator _ => schema => UpdateSchemaFormat(schema, StringFormats.IPv6),
                    IJsonPointerValidator _ => schema => UpdateSchemaFormat(schema, StringFormats.JsonPointer),
                    IMinItemsValidator minItemsValidator => schema => UpdateSchemaMinItems(schema, minItemsValidator),
                    IMaxItemsValidator maxItemsValidator => schema => UpdateSchemaMaxItems(schema, maxItemsValidator),
                    IRegularExpressionValidator regexValidator => schema => UpdateSchemaPattern(schema, regexValidator),
                    IUniqueItemsValidator uniqueItemsValidator => UpdateSchemaUniqueItems,
                    PrecisionScaleValidator<TRequest> precisionScaleValidator => schema => UpdateSchemaMultipleOf(schema, precisionScaleValidator),
                    StringEnumValidator<TRequest> stringEnumValidator => schema => UpdateSchemaEnum(schema, stringEnumValidator),
                    _ => _ => { }
                };

                schemaUpdater.Invoke(schema);
            }
        }

        return Task.CompletedTask;
    }

    private static void UpdateSchemaMinMax(OpenApiSchema schema, IBetweenValidator propertyValidator)
    {
        if (propertyValidator is IInclusiveBetweenValidator)
        {
            schema.Minimum = propertyValidator.From.ToString();
            schema.Maximum = propertyValidator.To.ToString();
        }
        else
        {
            schema.ExclusiveMinimum = propertyValidator.From.ToString();
            schema.ExclusiveMaximum = propertyValidator.To.ToString();
        }
    }

    private static void UpdateSchemaMinMax(OpenApiSchema schema, IComparisonValidator propertyValidator)
    {
        var valueToCompare = propertyValidator.ValueToCompare.ToString();

        Action<OpenApiSchema> updater = propertyValidator.Comparison switch
        {
            Comparison.LessThan => schema => schema.ExclusiveMaximum = valueToCompare,
            Comparison.LessThanOrEqual => schema => schema.Maximum = valueToCompare,
            Comparison.GreaterThan => schema => schema.ExclusiveMinimum = valueToCompare,
            Comparison.GreaterThanOrEqual => schema => schema.Minimum = valueToCompare,
            _ => _ => { }
        };

        updater.Invoke(schema);
    }

    private static void UpdateSchemaEnum(OpenApiSchema schema, IEnumValidator enumValidator)
    {
        schema.Enum = [.. Enum.GetNames(enumValidator.EnumType).Select(name => JsonValue.Create(name)).OfType<JsonNode>()];
    }

    private static void UpdateSchemaMinMaxLength(OpenApiSchema schema, ILengthValidator lengthValidator)
    {
        schema.MinLength = lengthValidator.Min;
        schema.MaxLength = lengthValidator.Max;
    }

    private static void UpdateSchemaMaxItems(OpenApiSchema schema, IMaxItemsValidator maxItemsValidator)
    {
        schema.MaxItems = maxItemsValidator.MaxItems;
    }

    private static void UpdateSchemaMinItems(OpenApiSchema schema, IMinItemsValidator minItemsValidator)
    {
        schema.MinItems = minItemsValidator.MinItems;
    }

    private static void UpdateSchemaMinimum(OpenApiSchema schema)
    {
        Action<OpenApiSchema> updater = schema.Type switch
        {
            JsonSchemaType.Array => schema => schema.MinItems = 1,
            JsonSchemaType.Number => schema => schema.Minimum = 1.ToString(),
            JsonSchemaType.String => schema => schema.MinLength = 1,
            _ => _ => { }
        };

        updater.Invoke(schema);
    }

    private static void UpdateSchemaRequired(OpenApiSchema schema, string propertyName)
    {
        schema.Required ??= new HashSet<string>();        
        schema.Required.Add(propertyName);
    }

    private static void UpdateSchemaMultipleOf(OpenApiSchema schema, PrecisionScaleValidator<TRequest> precisionScaleValidator)
    {
        schema.MultipleOf = (decimal)Math.Pow(10, -precisionScaleValidator.Scale);
    }

    private static void UpdateSchemaPattern(OpenApiSchema schema, IRegularExpressionValidator regexValidator)
    {
        schema.Pattern = regexValidator.Expression;
    }

    private static void UpdateSchemaFormat(OpenApiSchema schema, string format)
    {
        schema.Format = format;
    }

    private static void UpdateSchemaEnum(OpenApiSchema schema, IPropertyValidator validator)
    {
        if (validator.GetType().GetField("_enumNames", NonPublic|Instance)?.GetValue(validator) is IEnumerable<string> enumNames)
        {
            schema.Enum = [.. enumNames.Select(name => JsonValue.Create(name)).OfType<JsonNode>()];
        }
    }

    private static void UpdateSchemaUniqueItems(OpenApiSchema schema)
    {
        schema.UniqueItems = true;
    }
}
