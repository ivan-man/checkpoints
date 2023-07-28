using Hid.Checkpoint.Common.Enums;
using Hid.Checkpoint.Common.Extensions;
using Hid.CheckPoint.Shared;
using Hid.Identity.Business.Handlers.Roles.CreateIfNotExists;
using Hid.Identity.DataAccess.Ef;
using Hid.Identity.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace Hid.Identity.Business.Handlers.Users.Create;

    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Result<Guid?>>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMediator _mediator;
        private readonly ILogger<CreateUserCommandHandler> _logger;
        private readonly HidIdentityContext _dataContext;

        public CreateUserCommandHandler(
            UserManager<ApplicationUser> userManager,
            HidIdentityContext dataContext,
            ILogger<CreateUserCommandHandler> logger, 
            IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
            _dataContext = dataContext;
            _userManager = userManager;
        }

    public async Task<Result<Guid?>> Handle(
        CreateUserCommand request,
        CancellationToken cancellationToken)
    {
        try
        {
            var user = new ApplicationUser
            {
                UserName = request.UserName!,
                LockoutEnabled = !request.RolesValue.HasFlag(RoleFlags.Administrator),
                PersonId = request.PersonId!.Value,
                ExternalEmployeeId = request.ExternalEmployeeId!,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
            };

            var rolesList = request.RolesValue.GetRolesList();
            foreach (var roleValue in rolesList)
            {
                var checkRoleResult = await _mediator.Send(new CreateRoleIfNotExistsCommand
                {
                    Role = roleValue
                }, cancellationToken);

                if (!checkRoleResult.Success)
                    return Result<Guid?>.Failed(checkRoleResult);

                await _userManager.AddToRoleAsync(user, roleValue.ToString());
            }

            // We use the 'ExternalEmployeeId' like a password, because we don't have registration mechanism 
            var password = !string.IsNullOrWhiteSpace(request.UserSecret)
                ? request.UserSecret
                : request.ExternalEmployeeId;
            
            var result = await _userManager.CreateAsync(user, password);

            if (!result.Succeeded)
                return Result<Guid?>.Failed(result.ToString());

            await _dataContext.SaveChangesAsync(cancellationToken)
                .ConfigureAwait(false);

            return Result<Guid?>.Created(user.Id);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Failed to create user {@Request}", request);
            return Result<Guid?>.Internal("Failed to create user");
        }
    }
}
