using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Hid.Checkpoint.Audit.Abstractions.Models;

namespace Hid.Checkpoint.Audit.Abstractions.Interfaces
{
    public interface IStorageService : IDisposable
    {
        Task AddAsync(AuditEntityEvent entityEvent, CancellationToken cancellationToken = default);
        Task AddRangeAsync(IEnumerable<AuditEntityEvent> events, CancellationToken cancellationToken = default);
    }
}
