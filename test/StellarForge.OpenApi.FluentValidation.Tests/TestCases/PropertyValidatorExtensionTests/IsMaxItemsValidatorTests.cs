using StellarForge.OpenApi.FluentValidation.Extensions;
using StellarForge.OpenApi.FluentValidation.Tests.Support;
using StellarForge.OpenApi.FluentValidation.Validators;

namespace StellarForge.OpenApi.FluentValidation.Tests.TestCases.PropertyValidatorExtensionTests;

public class IsMaxItemsValidatorTests
{
    [Fact]
    public void IsMaxItemsValidator_True()
    {
        const int expectedMaxItems = 5;
        var isMaxItemsValidator = PropertyValidatorExtensions.IsMaxItemsValidator
        (
            new MaxItemsValidator<TestRequest, string>(expectedMaxItems),
            out var actualMaxItems
        );

        Assert.True(isMaxItemsValidator);
        Assert.Equal(expectedMaxItems, actualMaxItems);
    }

    [Fact]
    public void IsMaxItemsValidator_False()
    {
        Assert.False(PropertyValidatorExtensions.IsMaxItemsValidator(new IPv4Validator<TestRequest>(), out _));
    }
}
