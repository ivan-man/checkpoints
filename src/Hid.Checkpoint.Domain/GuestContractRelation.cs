using Hid.Checkpoint.Domain.Models;
using Hid.CheckPoint.Shared.Domain;

namespace Hid.Checkpoint.Domain;

public class GuestContractRelation : BaseEntity<int>
{
    public int? OrganizationContractId { get; set; }
    public OrganizationContract? OrganizationContract { get; set; }
    
    public int PassRequestId { get; set; }
    public PassRequest? PassRequest { get; set; }
    
    public int PersonId { get; set; }
    public Person? Person { get; set; }
}
