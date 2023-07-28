using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Hid.Checkpoint.Audit.Services
{
    public interface IChangesDetector
    {
        bool ShouldBeTracked(object e);
        bool MemberShouldBeTracked(Type t, string propertyName);

        Task ReceiveChanges(
            SaveChangesCompletedEventData eventData,
            Type entryType,
            EntityState changeType,
            EntityEntry changedState,
            object originalState);
    }
}
