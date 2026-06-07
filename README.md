# StellarForge.OpenApi.FluentValidation

StellarForge.OpenApi.FluentValidation is a package that exposes the [FluentValidation](https://docs.fluentvalidation.net/en/latest/) rules of API endpoints to [Microsoft.OpenApi](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/openapi/aspnetcore-openapi?view=aspnetcore-10.0).

## Statuses

[![License](https://img.shields.io/github/license/stellarforge-solutions/StellarForge.OpenApi.FluentValidation.svg)](https://raw.githubusercontent.com/stellar-forge/StellarForge.OpenApi.FluentValidation/master/LICENSE)
[![NuGetVersion](https://img.shields.io/nuget/v/StellarForge.OpenApi.FluentValidation.svg)](https://www.nuget.org/packages/StellarForge.OpenApi.FluentValidation)
![NuGetDownloads](https://img.shields.io/nuget/dt/StellarForge.OpenApi.FluentValidation.svg)

![Build and publish](https://github.com/stellarforge-solutions/StellarForge.OpenApi.FluentValidation/workflows/Build%20and%20publish/badge.svg)
[![Build status](https://ci.appveyor.com/api/projects/status/tcn613c0lqst33ot?svg=true)](https://ci.appveyor.com/project/stellarforge-solutions/stellarforge-openapi-fluentvalidation)
[![Coverage Status](https://coveralls.io/github/stellarforge-solutions/StellarForge.OpenApi.FluentValidation/badge.svg)](https://coveralls.io/github/stellarforge-solutions/StellarForge.OpenApi.FluentValidation)


## Validator to OpenApi Spec Mapping (built-in FluentValidation validators)

### [CreditCardValidator](https://github.com/FluentValidation/FluentValidation/blob/main/src/FluentValidation/Validators/CreditCardValidator.cs)

#### ExampleRequestValidator.cs
```csharp
using FluentValidation;

public class ExampleRequestValidator : AbstractValidator<ExampleRequest>
{
    public ExampleRequestValidator()
    {
        RuleFor(x => x.StringProperty).CreditCard();
    }
}
```

#### Generated OAS snippet
```yaml
components:
  schemas:
    ExampleRequest:
      type: object
      properties:
        stringProperty:
          type: string
          format: credit-card 
```

### [EmailValidator](https://github.com/FluentValidation/FluentValidation/blob/main/src/FluentValidation/Validators/EmailValidator.cs)

#### ExampleRequestValidator.cs
```csharp
using FluentValidation;

public class ExampleRequestValidator : AbstractValidator<ExampleRequest>
{
    public ExampleRequestValidator()
    {
        RuleFor(x => x.StringProperty).Email();
    }
}
```

#### Generated OAS snippet
```yaml
components:
  schemas:
    ExampleRequest:
      type: object
      properties:
        stringProperty:
          type: string
          format: email
```

### [EnumValidator](https://github.com/FluentValidation/FluentValidation/blob/main/src/FluentValidation/Validators/EnumValidator.cs)

Used when binding an enum property that must be a valid enum value.

#### ExampleRequestValidator.cs
```csharp
using FluentValidation;

public class ExampleRequestValidator : AbstractValidator<ExampleRequest>
{
    public ExampleRequestValidator()
    {
        // EnumProperty is of type SortOrder:
        //
        // pubilc enum SortOrder
        // {
        //     Asc,
        //     Desc
        // }
        RuleFor(x => x.EnumProperty).IsInEnum();
    }
}
```

#### Generated OAS snippet
```yaml
components:
  schemas:
    ExampleRequest:
      type: object
      properties:
        enumProperty:
          type: string
          enum: [asc, desc]
```

### [ExclusiveBetweenValidator](https://github.com/FluentValidation/FluentValidation/blob/main/src/FluentValidation/Validators/ExclusiveBetweenValidator.cs)

#### ExampleRequestValidator.cs
```csharp
using FluentValidation;

public class ExampleRequestValidator : AbstractValidator<ExampleRequest>
{
    public ExampleRequestValidator()
    {
        RuleFor(x => x.IntProperty).ExclusiveBetween(1, 10);
    }
}
```

#### Generated OAS snippet
```yaml
components:
  schemas:
    ExampleRequest:
      type: object
      properties:
        intProperty:
          type: integer
          exclusiveMinimum: 1
          exclusiveMaximum: 10
```

### [GreaterThanOrEqualToValidator](https://github.com/FluentValidation/FluentValidation/blob/main/src/FluentValidation/Validators/GreaterThanOrEqualValidator.cs)

#### ExampleRequestValidator.cs
```csharp
using FluentValidation;

public class ExampleRequestValidator : AbstractValidator<ExampleRequest>
{
    public ExampleRequestValidator()
    {
        RuleFor(x => x.IntProperty).GreaterThanOrEqualTo(10);
    }
}
```

#### Generated OAS snippet
```yaml
components:
  schemas:
    ExampleRequest:
      type: object
      properties:
        intProperty:
          type: integer
          minimum: 10
```

### [GreaterThanValidator](https://github.com/FluentValidation/FluentValidation/blob/main/src/FluentValidation/Validators/GreaterThanValidator.cs)

#### ExampleRequestValidator.cs
```csharp
using FluentValidation;

public class ExampleRequestValidator : AbstractValidator<ExampleRequest>
{
    public ExampleRequestValidator()
    {
        RuleFor(x => x.IntProperty).GreaterThan(10);
    }
}
```

#### Generated OAS snippet
```yaml
components:
  schemas:
    ExampleRequest:
      type: object
      properties:
        intProperty:
          type: integer
          exclusiveMinimum: 10
```

### [InclusiveBetweenValidator](https://github.com/FluentValidation/FluentValidation/blob/main/src/FluentValidation/Validators/InclusiveBetweenValidator.cs)

#### ExampleRequestValidator.cs
```csharp
using FluentValidation;

public class ExampleRequestValidator : AbstractValidator<ExampleRequest>
{
    public ExampleRequestValidator()
    {
        RuleFor(x => x.IntProperty).Between(1, 10);
    }
}
```

#### Generated OAS snippet
```yaml
components:
  schemas:
    ExampleRequest:
      type: object
      properties:
        intProperty:
          type: integer
          minimum: 1
          maximum: 10
```

### [LengthValidator](https://github.com/FluentValidation/FluentValidation/blob/main/src/FluentValidation/Validators/LengthValidator.cs)

#### ExampleRequestValidator.cs
```csharp
using FluentValidation;

public class ExampleRequestValidator : AbstractValidator<ExampleRequest>
{
    public ExampleRequestValidator()
    {
        RuleFor(x => x.StringProperty).Length(1, 10);
    }
}
```

#### Generated OAS snippet
```yaml
components:
  schemas:
    ExampleRequest:
      type: object
      properties:
        stringProperty:
          type: string
          minimum: 1
          maximum: 10
```

### [LessThanOrEqualToValidator](https://github.com/FluentValidation/FluentValidation/blob/main/src/FluentValidation/Validators/LessThanOrEqualValidator.cs)

#### ExampleRequestValidator.cs
```csharp
using FluentValidation;

public class ExampleRequestValidator : AbstractValidator<ExampleRequest>
{
    public ExampleRequestValidator()
    {
        RuleFor(x => x.IntProperty).LessThanOrEqualTo(10);
    }
}
```

#### Generated OAS snippet
```yaml
components:
  schemas:
    ExampleRequest:
      type: object
      properties:
        intProperty:
          type: integer
          maximum: 10
```

### [LessThanValidator](https://github.com/FluentValidation/FluentValidation/blob/main/src/FluentValidation/Validators/LessThanValidator.cs)

#### ExampleRequestValidator.cs
```csharp
using FluentValidation;

public class ExampleRequestValidator : AbstractValidator<ExampleRequest>
{
    public ExampleRequestValidator()
    {
        RuleFor(x => x.IntProperty).LessThan(10);
    }
}
```

#### Generated OAS snippet
```yaml
components:
  schemas:
    ExampleRequest:
      type: object
      properties:
        intProperty:
          type: integer
          exclusiveMaximum: 10
```

### [NotEmptyValidator](https://github.com/FluentValidation/FluentValidation/blob/main/src/FluentValidation/Validators/NotEmptyValidator.cs)

#### ExampleRequestValidator.cs
```csharp
using FluentValidation;

public class ExampleRequestValidator : AbstractValidator<ExampleRequest>
{
    public ExampleRequestValidator()
    {
        RuleFor(x => x.ArrayProperty).NotEmpty();
        RuleFor(x => x.IntProperty).NotEmpty();
        RuleFor(x => x.StringProperty).NotEmpty();
    }
}
```

#### Generated OAS snippet
```yaml
components:
  schemas:
    ExampleRequest:
      type: object
      properties:      
        arrayProperty:
          type: array
          minItems: 1
        intProperty:
          type: integer
          minimum: 1
        stringProperty:
          type: string
          minLength: 1
```

### [PrecisionScaleValidator](https://github.com/FluentValidation/FluentValidation/blob/main/src/FluentValidation/Validators/PrecisionScaleValidator.cs)

*Precision* is the total number of digits allowed in a number, while *scale* is the number of digits allowed after the decimal point. To document that a numeric value must have a certain number of digits after the decimal point, the schema `multipleOf` property is set to `10^-scale`. 

For example:
To document that a request parameter representing currency has 2 digits to the right of the decimal, the schema `multipleOf` property would be set to `0.01`. Per [IETF JSON Schema Validation Section 6.2.1](https://datatracker.ietf.org/doc/html/draft-bhutton-json-schema-validation-00#section-6.2.1):
> A numeric instance is valid only if division by this keyword's value results in an integer.

So a value of `50.75` would be valid (50.75 ÷ 0.01 = 5075 --> which is an integer) but a value of `50.749` would be invalid (50.749 ÷ 0.01 = 5074.9 --> which is not an integer). 


#### ExampleRequestValidator.cs
```csharp
using FluentValidation;

public class ExampleRequestValidator : AbstractValidator<ExampleRequest>
{
    public ExampleRequestValidator()
    {
        RuleFor(x => x.DecimalProperty).PrecisionScale(precision: 2, scale: 2);
    }
}
```

#### Generated OAS snippet
```yaml
components:
  schemas:
    ExampleRequest:
      type: object
      properties:
        decimalProperty:
          type: number
          format: float
          multipleOf: 0.01
```

### [RegularExpressionValidator](https://github.com/FluentValidation/FluentValidation/blob/main/src/FluentValidation/Validators/RegularExpressionValidator.cs)

#### ExampleRequestValidator.cs
```csharp
using FluentValidation;

public class ExampleRequestValidator : AbstractValidator<ExampleRequest>
{
    public ExampleRequestValidator()
    {
        RuleFor(x => x.StringProperty).Matches(@"^regex-pattern$");
    }
}
```

#### Generated OAS snippet
```yaml
components:
  schemas:
    ExampleRequest:
      type: object
      properties:
        stringProperty:
          type: string
          pattern: '^regex-pattern$' 
```

### [StringEnumValidator](https://github.com/FluentValidation/FluentValidation/blob/main/src/FluentValidation/Validators/StringEnumValidator.cs)

Used when binding a string property that must match the name of an enum value.

#### ExampleRequestValidator.cs
```csharp
using FluentValidation;

public class ExampleRequestValidator : AbstractValidator<ExampleRequest>
{
    public ExampleRequestValidator()
    {
        // pubilc enum SortOrder
        // {
        //     Asc,
        //     Desc
        // }
        RuleFor(x => x.StringProperty).IsEnumName(typeof(SortOrder)();
    }
}
```

#### Generated OAS snippet
```yaml
components:
  schemas:
    ExampleRequest:
      type: object
      properties:
        stringProperty:
          type: string
          enum: [asc, desc]
```

## Validator to OpenApi Spec Mapping (custom validators)

### [IPv4Validator](https://github.com/stellarforge-solutions/StellarForge.OpenApi.FluentValidation/main/src/StellarForge.OpenApi.FluentValidation/Validators/IPv4Validator.cs)

See https://datatracker.ietf.org/doc/html/draft-bhutton-json-schema-validation-00#section-7.3.4.

#### ExampleRequestValidator.cs
```csharp
using StellarForge.OpenApi.FluentValidation.Extensions;

public class ExampleRequestValidator : AbstractValidator<ExampleRequest>
{
    public ExampleRequestValidator()
    {
        RuleFor(x => x.StringProperty).IPv4();
    }
}
```

#### Generated OAS snippet
```yaml
components:
  schemas:
    ExampleRequest:
      type: object
      properties:
        stringProperty:
          type: string
          format: ipv4
```

### [IPv6Validator](https://github.com/stellarforge-solutions/StellarForge.OpenApi.FluentValidation/main/src/StellarForge.OpenApi.FluentValidation/Validators/IPv6Validator.cs)

See https://datatracker.ietf.org/doc/html/draft-bhutton-json-schema-validation-00#section-7.3.4.

#### ExampleRequestValidator.cs
```csharp
using StellarForge.OpenApi.FluentValidation.Extensions;

public class ExampleRequestValidator : AbstractValidator<ExampleRequest>
{
    public ExampleRequestValidator()
    {
        RuleFor(x => x.StringProperty).IPv6();
    }
}
```

#### Generated OAS snippet
```yaml
components:
  schemas:
    ExampleRequest:
      type: object
      properties:
        stringProperty:
          type: string
          format: ipv6
```

### [JsonPointerValidator](https://github.com/stellarforge-solutions/StellarForge.OpenApi.FluentValidation/main/src/StellarForge.OpenApi.FluentValidation/Validators/JsonPointerValidator.cs)

See https://datatracker.ietf.org/doc/html/draft-bhutton-json-schema-validation-00#section-7.3.7.

#### ExampleRequestValidator.cs
```csharp
using StellarForge.OpenApi.FluentValidation.Extensions;

public class ExampleRequestValidator : AbstractValidator<ExampleRequest>
{
    public ExampleRequestValidator()
    {
        RuleFor(x => x.StringProperty).JsonPointer();
    }
}
```

#### Generated OAS snippet
```yaml
components:
  schemas:
    ExampleRequest:
      type: object
      properties:
        stringProperty:
          type: string
          format: json-pointer
```

### [MinItemsValidator](https://github.com/stellarforge-solutions/StellarForge.OpenApi.FluentValidation/main/src/StellarForge.OpenApi.FluentValidation/Validators/MinItemsValidator.cs)

See https://datatracker.ietf.org/doc/html/draft-bhutton-json-schema-validation-00#section-6.4.1.

#### ExampleRequestValidator.cs
```csharp
using StellarForge.OpenApi.FluentValidation.Extensions;

public class ExampleRequestValidator : AbstractValidator<ExampleRequest>
{
    public ExampleRequestValidator()
    {
        RuleFor(x => x.ArrayProperty).MinItems(5);
    }
}
```

#### Generated OAS snippet
```yaml
components:
  schemas:
    ExampleRequest:
      type: object
      properties:
        arrayProperty:
          type: array
          minItems: 5
```

### [MaxItemsValidator](https://github.com/stellarforge-solutions/StellarForge.OpenApi.FluentValidation/main/src/StellarForge.OpenApi.FluentValidation/Validators/MaxItemsValidator.cs)

See https://datatracker.ietf.org/doc/html/draft-bhutton-json-schema-validation-00#section-6.4.1.

#### ExampleRequestValidator.cs
```csharp
using StellarForge.OpenApi.FluentValidation.Extensions;

public class ExampleRequestValidator : AbstractValidator<ExampleRequest>
{
    public ExampleRequestValidator()
    {
        RuleFor(x => x.ArrayProperty).MaxItems(10);
    }
}
```

#### Generated OAS snippet
```yaml
components:
  schemas:
    ExampleRequest:
      type: object
      properties:
        arrayProperty:
          type: array
          maxItems: 10
```

### [UniqueItemsValidator](https://github.com/stellarforge-solutions/StellarForge.OpenApi.FluentValidation/main/src/StellarForge.OpenApi.FluentValidation/Validators/UniqueItemsValidator.cs)

See https://datatracker.ietf.org/doc/html/draft-bhutton-json-schema-validation-00#section-6.4.3.

#### ExampleRequestValidator.cs
```csharp
using StellarForge.OpenApi.FluentValidation.Extensions;

public class ExampleRequestValidator : AbstractValidator<ExampleRequest>
{
    public ExampleRequestValidator()
    {
        RuleFor(x => x.ArrayProperty).UniqueItems();
    }
}
```

#### Generated OAS snippet
```yaml
components:
  schemas:
    ExampleRequest:
      type: object
      properties:
        arrayProperty:
          type: array
          uniqueItems: true
```

## Usage

### Api.csproj

```xml
<Project Sdk="Microsoft.NET.Sdk.Web">

    <PropertyGroup>
        <TargetFramework>net10.0</TargetFramework>
        <Nullable>enable</Nullable>
        <ImplicitUsings>enable</ImplicitUsings>
    </PropertyGroup>

    <ItemGroup>        
        <PackageReference Include="FluentValidation" Version="12.1.1" />
        <PackageReference Include="FluentValidation.DependencyInjectionExtensions" Version="12.1.1" />
        <PackageReference Include="StellarForge.OpenApi.FluentValidation" Version="1.0.0" />
        <PackageReference Include="Microsoft.AspNetCore.OpenApi" Version="10.0.5" />
        <PackageReference Include="Scalar.AspNetCore" Version="2.13.17" />
        <PackageReference Include="Scalar.AspNetCore.Microsoft" Version="2.13.17" />
    </ItemGroup>
    
</Project>
```

### ForecastRequest.cs

```csharp
using System.Text.Json.Serialization;

/// <summary>
/// Validated by <see cref="ForecastRequestValidator"/>
/// </summary>
public class ForecastRequest
{
    [JsonPropertyName("days")]
    public int ForecastDays { get; set; }

    [JsonPropertyName("latitude")]
    public double Latitude { get; set; }

    [JsonPropertyName("longitude")]
    public double Longitude { get; set; }
}
```

### ForecastRequestValidator.cs

```csharp
using FluentValidation;

public class ForecastRequestValidator : AbstractValidator<ForecastRequest>
{
    public ForecastRequestValidator()
    {
        RuleFor(x => x.ForecastDays)
            .InclusiveBetween(1, 7);

        RuleFor(x => x.Latitude)
            .InclusiveBetween(-90, 90);

        RuleFor(x => x.Longitude)
            .InclusiveBetween(0, 180);
    }
}
```

### 1. Modular Endpoints

#### GetWeatherForecastEndpoint.cs

```csharp
using Microsoft.AspNetCore.Builder;
using StellarForge.OpenApi.FluentValidation;

internal sealed class GetWeatherForecastEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("weatherForecast", HandleAsync)
            .AddOpenApiOperationTransformer(new RequestValidationTransformer<ForecastRequestValidator, ForecastRequest>().TransformAsync);
    }

    private async Task<IResult> HandleAsync([AsParameters] ForecastRequest request, 
        [FromServices] WeatherForecastQuery query,
        CancellationToken cancellationToken)
    {
        // Get the forecast
    }
}
```

### 2. Minimal API

#### Program.cs

```csharp
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using StellarForge.OpenApi.FluentValidation;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddValidatorsFromAssemblyContaining<Program>();

var app = builder.Build();

app.MapOpenApi();
app.MapScalarApiReference(ConfigureScalarOptions);

app.MapGet("/weatherforecast", GetWeatherForecastAsync)
    .AddOpenApiOperationTransformer(new RequestValidationTransformer<ForecastRequestValidator, ForecastRequest>());

app.Run();

private async Task<IResult> GetWeatherForecastAsync([AsParameters] ForecastRequest request,
    [FromServices] WeatherForecastQuery query,
    CancellationToken cancellationToken)
{
    // Get the forecast
}
```
