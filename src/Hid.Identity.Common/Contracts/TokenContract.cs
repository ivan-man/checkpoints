using System.Runtime.Serialization;

namespace Hid.Identity.Common.Contracts;

[DataContract]
public class TokenContract
{
    [DataMember(Order = 1)] public string AccessToken { get; set; }
    [DataMember(Order = 2)] public DateTime? Expired { get; set; }
    [DataMember(Order = 3)] public string Refresh { get; set; }
}
