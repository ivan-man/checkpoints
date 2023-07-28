using Hid.Checkpoint.Domain.Models;

namespace Hid.Checkpoint.DataAccess.Ef.Repositories.Implementations;

internal class EmailsRepository : BaseRepositoryIdentity<CheckPointsContext, EmailItem, int>, IEmailsRepository
{
    public EmailsRepository(CheckPointsContext context) : base(context)
    {
    }
}
