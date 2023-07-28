using Hid.Checkpoint.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hid.Checkpoint.DataAccess.Ef.Configurations;

public class PersonConfig : IEntityTypeConfiguration<Person>
{
    public void Configure(EntityTypeBuilder<Person> builder)
    {
        builder.Ignore(q => q.Profile);

        builder.OwnsMany(p => p.Profiles, q =>
        {
            q.WithOwner().HasForeignKey("PersonId");
            q.Property<int>("Id");
            q.HasKey("Id");
            
            q.HasIndex(g => new { g.Phone, FirstName = g.Name, LastName = g.Surname, g.DateOfBirth, g.OrganizationId })
                .IsUnique(); 
        });
    }
}
