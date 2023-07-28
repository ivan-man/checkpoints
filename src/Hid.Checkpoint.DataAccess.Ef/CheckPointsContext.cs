using System.Reflection;
using Hid.Checkpoint.Common.Enums;
using Hid.Checkpoint.DataAccess.Ef.Seed;
using Hid.Checkpoint.Domain;
using Hid.Checkpoint.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Hid.Checkpoint.DataAccess.Ef;

public class CheckPointsContext : DbContext
{
    public DbSet<Person> Persons { get; private set; }
    public IQueryable<Person> Employees { get; private set; } 
    public IQueryable<Person> Guests { get; private set; }
    
    public DbSet<ApproverPermissionRequest> ApproverPermissionRequests { get; private set; }
    public DbSet<ApprovePermission> ApprovePermissions { get; private set; }
    
    public DbSet<Organization> Organizations { get; private set; }
    public DbSet<OrganizationContract> OrganizationContracts { get; private set; }
    public DbSet<GuestContractRelation> OrganizationContractRelations { get; private set; }
    
    public DbSet<PassRequest> PassRequests { get; private set; }
    public DbSet<Device> Devices { get; private set; }
    public DbSet<AccessLevel> AccessLevels { get; private set; }
    public DbSet<AccessPoint> AccessPoints { get; private set; }
    
    public DbSet<PersonMetadata> PersonMetadata { get; private set; }
    public DbSet<RequestMetadata> RequestsMetadata { get; private set; }
    public DbSet<ProfileMetadata> OrganizationMetadata { get; private set; }
    public DbSet<OrganizationMetadata> ProfileMetadata { get; private set; }
    
    public DbSet<PersonProperty> PersonProperties { get; private set; }
    public DbSet<RequestProperty> RequestsProperties { get; private set; }
    public DbSet<ProfileProperty> OrganizationProperties { get; private set; }
    public DbSet<OrganizationProperty> ProfileProperties { get; private set; }

    public CheckPointsContext(DbContextOptions<CheckPointsContext> options) : base(options)
    {
        if (Persons == null) 
            return;
        
        Employees = Persons.Where(q =>
            q.Profiles.SingleOrDefault(p => p.DisabledDate == null && !p.Removed)!.Organization.Type ==
            OrganizationType.Internal);
            
        Guests = Persons.Where(q =>
            q.Profiles.SingleOrDefault(p => p.DisabledDate == null && !p.Removed)!.Organization.Type ==
            OrganizationType.External);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        
        builder.Entity<PropertyMetadata>(entity =>
        {
            entity.HasDiscriminator<string>("discriminator")
                .HasValue<RequestMetadata>("RequestMetadata")
                .HasValue<PersonMetadata>("PersonMetadata")
                .HasValue<ProfileMetadata>("ProfileMetadata")
                .HasValue<OrganizationMetadata>("OrganizationMetadata");
        
            entity.Metadata.SetTableName("property_metadata");
        });

        builder.SeedData();
    }
}
