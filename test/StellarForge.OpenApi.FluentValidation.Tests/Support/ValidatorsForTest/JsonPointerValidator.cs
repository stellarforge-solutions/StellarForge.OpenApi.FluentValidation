using FluentValidation;
using StellarForge.OpenApi.FluentValidation.Extensions;

namespace StellarForge.OpenApi.FluentValidation.Tests.Support.ValidatorsForTest;

internal class JsonPointerValidator : AbstractValidator<TestRequest>
{
    public JsonPointerValidator()
    {
        RuleFor(x => x.StringProperty).JsonPointer();
    }
}