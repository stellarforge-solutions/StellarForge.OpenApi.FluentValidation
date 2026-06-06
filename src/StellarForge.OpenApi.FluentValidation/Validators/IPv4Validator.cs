using System.Net;
using System.Net.Sockets;
using FluentValidation;
using FluentValidation.Validators;

namespace StellarForge.OpenApi.FluentValidation.Validators;

internal interface IIPv4Validator;

internal class IPv4Validator<T>() : PropertyValidator<T, string>, IIPv4Validator
{
    public override string Name => nameof(IPv4Validator<>);

    public override bool IsValid(ValidationContext<T> context, string value)
    {
        if (value == null) return true;

        return IPAddress.TryParse(value, out IPAddress? address) && 
            address.AddressFamily == AddressFamily.InterNetwork;
    }
}