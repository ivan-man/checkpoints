using System.Reflection;
using Hid.CheckPoint.Shared.Domain;
using Hid.Checkpoint.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Hid.Checkpoint.DataAccess.Ef.Seed;

public static class Seed
{
    public static ModelBuilder SeedData(this ModelBuilder modelBuilder)
    {
        modelBuilder.SeedModelPropertiesData<PassRequest, RequestProperty>();
        modelBuilder.SeedModelPropertiesData<Person, PersonProperty>();
        modelBuilder.SeedModelPropertiesData<Profile, ProfileProperty>();
        modelBuilder.SeedModelPropertiesData<Organization, OrganizationProperty>();
        modelBuilder.SeedCountries();
        modelBuilder.SeedPassRequestTypes();

        return modelBuilder;
    }

    private static ModelBuilder SeedModelPropertiesData<TModel, TPropertyModel>(this ModelBuilder modelBuilder)
        where TModel : BaseEntity
        where TPropertyModel : CustomizableProperty, new()
    {
        var passRequestType = typeof(TModel);
        var properties = passRequestType.GetProperties(BindingFlags.Public | BindingFlags.Instance);

        var models = new List<TPropertyModel>();

        foreach (var property in properties.OrderBy(q => q.Name))
        {
            var requestProperty = CustomizableProperty.CreateModel<TModel, TPropertyModel>(property);

            requestProperty.Created = new DateTime(1999, 01, 01);
            requestProperty.Updated = new DateTime(1999, 01, 01);

            models.Add(requestProperty);
        }

        modelBuilder.Entity<TPropertyModel>().HasData(models);

        return modelBuilder;
    }

    private static ModelBuilder SeedPassRequestTypes(this ModelBuilder modelBuilder)
    {
        var id = 0;

        var types = new List<PassRequestType>()
        {
            new PassRequestType()
            {
                Id = ++id,
                Created = new DateTime(1999, 1, 1),
                Updated = new DateTime(1999, 1, 1),
                DisplayName = "Постоянный пропуск",
                Description = "Постоянный пропуск",
                Enabled = true,
                Removed = false,
                IsCheckpointIssue = false,
                ValidityPeriod = null,
                MaxValidityPeriod = null,
            },
            new PassRequestType()
            {
                Id = ++id,
                Created = new DateTime(1999, 1, 1),
                Updated = new DateTime(1999, 1, 1),
                DisplayName = "Разовый пропуск",
                Description = "Разовый пропуск",
                Enabled = true,
                Removed = false,
                IsCheckpointIssue = false,
                ValidityPeriod = TimeSpan.FromDays(1),
                MaxValidityPeriod = TimeSpan.FromDays(1),
            },
            new PassRequestType()
            {
                Id = ++id,
                Created = new DateTime(1999, 1, 1),
                Updated = new DateTime(1999, 1, 1),
                DisplayName = "Иностранный посетитель",
                Description = "Иностранный посетитель",
                Enabled = true,
                Removed = false,
                IsCheckpointIssue = false,
                ValidityPeriod = null,
                MaxValidityPeriod = null,
            },
            new PassRequestType()
            {
                Id = ++id,
                Created = new DateTime(1999, 1, 1),
                Updated = new DateTime(1999, 1, 1),
                DisplayName = "Единый пропуск ",
                Description = "Единый пропуск",
                Enabled = true,
                Removed = false,
                IsCheckpointIssue = false,
                ValidityPeriod = null,
                MaxValidityPeriod = TimeSpan.FromDays(180),
            },
            new PassRequestType()
            {
                Id = ++id,
                Created = new DateTime(1999, 1, 1),
                Updated = new DateTime(1999, 1, 1),
                DisplayName = "Списочный пропуск",
                Description = "Списочный пропуск",
                Enabled = true,
                Removed = false,
                ValidityPeriod = null,
                IsCheckpointIssue = true,
                MaxValidityPeriod = TimeSpan.FromDays(30),
            },
            new PassRequestType()
            {
                Id = ++id,
                Created = new DateTime(1999, 1, 1),
                Updated = new DateTime(1999, 1, 1),
                DisplayName = "Выход в выходной день",
                Description = "Выход в выходной день",
                Enabled = true,
                Removed = false,
                IsCheckpointIssue = true,
                ValidityPeriod = null,
                MaxValidityPeriod = TimeSpan.FromDays(1),
            },
            new PassRequestType()
            {
                Id = ++id,
                Created = new DateTime(1999, 1, 1),
                Updated = new DateTime(1999, 1, 1),
                DisplayName = "Материальный пропуск",
                Description = "Материальный пропуск",
                Enabled = true,
                Removed = false,
                IsCheckpointIssue = true,
                ValidityPeriod = null,
                MaxValidityPeriod = null,
            },
            new PassRequestType()
            {
                Id = ++id,
                Created = new DateTime(1999, 1, 1),
                Updated = new DateTime(1999, 1, 1),
                DisplayName = "Пропуск посетителя ",
                Description = "Пропуск посетителя ",
                Enabled = true,
                Removed = false,
                IsCheckpointIssue = false,
                ValidityPeriod = null,
                MaxValidityPeriod = TimeSpan.FromDays(90),
            },
        };
        
        modelBuilder.Entity<PassRequestType>().HasData(types);
        
        return modelBuilder;
    }
    
    private static ModelBuilder SeedCountries(this ModelBuilder modelBuilder)
    {
        var rawData = Resources.ResourcesAccess.Countries;
        var inputLines = rawData.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);

        var id = 0;
        var models = new List<Country>();
        
        foreach (var line in inputLines)
        {
            var parts = line.Split('\t');
            if (parts.Length != 5)
            {
                Console.WriteLine("Incorrect line format: " + line);
                continue;
            }

            var country = new Country
            {
                Id = ++id,
                Name = parts[0],
                NameRu = parts[1],
                NormalizedName = parts[0].ToUpperInvariant(),
                NormalizedNameRu = parts[1].ToUpperInvariant(),
                Iso2 = parts[2],
                Iso3 = parts[3],
                Number = int.Parse(parts[4]),
                Created = new DateTime(1999, 1, 1),
                Updated = new DateTime(1999, 1, 1),
            };

            models.Add(country);
        }
        
        modelBuilder.Entity<Country>().HasData(models);

        return modelBuilder;
    }
    
    
}
