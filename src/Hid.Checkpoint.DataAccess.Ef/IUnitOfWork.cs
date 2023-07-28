using Hid.Checkpoint.DataAccess.Ef.Repositories;
using Hid.Checkpoint.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Hid.Checkpoint.DataAccess.Ef;

public interface IUnitOfWork
{
    IPersonRepository Persons { get; }
    IOrganizationRepository Organizations { get; }
    IPassRequestRepository PassRequests { get; }
    IAccessLevelRepository AccessLevels { get; }
    IAccessPointRepository AccessPoints { get; }
    ICountryRepository Countries { get; }
    IDeviceRepository Devices { get; }
    IPositionsRepository Positions { get; }
    ISubdivisionRepository Subdivisions { get; }
    IApproveChainRepository ApproveChains { get; }
    IApproveChainTemplateRepository ApproveChainTemplates { get; }
    IEmailsRepository Emails { get; }

    IMetadataRepository<PassRequest> RequestsMetadata { get; }
    IMetadataRepository<Profile> ProfilesMetadata { get; }
    IMetadataRepository<Organization> OrganizationsMetadata { get; }
    IMetadataRepository<Person> PersonMetadata { get; }

    ICustomizablePropertyRepository RequestProperties { get; }
    ICustomizablePropertyRepository ProfileProperties { get; }
    ICustomizablePropertyRepository OrganizationsProperties { get; }
    ICustomizablePropertyRepository PersonProperties { get; }

    Task<IAsyncDisposable> BeginTransactionAsync(CancellationToken cancellationToken);
    Task RollbackTransactionAsync(CancellationToken cancellationToken);
    Task CommitTransactionAsync(CancellationToken cancellationToken);

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}

public interface IUnitOfWork<out TContext> : IUnitOfWork
    where TContext : DbContext
{
}
