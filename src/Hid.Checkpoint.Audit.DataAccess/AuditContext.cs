using System.Reflection;
using Hid.Checkpoint.Audit.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace Hid.Checkpoint.Audit.DataAccess;

public class AuditContext : DbContext
{
    public DbSet<AuditEntityRecord> AuditRecords { get; set; }

    public AuditContext(DbContextOptions<AuditContext> options) : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
