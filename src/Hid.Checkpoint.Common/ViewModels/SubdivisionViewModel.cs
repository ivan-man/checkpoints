namespace Hid.Checkpoint.Common.ViewModels;

public class SubdivisionViewModel : BaseDomainViewModel<int>
{
    public string Title { get; set; }

    public Guid? ExternalId { get; set; }
    public string? Code { get; set; }
    public string? Kpp { get; set; }
    public string? Okpo { get; set; }
    public string? Okato { get; set; }
    
    public string? Address { get; set; }
    
    /// <summary>
    /// Идентификатор руководителя
    /// </summary>
    public int ManagerId { get; set; }
    
    /// <summary>
    /// руководитель
    /// </summary>
    public EmployeeViewModel? Manager { get; set; }

    /// <summary>
    /// Дата расформирования
    /// </summary>
    public DateOnly? DisbandDate { get; set; }

    public int OrganizationId { get; set; }
    public OrganizationViewModel? Organization { get; set; }

    public int? ParentSubdivisionId { get; set; }
}
