using System.Linq;

namespace Hid.Checkpoint.Audit.Abstractions.Models
{
    public class TrackingInfo
    {
        public bool IsTracked { get; }
        public string DisplayName { get; set; }
        public string TypeName { get; set; }
        public string FullTypeName { get; set; }
        public AuditPropertyInfo[] PropertyInfos { get; set; } = Enumerable.Empty<AuditPropertyInfo>().ToArray();

        public TrackingInfo(bool isTracked)
        {
            IsTracked = isTracked;
        }
    }
}
