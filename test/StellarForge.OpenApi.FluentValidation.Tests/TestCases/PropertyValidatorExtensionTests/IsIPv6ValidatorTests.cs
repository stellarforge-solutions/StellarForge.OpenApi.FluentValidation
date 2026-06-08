using StellarForge.OpenApi.FluentValidation.Extensions;
using StellarForge.OpenApi.FluentValidation.Tests.Support;
using StellarForge.OpenApi.FluentValidation.Validators;

namespace StellarForge.OpenApi.FluentValidation.Tests.TestCases.PropertyValidatorExtensionTests;

public class IsIPv6ValidatorTests
{
    [Fact]
    public void IsIPv6Validator_True()
    {
        Assert.True(PropertyValidatorExtensions.IsIPv6Validator(new IPv6Validator<TestRequest>()));
    }

    [Fact]
    public void IsIPv6Validator_False()
    {
        Assert.False(PropertyValidatorExtensions.IsIPv6Validator(new IPv4Validator<TestRequest>()));
    }
}
