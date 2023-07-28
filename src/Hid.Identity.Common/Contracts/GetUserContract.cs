using System.Runtime.Serialization;

namespace Hid.Identity.Common.Contracts;

[DataContract]
public class GetUserContract
{
    [DataMember(Order = 1)] public string? UserName { get; init; }
    [DataMember(Order = 2)] public int? PersonId { get; init; }
    [DataMember(Order = 3)] public string? ExternalEmployeeId { get; init; }
    [DataMember(Order = 4)] public string? Email { get; init; }
    [DataMember(Order = 5)] public string? PhoneNumber { get; init; }
}
