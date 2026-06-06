using StellarForge.OpenApi.FluentValidation.Tests.TestCases.RequestValidationTransformerTests;

namespace StellarForge.OpenApi.FluentValidation.Tests.Support;

internal class TestRequest
{
    public string[] ArrayProperty { get; set; } = [];

    public decimal DecimalProperty { get; set; }

    public TestEnum EnumProperty { get; set; }

    public int IntProperty { get; set; }

    public string StringProperty { get; set; } = string.Empty;
}