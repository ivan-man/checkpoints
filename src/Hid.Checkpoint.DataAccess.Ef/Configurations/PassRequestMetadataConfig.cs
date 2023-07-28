using Hid.Checkpoint.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hid.Checkpoint.DataAccess.Ef.Configurations;

public class PassRequestMetadataConfig : IEntityTypeConfiguration<PropertyMetadata>
{
    public void Configure(EntityTypeBuilder<PropertyMetadata> builder)
    {
        builder.HasIndex(q => new { q.RequestTypeId, q.Role, q.EmployeeId, q.PropertyId })
            .IsUnique()
            .HasFilter("removed is not true");
    }
}
