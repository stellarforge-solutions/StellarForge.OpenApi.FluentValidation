using StellarForge.OpenApi.FluentValidation.Extensions;
using StellarForge.OpenApi.FluentValidation.Tests.Support;
using StellarForge.OpenApi.FluentValidation.Validators;

namespace StellarForge.OpenApi.FluentValidation.Tests.TestCases.PropertyValidatorExtensionTests;

public class IsIPv4ValidatorTests
{
    [Fact]
    public void IsIPv4Validator_True()
    {
        Assert.True(PropertyValidatorExtensions.IsIPv4Validator(new IPv4Validator<TestRequest>()));
    }

    [Fact]
    public void IsIPv4Validator_False()
    {
        Assert.False(PropertyValidatorExtensions.IsIPv4Validator(new IPv6Validator<TestRequest>()));
    }
}
