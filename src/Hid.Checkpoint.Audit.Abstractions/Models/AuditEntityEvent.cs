using System.Collections.Generic;
using Hid.Checkpoint.Audit.Abstractions.Enums;

namespace Hid.Checkpoint.Audit.Abstractions.Models
{
    public class AuditEntityEvent
    {
        public int? PersonId { get; set; }
        public int? ProfileId { get; set; }
        public string UserInfo { get; set; }

        public string EntityId { get; set; }
        public string DisplayName { get; set; }
        public string EntityType { get; set; }
        public string EntityFullType { get; set; }
        public ChangesType? ChangesType { get; set; }
        public ChangesInitiatorType InitiatorType { get; set; } = ChangesInitiatorType.Unknown;

        public List<AuditMemberEvent> MembersEvents { get; set; }
    }
}
