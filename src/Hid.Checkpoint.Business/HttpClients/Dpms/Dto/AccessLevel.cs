using Hid.Checkpoint.Domain.Models;
using Newtonsoft.Json;

namespace Hid.Checkpoint.Business.HttpClients.Dpms.Dto;

public class AccessLevel
{
    [JsonProperty("uid")]
    public Guid? Uid;

    [JsonProperty("name")]
    public string? Name;

    [JsonProperty("description")]
    public string? Description;

    [JsonProperty("accessPoints")]
    public List<AccessPoint>? AccessPoints;

    [JsonProperty("modifiedAt")]
    public DateTime? ModifiedAt;
}
