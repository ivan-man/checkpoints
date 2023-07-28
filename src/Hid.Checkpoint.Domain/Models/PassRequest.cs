using Hid.CheckPoint.Shared.Attributes;
using Hid.CheckPoint.Shared.Domain;
using Hid.Checkpoint.Audit.Abstractions.Attributes;
using Hid.Checkpoint.Audit.Abstractions.Enums;

namespace Hid.Checkpoint.Domain.Models;

[Metadata("Заявка")]
[AuditedEntity(EntityChangesTypes.All)]
public class PassRequest : BaseEntity<int>
{
    /// <summary>
    /// Автор заявки
    /// </summary>
    [Metadata("Автор", IgnorePermissions = true)]
    public Person Author { get; set; }

    /// <summary>
    /// Список гостей
    /// </summary>
    [Metadata("Посетители", IgnorePermissions = true)]
    public List<Person> Guests { get; set; }

    [Metadata("Id типа запроса", IgnorePermissions = true)]
    public int RequestTypeId { get; set; }

    [Metadata("Тип запроса", IgnorePermissions = true)]
    public PassRequestType RequestType { get; set; }

    [Metadata("Дата запроса")] public DateTime Date { get; set; }
    [Metadata("Действует до")] public DateTime ExpiredDate { get; set; }
    [Metadata("Цель визита")] public string? VisitPurpose { get; set; }
    [Metadata("Дополнительно")] public string? Additional { get; set; }

    [Metadata] public List<ApproveChain> ApproveChains { get; set; }

    [Metadata("Устройства", IgnorePermissions = true)]
    public List<Device>? Devices { get; set; }

    [Metadata(true)] public List<GuestContractRelation>? GuestContractRelations { get; set; }
}
