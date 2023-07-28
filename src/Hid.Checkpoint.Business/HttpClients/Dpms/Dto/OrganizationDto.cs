using Newtonsoft.Json;

namespace Hid.Checkpoint.Business.HttpClients.Dpms.Dto;

public class OrganizationDto
{
    [JsonProperty("uid")]
    public Guid? Uid;

    [JsonProperty("adUid")]
    public Guid? AdUid;

    [JsonProperty("name")]
    public string? Name;

    [JsonProperty("mainOrganizationUid")]
    public Guid? MainOrganizationUid;

    [JsonProperty("mainOrganizationName")]
    public string? MainOrganizationName;

    [JsonProperty("modifiedAt")]
    public DateTime? ModifiedAt;
}
