using Hid.CheckPoint.Shared.Domain;
using Hid.Identity.DataAccess.Ef.Seed;
using Hid.Identity.Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Hid.Identity.DataAccess.Ef;

public class HidIdentityContext : IdentityDbContext<ApplicationUser, ApplicationUserRole, Guid>
{
    public DbSet<ApplicationUser> Users { get; set; }
    public DbSet<ApplicationUserRole> Roles { get; set; }
    public DbSet<RefreshToken> RefreshTokens { get; set; }

    public HidIdentityContext(DbContextOptions<HidIdentityContext> options)
        : base(options)
    {
        // ReSharper disable once VirtualMemberCallInConstructor
        ChangeTracker.StateChanged += OnEntityStateChanged;
    }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.SeedRoles();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseLoggerFactory(GetDbLoggerFactory()).EnableSensitiveDataLogging();
        optionsBuilder.EnableDetailedErrors();

        base.OnConfiguring(optionsBuilder);
    }

    private void OnEntityStateChanged(object? sender, EntityStateChangedEventArgs e)
    {
        if (e.Entry.Entity is not IBaseEntity entity)
            return;

        switch (e.Entry.State)
        {
            case EntityState.Modified:
                entity.Updated = DateTime.UtcNow;
                break;
            case EntityState.Added: //It does not work on creating, because state of entity is 'Unchanged'
            case EntityState.Unchanged:
                entity.Created = entity.Created == default ? DateTime.UtcNow : entity.Created;
                break;
            case EntityState.Detached:
            case EntityState.Deleted:
            default:
                break;
        }
    }

    private static ILoggerFactory? GetDbLoggerFactory()
    {
        IServiceCollection serviceCollection = new ServiceCollection();
        serviceCollection.AddLogging(builder =>
            builder.AddFilter(DbLoggerCategory.Database.Command.Name, LogLevel.Debug));

        return serviceCollection.BuildServiceProvider().GetService<ILoggerFactory>();
    }
}
