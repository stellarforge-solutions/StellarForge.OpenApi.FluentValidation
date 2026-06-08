using FluentValidation;
using StellarForge.OpenApi.FluentValidation.Tests.Support;
using StellarForge.OpenApi.FluentValidation.Validators;

namespace StellarForge.OpenApi.FluentValidation.Tests.TestCases.ValidatorTests;

public class IPv6ValidatorTests
{
    [Theory]
    [InlineData(null, true)]
    [InlineData("2001:0db8:85a3:0000:0000:8a2e:0370:7334", true)]
    [InlineData("not an IP address", false)]
    public void IsValid(string? ipAddress, bool expected)
    {
        // ARRANGE
        var validator = new IPv6Validator<TestRequest>();
        var context = new ValidationContext<TestRequest>(new TestRequest());

        // ACT & ASSERT
#pragma warning disable CS8604 // Possible null reference argument.
        Assert.Equal(expected, validator.IsValid(context, ipAddress));
#pragma warning restore CS8604 // Possible null reference argument.
    }
}