using Hid.Checkpoint.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hid.Checkpoint.DataAccess.Ef.Configurations;

public class ApproveChainTemplateConfig : IEntityTypeConfiguration<ChainTemplate>
{
    public void Configure(EntityTypeBuilder<ChainTemplate> builder)
    {
        builder.OwnsMany(p => p.Stages, a =>
        {
            a.WithOwner().HasForeignKey("ApproveChainId");
            a.Property<int>("Id");
            a.HasKey("Id");
        });
    }
}
