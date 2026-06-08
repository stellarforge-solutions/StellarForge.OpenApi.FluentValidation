using FluentValidation;
using StellarForge.OpenApi.FluentValidation.Tests.Support;
using StellarForge.OpenApi.FluentValidation.Validators;

namespace StellarForge.OpenApi.FluentValidation.Tests.TestCases.ValidatorTests;

public class UniqueItemsValidatorTests
{
    [Theory]
    [InlineData(null, true)]
    [InlineData(new[] { "item1", "item2" }, true)]
    [InlineData(new[] { "duplicate", "duplicate" }, false)]
    public void IsValid(IEnumerable<string>? value, bool expected)
    {
        // ARRANGE
        var validator = new UniqueItemsValidator<TestRequest, string>();
        var context = new ValidationContext<TestRequest>(new TestRequest());

        // ACT & ASSERT
#pragma warning disable CS8604 // Possible null reference argument.
        Assert.Equal(expected, validator.IsValid(context, value));
#pragma warning restore CS8604 // Possible null reference argument.
    }
}