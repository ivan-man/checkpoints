using Hid.Checkpoint.Audit.DataAccess;
using Hid.Checkpoint.Audit.DataAccess.Models;
using Hid.CheckPoint.Shared;
using Mapster;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Hid.Checkpoint.Audit.Commands;

public class SaveRecordCommandHandler : IRequestHandler<SaveRecordCommand, Result>
{
    private readonly AuditContext _db;
    private readonly ILogger<SaveRecordCommandHandler> _logger;

    public SaveRecordCommandHandler(AuditContext db, ILogger<SaveRecordCommandHandler> logger)
    {
        _db = db;
        _logger = logger;
    }

    public async Task<Result> Handle(SaveRecordCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var record = request.AuditEntity?.Adapt<AuditEntityRecord>();
            if (record == null)
            {
                _logger.LogError("Invalid {@Request}", request);
                return Result.Bad("Invalid request");
            }
            
            _db.AuditRecords.Add(record);
            await _db.SaveChangesAsync(cancellationToken);

            return Result.Created();
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Failed to save record by {@Request}", request);
            return Result.Internal("Failed to save record");
        }
    }
}
