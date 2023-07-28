using Hid.Checkpoint.Common.Enums;
using Hid.CheckPoint.Shared;
using Hid.Identity.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Hid.Identity.DataAccess.Ef.Seed;

public static class Seed
{
    public static ModelBuilder SeedRoles(this ModelBuilder modelBuilder)
    {
        var roles = new List<ApplicationUserRole>();

        foreach (var role in Enum.GetValues<RoleFlags>().Where(q => (int)q > 0))
        {
            roles.Add(new ApplicationUserRole
            {
                Id = ((int)role).ToGuid(),
                Name = role.ToString(),
                NormalizedName = role.ToString().ToUpper(),
                Role = role,
            });
        }

        modelBuilder.Entity<ApplicationUserRole>().HasData(roles);

        return modelBuilder;
    }
}
