using Newtonsoft.Json;

namespace Hid.Checkpoint.Business.HttpClients.Dpms.Dto;

public class EmployeeDto
{
    [JsonProperty("uid")]
    public Guid? Uid;

    [JsonProperty("adUid")]
    public Guid? AdUid;

    [JsonProperty("name")]
    public string? Name;

    [JsonProperty("surname")]
    public string? Surname;

    [JsonProperty("patronymic")]
    public string? Patronymic;

    [JsonProperty("organizationUid")]
    public string? OrganizationUid;

    [JsonProperty("unitUid")]
    public Guid? UnitUid;

    [JsonProperty("unitName")]
    public string? UnitName;

    [JsonProperty("positionUid")]
    public Guid? PositionUid;

    [JsonProperty("positionName")]
    public string? PositionName;

    [JsonProperty("phone")]
    public string? Phone;

    [JsonProperty("modifiedAt")]
    public DateTime? ModifiedAt;
}
