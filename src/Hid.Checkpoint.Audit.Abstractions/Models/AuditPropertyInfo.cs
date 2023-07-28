using System.Reflection;

namespace Hid.Checkpoint.Audit.Abstractions.Models
{
    public class AuditPropertyInfo
    {
        public string DisplayName { get; set; }
        public PropertyInfo PropertyInfo { get; private set; }        

        public AuditPropertyInfo(PropertyInfo propertyInfo)
        {
            PropertyInfo = propertyInfo;
        }
    }
}
