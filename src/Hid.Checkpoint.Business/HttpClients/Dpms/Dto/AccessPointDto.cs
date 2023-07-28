using Newtonsoft.Json;

namespace Hid.Checkpoint.Business.HttpClients.Dpms.Dto;

public class AccessPointDto
{
    [JsonProperty("uid")]
    public Guid? Uid;

    [JsonProperty("name")]
    public string? Name;
}
