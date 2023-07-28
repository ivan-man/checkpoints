using System.ServiceModel;
using Hid.CheckPoint.Shared;
using Hid.Identity.Common.Contracts;

namespace Hid.Identity.Client;

/// <summary>
/// It must be placed not here.
/// This service is designed for API or grpc,
/// but we use it as a built-in object.
/// </summary>
[ServiceContract]
public interface IIdentityService
{
    [OperationContract]
    ValueTask<Result> ValidateTokenAsync(ValidateTokenContract request, CancellationToken token = default);

    [OperationContract]
    ValueTask<Result<Guid?>> CreateUserAsync(CreateUserContract request, CancellationToken token = default);

    [OperationContract]
    ValueTask<Result<TokenContract>> LoginAsync(LoginContract request, CancellationToken token = default);

    [OperationContract]
    ValueTask<Result<UserContract?>> GetUserAsync(GetUserContract request, CancellationToken token = default);

    [OperationContract]
    ValueTask<Result> AddUserRoleAsync(AddUserRoleContract request, CancellationToken token = default);

    [OperationContract]
    ValueTask<Result> RemoveUserRoleAsync(RemoveUserRoleContract request, CancellationToken token = default);
}
