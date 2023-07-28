namespace Hid.Identity.Common;

public class TokenModel
{
    public string Id { get; set; }
    public string Token { get; set; }
    public DateTime? Expired { get; set; }
}
