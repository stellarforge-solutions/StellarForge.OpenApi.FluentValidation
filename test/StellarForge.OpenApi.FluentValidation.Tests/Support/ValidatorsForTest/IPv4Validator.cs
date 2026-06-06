using FluentValidation;
using StellarForge.OpenApi.FluentValidation.Extensions;

namespace StellarForge.OpenApi.FluentValidation.Tests.Support.ValidatorsForTest;

internal class IPv4Validator : AbstractValidator<TestRequest>
{
    public IPv4Validator()
    {
        RuleFor(x => x.StringProperty).IPv4();
    }
}