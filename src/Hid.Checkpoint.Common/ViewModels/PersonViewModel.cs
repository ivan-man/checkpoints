namespace Hid.Checkpoint.Common.ViewModels;

public class PersonViewModel  : BaseDomainViewModel<int>
{
    public DateOnly? DateOfBirth { get; set; }

    public string Name { get; set; }
    public string Surname { get; set; }
    public string? Patronymic { get; set; }

    public string? Phone { get; set; }
    public string? Email { get; set; }

    public int OrganizationId { get; set; }

    public OrganizationViewModel? Organization { get; set; }

    /// <summary>
    /// Дата смены профиля сотрудника (Ведем историчность)
    /// </summary>
    public DateOnly? DisabledDate { get; set; }


    public int? CountryId { get; set; }
    public CountryViewModel? Country { get; set; }

    public bool IsEmployee { get; set; }

    #region Employee

    public Guid? ExternalId { get; set; }
    public Guid? ExternalIndividual { get; set; }

    public string? TabN { get; set; }

    /// <summary>
    /// код физлица
    /// </summary>
    public string? Code { get; set; }

    public string? Inn { get; set; }

    /// <summary>
    /// Дата найма  
    /// </summary>
    public DateOnly? EmploymentDate { get; set; }

    /// <summary>
    /// Дата увольнения
    /// </summary>
    public DateOnly? DismissalDate { get; set; }


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

    public int? PositionId { get; set; }
    public PositionViewModel? Position { get; set; }

    #endregion Employee
}
