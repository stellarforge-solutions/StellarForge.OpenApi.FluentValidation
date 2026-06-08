using StellarForge.OpenApi.FluentValidation.Extensions;
using StellarForge.OpenApi.FluentValidation.Tests.Support;
using StellarForge.OpenApi.FluentValidation.Validators;

namespace StellarForge.OpenApi.FluentValidation.Tests.TestCases.PropertyValidatorExtensionTests;

public class IsJsonPointerValidatorTests
{
    [Fact]
    public void IsJsonPointerValidator_True()
    {
        Assert.True(PropertyValidatorExtensions.IsJsonPointerValidator(new JsonPointerValidator<TestRequest>()));
    }

    [Fact]
    public void IsJsonPointerValidator_False()
    {
        Assert.False(PropertyValidatorExtensions.IsJsonPointerValidator(new IPv4Validator<TestRequest>()));
    }
}
