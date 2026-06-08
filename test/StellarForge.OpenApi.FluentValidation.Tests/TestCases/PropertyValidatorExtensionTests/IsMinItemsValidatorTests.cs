using StellarForge.OpenApi.FluentValidation.Extensions;
using StellarForge.OpenApi.FluentValidation.Tests.Support;
using StellarForge.OpenApi.FluentValidation.Validators;

namespace StellarForge.OpenApi.FluentValidation.Tests.TestCases.PropertyValidatorExtensionTests;

public class IsMinItemsValidatorTests
{
    [Fact]
    public void IsMinItemsValidator_True()
    {
        const int expectedMinItems = 2;
        var isMinItemsValidator = PropertyValidatorExtensions.IsMinItemsValidator
        (
            new MinItemsValidator<TestRequest, string>(expectedMinItems),
            out var actualMinItems
        );

        Assert.True(isMinItemsValidator);
        Assert.Equal(expectedMinItems, actualMinItems);
    }

    [Fact]
    public void IsMinItemsValidator_False()
    {
        Assert.False(PropertyValidatorExtensions.IsMinItemsValidator(new IPv4Validator<TestRequest>(), out _));
    }
}
