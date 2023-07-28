using Hid.Checkpoint.DataAccess.Ef.Repositories;
using Hid.Checkpoint.DataAccess.Ef.Repositories.Implementations;
using Hid.Checkpoint.Domain.Models;

namespace Hid.Checkpoint.DataAccess.Ef;

internal class UnitOfWork : IUnitOfWork<CheckPointsContext>
{
    protected CheckPointsContext DbContext { get; }
    
    private readonly Lazy<IOrganizationRepository> _organizationRepository;
    private readonly Lazy<IPassRequestRepository> _passRequestRepository;
    private readonly Lazy<IAccessLevelRepository> _accessLevelRepository;
    private readonly Lazy<IAccessPointRepository> _accessPointRepository;
    private readonly Lazy<ICountryRepository> _countryRepository;
    private readonly Lazy<IDeviceRepository> _deviceRepository;
    private readonly Lazy<IPositionsRepository> _positionsRepository;
    private readonly Lazy<ISubdivisionRepository> _subdivisionRepository;
    private readonly Lazy<IApproveChainRepository> _approveChainRepository;
    private readonly Lazy<IApproveChainTemplateRepository> _approveChainTemplateRepository;
    private readonly Lazy<IEmailsRepository> _emailsRepository;
    private readonly Lazy<IPersonRepository> _personsRepository;

    private readonly Lazy<IMetadataRepository<PassRequest>> _passRequestMetadataRepository;
    private readonly Lazy<IMetadataRepository<Profile>> _profileMetadataRepository;
    private readonly Lazy<IMetadataRepository<Organization>> _organizationsMetadataRepository;
    private readonly Lazy<IMetadataRepository<Person>> _personMetadataRepository;
    
    private readonly Lazy<ICustomizablePropertyRepository> _passRequestPropertiesRepository;
    private readonly Lazy<ICustomizablePropertyRepository> _profilePropertiesRepository;
    private readonly Lazy<ICustomizablePropertyRepository> _organizationsPropertiesRepository;
    private readonly Lazy<ICustomizablePropertyRepository> _personPropertiesRepository;
    

    public IPersonRepository Persons => _personsRepository.Value;
    public IOrganizationRepository Organizations => _organizationRepository.Value;
    public IPassRequestRepository PassRequests => _passRequestRepository.Value;
    public IAccessLevelRepository AccessLevels => _accessLevelRepository.Value;
    public IAccessPointRepository AccessPoints => _accessPointRepository.Value;
    public ICountryRepository Countries => _countryRepository.Value;
    public IDeviceRepository Devices => _deviceRepository.Value;
    public IPositionsRepository Positions => _positionsRepository.Value;
    public ISubdivisionRepository Subdivisions => _subdivisionRepository.Value;
    public IApproveChainRepository ApproveChains => _approveChainRepository.Value;
    public IApproveChainTemplateRepository ApproveChainTemplates => _approveChainTemplateRepository.Value;
    public IEmailsRepository Emails => _emailsRepository.Value;

    public IMetadataRepository<PassRequest> RequestsMetadata => _passRequestMetadataRepository.Value;
    public IMetadataRepository<Profile> ProfilesMetadata => _profileMetadataRepository.Value;
    public IMetadataRepository<Organization> OrganizationsMetadata => _organizationsMetadataRepository.Value;
    public IMetadataRepository<Person> PersonMetadata => _personMetadataRepository.Value;

    public ICustomizablePropertyRepository RequestProperties => _passRequestPropertiesRepository.Value;
    public ICustomizablePropertyRepository ProfileProperties => _profilePropertiesRepository.Value;
    public ICustomizablePropertyRepository OrganizationsProperties => _organizationsPropertiesRepository.Value;
    public ICustomizablePropertyRepository PersonProperties => _personPropertiesRepository.Value;

    public UnitOfWork(CheckPointsContext dbContext)
    {
        DbContext = dbContext;
        
        _personsRepository = new Lazy<IPersonRepository>(() => new PersonRepository(dbContext));
        _organizationRepository = new Lazy<IOrganizationRepository>(() => new OrganizationRepository(dbContext));
        _passRequestRepository = new Lazy<IPassRequestRepository>(() => new PassRequestRepository(dbContext));
        _accessLevelRepository = new Lazy<IAccessLevelRepository>(() => new AccessLevelRepository(dbContext));
        _accessPointRepository = new Lazy<IAccessPointRepository>(() => new AccessPointRepository(dbContext));
        _countryRepository = new Lazy<ICountryRepository>(() => new CountryRepository(dbContext));
        _deviceRepository = new Lazy<IDeviceRepository>(() => new DeviceRepository(dbContext));
        _positionsRepository = new Lazy<IPositionsRepository>(() => new PositionsRepository(dbContext));
        _subdivisionRepository = new Lazy<ISubdivisionRepository>(() => new SubdivisionRepository(dbContext));
        _approveChainRepository = new Lazy<IApproveChainRepository>(() => new ApproveChainRepository(dbContext));
        _approveChainTemplateRepository = new Lazy<IApproveChainTemplateRepository>(() => new ApproveChainTemplateRepository(dbContext));
        _emailsRepository = new Lazy<IEmailsRepository>(() => new EmailsRepository(dbContext));
        
        _passRequestMetadataRepository = new Lazy<IMetadataRepository<PassRequest>>(() => new MetadataRepository<PassRequest>(dbContext));
        _profileMetadataRepository = new Lazy<IMetadataRepository<Profile>>(() => new MetadataRepository<Profile>(dbContext));
        _organizationsMetadataRepository = new Lazy<IMetadataRepository<Organization>>(() => new MetadataRepository<Organization>(dbContext));
        _personMetadataRepository = new Lazy<IMetadataRepository<Person>>(() => new MetadataRepository<Person>(dbContext));
    
        _passRequestPropertiesRepository = new Lazy<ICustomizablePropertyRepository>(() => new CustomizablePropertyRepository(dbContext));
        _profilePropertiesRepository = new Lazy<ICustomizablePropertyRepository>(() => new CustomizablePropertyRepository(dbContext));
        _organizationsPropertiesRepository = new Lazy<ICustomizablePropertyRepository>(() => new CustomizablePropertyRepository(dbContext));
        _personPropertiesRepository = new Lazy<ICustomizablePropertyRepository>(() => new CustomizablePropertyRepository(dbContext));
    }
    
    public async Task<IAsyncDisposable> BeginTransactionAsync(CancellationToken cancellationToken)
    {
        return await DbContext.Database.BeginTransactionAsync(cancellationToken);
    }

    public Task RollbackTransactionAsync(CancellationToken cancellationToken)
    {
        return DbContext.Database.RollbackTransactionAsync(cancellationToken);
    }

    public Task CommitTransactionAsync(CancellationToken cancellationToken)
    {
        return DbContext.Database.CommitTransactionAsync(cancellationToken);
    }

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return DbContext.SaveChangesAsync(cancellationToken);
    }
}
