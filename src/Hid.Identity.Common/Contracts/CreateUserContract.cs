using System.Runtime.Serialization;
using Hid.Checkpoint.Common.Enums;

namespace Hid.Identity.Common.Contracts;

[DataContract]
public class CreateUserContract
{
    [DataMember(Order = 1)] public string? Login { get; set; }
    [DataMember(Order = 2)] public int? PersonId { get; set; }
    [DataMember(Order = 3)] public string? ExternalEmployeeId { get; set; }
    [DataMember(Order = 4)] public RoleFlags RolesValue { get; set; }
    [DataMember(Order = 5)] public string? Email { get; set; }
    [DataMember(Order = 6)] public string? PhoneNumber { get; set; }
    [DataMember(Order = 7)] public string? UserSecret { get; set; }
}
