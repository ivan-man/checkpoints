using Hid.Checkpoint.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hid.Checkpoint.DataAccess.Ef.Configurations;

public class ApproveChainConfig : IEntityTypeConfiguration<ApproveChain>
{
    public void Configure(EntityTypeBuilder<ApproveChain> builder)
    {
        builder.HasMany(p => p.Stages)
            .WithOne(p => p.Chain);
    }
}
