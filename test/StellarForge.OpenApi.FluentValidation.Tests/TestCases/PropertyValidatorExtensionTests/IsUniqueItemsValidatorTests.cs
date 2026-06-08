using StellarForge.OpenApi.FluentValidation.Extensions;
using StellarForge.OpenApi.FluentValidation.Tests.Support;
using StellarForge.OpenApi.FluentValidation.Validators;

namespace StellarForge.OpenApi.FluentValidation.Tests.TestCases.PropertyValidatorExtensionTests;

public class IsUniqueItemsValidatorTests
{
    [Fact]
    public void IsUniqueItemsValidator_True()
    {
        Assert.True(PropertyValidatorExtensions.IsUniqueItemsValidator(new UniqueItemsValidator<TestRequest, string>()));
    }

    [Fact]
    public void IsUniqueItemsValidator_False()
    {
        Assert.False(PropertyValidatorExtensions.IsUniqueItemsValidator(new IPv4Validator<TestRequest>()));
    }
}
