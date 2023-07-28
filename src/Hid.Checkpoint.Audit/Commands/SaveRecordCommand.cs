using Hid.Checkpoint.Audit.Models;
using Hid.CheckPoint.Shared;
using MediatR;

namespace Hid.Checkpoint.Audit.Commands;

public class SaveRecordCommand : IRequest<Result>
{
    public AuditEntityRecordViewModel AuditEntity { get; set; }
}
