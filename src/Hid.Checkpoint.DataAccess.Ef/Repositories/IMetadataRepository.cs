using Hid.CheckPoint.Shared.Domain;
using Hid.Checkpoint.Domain.Models;

namespace Hid.Checkpoint.DataAccess.Ef.Repositories;

public interface IMetadataRepository<TModel> : IBaseRepositoryIdentity<PropertyMetadata, int>
    where TModel : BaseEntity, new()
{
}
