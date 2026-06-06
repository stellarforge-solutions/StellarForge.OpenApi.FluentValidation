using System.Net;
using System.Net.Sockets;
using FluentValidation;
using FluentValidation.Validators;

namespace StellarForge.OpenApi.FluentValidation.Validators;

internal interface IIPv6Validator;

internal class IPv6Validator<T>() : PropertyValidator<T, string>, IIPv6Validator
{
    public override string Name => nameof(IPv6Validator<>);

    public override bool IsValid(ValidationContext<T> context, string value)
    {
        if (value == null) return true;

        return IPAddress.TryParse(value, out IPAddress? address) && 
            address.AddressFamily == AddressFamily.InterNetworkV6;
    }
}