using Hid.Checkpoint.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hid.Checkpoint.DataAccess.Ef.Configurations;

public class AccessLevelConfig : IEntityTypeConfiguration<AccessLevel>
{
    public void Configure(EntityTypeBuilder<AccessLevel> builder)
    {
        builder.HasMany(p => p.AccessPoints)
            .WithMany(q => q.AccessLevels);
        
        builder.HasMany(p => p.Approvers);
    }
}
