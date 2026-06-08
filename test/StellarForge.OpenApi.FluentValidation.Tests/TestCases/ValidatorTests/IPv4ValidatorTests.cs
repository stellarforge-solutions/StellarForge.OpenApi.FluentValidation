using FluentValidation;
using StellarForge.OpenApi.FluentValidation.Tests.Support;
using StellarForge.OpenApi.FluentValidation.Validators;

namespace StellarForge.OpenApi.FluentValidation.Tests.TestCases.ValidatorTests;

public class IPv4ValidatorTests
{
    [Theory]
    [InlineData(null, true)]
    [InlineData("192.168.1.1", true)]
    [InlineData("not an IP address", false)]
    public void IsValid(string? ipAddress, bool expected)
    {
        // ARRANGE
        var validator = new IPv4Validator<TestRequest>();
        var context = new ValidationContext<TestRequest>(new TestRequest());

        // ACT & ASSERT
#pragma warning disable CS8604 // Possible null reference argument.
        Assert.Equal(expected, validator.IsValid(context, ipAddress));
#pragma warning restore CS8604 // Possible null reference argument.
    }
}