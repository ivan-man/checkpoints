using Hid.CheckPoint.Shared.Domain;
using Hid.Checkpoint.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hid.Checkpoint.DataAccess.Ef.Configurations;

public class CustomizablePropertyConfig<TModel> : IEntityTypeConfiguration<CustomizableProperty>
    where TModel : BaseEntity, new()
{
    public void Configure(EntityTypeBuilder<CustomizableProperty> builder)
    {
        builder.HasIndex(q => new { Type = q.TypeFullName, PropertyName = q.Name })
            .IsUnique()
            .HasFilter("removed is not true");
    }
}
