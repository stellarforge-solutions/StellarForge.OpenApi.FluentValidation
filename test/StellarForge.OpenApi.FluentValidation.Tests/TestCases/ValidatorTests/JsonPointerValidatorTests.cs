using FluentValidation;
using StellarForge.OpenApi.FluentValidation.Tests.Support;
using StellarForge.OpenApi.FluentValidation.Validators;

namespace StellarForge.OpenApi.FluentValidation.Tests.TestCases.ValidatorTests;

public class JsonPointerValidatorTests
{
    [Theory]
    [InlineData(null, true)]
    [InlineData("/properties/name", true)]
    [InlineData("not a JSON pointer", false)]
    public void IsValid(string? jsonPointer, bool expected)
    {
        // ARRANGE
        var validator = new JsonPointerValidator<TestRequest>();
        var context = new ValidationContext<TestRequest>(new TestRequest());

        // ACT & ASSERT
#pragma warning disable CS8604 // Possible null reference argument.
        Assert.Equal(expected, validator.IsValid(context, jsonPointer));
#pragma warning restore CS8604 // Possible null reference argument.
    }
}