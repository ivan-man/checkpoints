using System.Runtime.Serialization;

namespace Hid.Identity.Common.Contracts;

[DataContract]
public class LoginContract
{
     [DataMember(Order = 1)] public Guid? UserId { get; set; }
     [DataMember(Order = 2)] public string? SystemName { get; set; }
     [DataMember(Order = 3)] public string? ExternalEmployeeId { get; set; }
}
