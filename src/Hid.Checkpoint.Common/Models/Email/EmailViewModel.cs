namespace Hid.Checkpoint.Common.Models.Email;

public class EmailViewModel
{
    public Guid EmailId { get; set; }
    public List<string> To { get; set; }
    public string? Subject { get; set; }
    public string? Body { get; set; }
}
