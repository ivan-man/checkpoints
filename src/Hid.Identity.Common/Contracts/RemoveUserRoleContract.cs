using System.Runtime.Serialization;
using Hid.Checkpoint.Common.Enums;

namespace Hid.Identity.Common.Contracts;

[DataContract]
public class RemoveUserRoleContract
{
    [DataMember(Order = 1)] public int? PersonId { get; init; }
    [DataMember(Order = 2)] public Guid? UserId { get; init; }
    [DataMember(Order = 3)] public string? ExternalEmployeeId { get; init; }
    [DataMember(Order = 4)] public RoleFlags RoleValue { get; init; }
}
