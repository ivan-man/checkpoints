namespace Hid.Checkpoint.Common.ViewModels;

public class CountryViewModel : BaseDomainViewModel<int>
{
    public string? Name { get; set; }
    public string? NameRu { get; set; }
    public string? Iso2 { get; set; }
    public string? Iso3 { get; set; }
    public int? Number { get; set; }
}
