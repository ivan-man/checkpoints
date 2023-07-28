using System.ComponentModel.DataAnnotations.Schema;
using Hid.Checkpoint.Common.Enums;
using Hid.CheckPoint.Shared;
using Microsoft.AspNetCore.Identity;

namespace Hid.Identity.Domain.Models;

public class ApplicationUserRole : IdentityRole<Guid>
{
    public RoleFlags Role { get; set; }
    [NotMapped] public string? RoleName => Role.ToString();
    [NotMapped] public string? RoleDisplay => Role.GetDisplayName();
}
