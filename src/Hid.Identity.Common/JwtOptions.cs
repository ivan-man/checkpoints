namespace Hid.Identity.Common;

public class JwtOptions
{
    public string? Secret { get; set; }

    /// <summary>
    /// It must by password,
    /// but we have not registration flow
    /// </summary>
    public string UserSecret { get; set; } = string.Empty;
    public int AccessTtl { get; set; } = 5;
    public int TempTtl { get; set; } = 1;
    public int RefreshTtl { get; set; } = 60 * 24 * 7;
}
