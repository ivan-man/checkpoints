using Hid.CheckPoint.Shared;
using MediatR;

namespace Hid.Identity.Business.Handlers.TokenValidation;

public class ValidateTokenCommand : IRequest<Result>
{
    public string Token { get; set; }
}
