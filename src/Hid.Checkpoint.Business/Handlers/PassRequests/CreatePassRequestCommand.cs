using Hid.CheckPoint.Shared;
using MediatR;

namespace Hid.Checkpoint.Business.Handlers.PassRequests;

public class CreatePassRequestCommand : IRequest<Result>
{
    public int TypeId { get; set; }

}
