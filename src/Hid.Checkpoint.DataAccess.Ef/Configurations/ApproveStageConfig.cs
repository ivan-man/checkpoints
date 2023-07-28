using Hid.Checkpoint.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hid.Checkpoint.DataAccess.Ef.Configurations;

public class ApproveStageConfig : IEntityTypeConfiguration<ApproveStage>
{
    public void Configure(EntityTypeBuilder<ApproveStage> builder)
    {
        builder.HasOne(p => p.Approver);
        builder.HasMany(p => p.Responsibles);
        
        builder.HasMany(p => p.PrevStages)
            .WithMany(p => p.NextStages);
        
        builder.HasMany(p => p.NextStages)
            .WithMany(p => p.PrevStages);
    }
}
