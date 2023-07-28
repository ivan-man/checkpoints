namespace Hid.Checkpoint.Business.Handlers.Persons.Create;

public class CreatePersonCommand
{
    public DateOnly DateOfBirth { get; set; }
    
    public string Name { get; set; }
    public string Surname { get; set; }
    public string? Patronymic { get; set; }
    
    public string? Phone { get; set; }
    public string? Email { get; set; }
    public string? Inn { get; set; }
    
    public int OrganizationId { get; set; }
    public int? CountryId { get; set; }
    public bool IsEmployee { get; set; }
    
    #region Employee
    
    public string? TabN { get; set; }
    
    public Guid? ExternalId { get; set; }
    
    public Guid? ExternalIndividual { get; set; }
    public DateOnly? EmploymentDate { get; set; }
    
    public string? PositionCode { get; set; }
    public string? Okpdtr { get; set; }
    public string? OkpdtrTitle { get; set; }
    
    public int? PositionId { get; set; }
    
    #endregion Employee
}
