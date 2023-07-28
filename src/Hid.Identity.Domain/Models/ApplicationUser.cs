using Microsoft.AspNetCore.Identity;

namespace Hid.Identity.Domain.Models;

public class ApplicationUser : IdentityUser<Guid>
{
    public int PersonId { get; set; }
    public string ExternalEmployeeId { get; set; }
}
