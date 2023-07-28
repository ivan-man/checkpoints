namespace Hid.Checkpoint.Common.ViewModels;

public class EmployeeViewModel : BaseDomainViewModel<int>
{
    public Guid? ExternalId { get; set; }
    public string? Code { get; set; }
    public string? Inn { get; set; }

    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Patronymic { get; set; }

    public string? TabN { get; set; }
    public string? Phone { get; set; }
    public string? Email { get; set; }

    public ProfileViewModel? CurrentProfile { get; set; }
    
    public List<ProfileViewModel>? Profiles { get; set; }
    
    /// <summary>
    /// Дата найма  
    /// </summary>
    public DateOnly? EmploymentDate { get; set; }

    /// <summary>
    /// Дата увоьнения
    /// </summary>
    public DateOnly? DismissalDate { get; set; }
}
