using System.Threading.Channels;
using Hid.Checkpoint.Audit.Abstractions.Interfaces;
using Hid.Checkpoint.Audit.Abstractions.Models;
using Hid.Checkpoint.Audit.Commands;
using Hid.Checkpoint.Audit.Models;
using Mapster;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Hid.Checkpoint.Audit.Services;

internal class StorageService : IStorageService
{
    private bool _isReading;

    private readonly Channel<AuditEntityEvent> _channel = Channel.CreateUnbounded<AuditEntityEvent>();
    private readonly ChannelWriter<AuditEntityEvent> _writer;
    private readonly ChannelReader<AuditEntityEvent> _reader;

    private readonly IMediator _mediator;
    private readonly ILogger<StorageService> _logger;

    public StorageService(IMediator mediator, ILogger<StorageService> logger)
    {
        _mediator = mediator;
        _logger = logger;

        _reader = _channel.Reader;
        _writer = _channel.Writer;
    }

    public async Task AddRangeAsync(IEnumerable<AuditEntityEvent> events, CancellationToken cancellationToken = default)
    {
        foreach (var entityEvent in events)
        {
            await AddAsync(entityEvent, cancellationToken);
        }
    }

    public async Task AddAsync(AuditEntityEvent entityEvent, CancellationToken cancellationToken = default)
    {
        if (!_writer.TryWrite(entityEvent))
        {
            await _writer.WriteAsync(entityEvent, cancellationToken);
        }

        await StorageEvents(cancellationToken);
    }

    private async ValueTask StorageEvents(CancellationToken cancellationToken = default)
    {
        if (cancellationToken.IsCancellationRequested)
        {
            Dispose();
            return;
        }

        if (_isReading)
            return;

        try
        {
            var counter = 0;
            _isReading = true;

            while (_isReading && await _reader.WaitToReadAsync(cancellationToken))
            {
                var auditEvent = await _reader.ReadAsync(cancellationToken);
                var auditEntity = auditEvent.Adapt<AuditEntityRecordViewModel>();

                var saveResponse = await _mediator.Send(
                    new SaveRecordCommand { AuditEntity = auditEntity },
                    cancellationToken);

                if (++counter < 25)
                    continue;

                counter = 0;
            }
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Failed to store audit events");
        }
        finally
        {
            _isReading = false;
        }
    }

    public void Dispose()
    {
        _isReading = false;
        _writer.TryComplete();
    }
}
