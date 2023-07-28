using Hid.CheckPoint.Shared.Attributes;
using Hid.CheckPoint.Shared.Domain;

namespace Hid.Checkpoint.Domain.Models;

public class Country : BaseEntity<int>
{
    [Metadata("Международное название")] public string Name { get; set; }
    [Metadata("Название")] public string NameRu { get; set; }
    [Metadata(true)] public string NormalizedName { get; set; }
    [Metadata(true)] public string NormalizedNameRu { get; set; }
    [Metadata("Код ISO2")] public string Iso2 { get; set; }
    [Metadata("Код ISO3")] public string Iso3 { get; set; }
    [Metadata("Номер")] public int Number { get; set; }
}

