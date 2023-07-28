using Hid.Checkpoint.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hid.Checkpoint.DataAccess.Ef.Configurations;

public class OrganizationContractConfig : IEntityTypeConfiguration<OrganizationContract>
{
    public void Configure(EntityTypeBuilder<OrganizationContract> builder)
    {
        builder.HasOne(q => q.Organization)
            .WithMany(q => q.Contracts);

        builder.HasMany(q => q.GuestContractRelations)
            .WithOne(q => q.OrganizationContract);
    }
}
