using System.Runtime.Serialization;

namespace Hid.Identity.Common.Contracts;

[DataContract]
public class ValidateTokenContract
{
    [DataMember(Order = 1)] public string? Token { get; set; }

}
