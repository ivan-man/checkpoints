using Hid.CheckPoint.Shared.Domain;

namespace Hid.Identity.Domain.Models;

public class RefreshToken : BaseEntity<Guid>
{
    public string Token { get; set; }
    public string JwtId { get; set; }
    public DateTime AddedDate { get; set; }
    public DateTime? ExpiryDate { get; set; }

    public Guid UserId { get; set; }
    public ApplicationUser User { get; set; }
}
