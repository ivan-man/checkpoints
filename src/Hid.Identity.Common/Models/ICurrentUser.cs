
namespace Hid.Identity.Common.Models;

public interface ICurrentUser : IUser
{
    public string Login { get; }
}
