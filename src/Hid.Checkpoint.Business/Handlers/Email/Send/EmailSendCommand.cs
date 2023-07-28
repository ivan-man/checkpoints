using Hid.CheckPoint.Shared;
using MediatR;

namespace Hid.Checkpoint.Business.Handlers.Email.Send;

public class EmailSendCommand : IRequest<Result<Guid?>>
{
    public Guid EmailId { get; set; }
    public List<string> To { get; set; }
    public string? Subject { get; set; }
    public string? Body { get; set; }
}
