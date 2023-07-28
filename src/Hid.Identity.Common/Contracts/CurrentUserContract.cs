using System.Runtime.Serialization;
using Hid.Checkpoint.Common.Enums;
using Hid.Checkpoint.Common.Extensions;
using Hid.CheckPoint.Shared;
using Hid.Identity.Common.Models;

namespace Hid.Identity.Common.Contracts;

[DataContract]
public class CurrentUserContract : ICurrentUser
{
    [DataMember(Order = 1)] public string? Login { get; init; }
    [DataMember(Order = 2)] public Guid Id { get; init; }
    [DataMember(Order = 3)] public int PersonId { get; init; }
    [DataMember(Order = 4)] public string? ExternalEmployeeId { get; init; }
    [DataMember(Order = 5)] public RoleFlags RolesValue { get; init; }
    [DataMember(Order = 6)] public Guid? Jti { get; init; }
    [DataMember(Order = 7)] public DateTime? Iat { get; init; }
    
    private List<RoleFlags>? _rolesView;
    public List<RoleFlags>? RolesView => _rolesView ??= RolesValue.GetRolesList();
    
    private List<string>? _rolesDisplay;
    public List<string>? RolesDisplay => _rolesDisplay ??= RolesView?.Select(q => q.GetDisplayName()).ToList();
}
