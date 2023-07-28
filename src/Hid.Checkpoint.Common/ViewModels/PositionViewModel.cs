namespace Hid.Checkpoint.Common.ViewModels;

public class PositionViewModel : BaseDomainViewModel<int>
{
    public string Title { get; set; }

    /// <summary>
    /// Код должности
    /// </summary>
    public string? PositionCode { get; set; }

    /// <summary>
    /// Код должности в классифкаторе профессий и должностей
    /// </summary>
    public string? Okpdtr { get; set; }

    /// <summary>
    /// Название должности из классификатора профессий и должностей
    /// </summary>
    public string? OkpdtrTitle { get; set; }
    
    public int OrganizationId { get; set; }
    public OrganizationViewModel? Organization { get; set; }

    public int? SubdivisionId { get; set; }
    public SubdivisionViewModel? Subdivision { get; set; }
}
