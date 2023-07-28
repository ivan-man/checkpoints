using Newtonsoft.Json;

namespace Hid.Checkpoint.Business.HttpClients.Dpms.Dto;

public class SubdivisionDto
{
    [JsonProperty("uid")]
    public Guid? Uid;

    [JsonProperty("adUid")]
    public Guid? AdUid;

    [JsonProperty("name")]
    public string? Name;

    [JsonProperty("organizationUid")]
    public Guid? OrganizationUid;

    [JsonProperty("organizationName")]
    public string? OrganizationName;

    [JsonProperty("mainUnitUid")]
    public Guid? MainUnitUid;

    [JsonProperty("mainUnitName")]
    public string? MainUnitName;

    [JsonProperty("modifiedAt")]
    public DateTime? ModifiedAt;
}
