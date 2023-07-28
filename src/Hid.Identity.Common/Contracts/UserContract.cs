using System.Runtime.Serialization;
using Hid.Checkpoint.Common.Enums;
using Hid.Checkpoint.Common.Extensions;
using Hid.CheckPoint.Shared;
using Hid.Identity.Common.Models;

namespace Hid.Identity.Common.Contracts;

[DataContract]
public class UserContract : IUser
{
    [DataMember(Order = 1)] public Guid Id { get; init; }
    [DataMember(Order = 2)] public int PersonId { get; init; }
    [DataMember(Order = 3)] public string? ExternalEmployeeId { get; init; }
    [DataMember(Order = 4)] public RoleFlags RolesValue { get; init; }

    private List<RoleFlags>? _rolesView;
    public List<RoleFlags>? RolesView => _rolesView ??= RolesValue.GetRolesList();

    private List<string>? _rolesDisplay;
    public List<string>? RolesDisplay => _rolesDisplay ??= RolesView?.Select(q => q.GetDisplayName()).ToList();
}
