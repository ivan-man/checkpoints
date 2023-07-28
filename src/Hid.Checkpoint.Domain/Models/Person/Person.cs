using System.ComponentModel.DataAnnotations.Schema;
using Hid.CheckPoint.Shared.Attributes;
using Hid.CheckPoint.Shared.Domain;
using Hid.Checkpoint.Audit.Abstractions.Attributes;
using Hid.Checkpoint.Audit.Abstractions.Enums;

namespace Hid.Checkpoint.Domain.Models;

[AuditedEntity(EntityChangesTypes.All)]
public class Person : BaseEntity<int>
{
    /// <summary>
    /// It is only view property.
    /// You can't filter by it, you wil get ef translation error.
    /// </summary>
    [NotMapped, Metadata(isHidden: true)]
    public Profile? Profile 
        => Removed ? null : Profiles.FirstOrDefault(q => q.DisabledDate == null && !q.Removed);
    
    public Guid UserId { get; set; }

    [Metadata(isHidden: true)] public List<Profile> Profiles { get; set; } = new();
}

// public class Employee : Person
// {
// }
//
// public class Guest : Person
// {
//     //ToDo
//     [NotMapped]
//     public List<DocumentCopy>? Documents { get; set; }
// }
