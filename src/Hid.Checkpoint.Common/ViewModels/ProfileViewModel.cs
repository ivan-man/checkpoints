namespace Hid.Checkpoint.Common.ViewModels;

public class ProfileViewModel : BaseDomainViewModel<int>
{
    public Guid? ExternalId { get; set; }
    public Guid? ExternalIndividual { get; set; }

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string? Patronymic { get; set; }

    public string? TabN { get; set; }
    public string? Phone { get; set; }
    public string? Email { get; set; }

    public int? PositionId { get; set; }
    public PositionViewModel? Position { get; set; }

    public DateTime? DisabledDate { get; set; }
}
