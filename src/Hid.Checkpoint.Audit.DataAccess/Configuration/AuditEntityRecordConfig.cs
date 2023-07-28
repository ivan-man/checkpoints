using Hid.Checkpoint.Audit.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hid.Checkpoint.Audit.DataAccess.Configuration;

public class AuditEntityRecordConfig : IEntityTypeConfiguration<AuditEntityRecord>
{
    public void Configure(EntityTypeBuilder<AuditEntityRecord> builder)
    {
        builder.HasMany(
                p => p.AuditMembers)
            .WithOne(q => q.AuditEntityRecord);
    }
}
