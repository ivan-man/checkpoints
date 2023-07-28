using Hid.CheckPoint.Shared.Domain;
using Hid.Checkpoint.Domain.Models;

namespace Hid.Checkpoint.DataAccess.Ef.Repositories.Implementations;

internal class MetadataRepository<TModel>
    : BaseRepositoryIdentity<CheckPointsContext, PropertyMetadata, int>, IMetadataRepository<TModel>
    where TModel : BaseEntity, new()
{
    public MetadataRepository(CheckPointsContext context) : base(context)
    {
    }
}
