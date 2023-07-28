using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Hid.CheckPoint.Shared.Attributes;
using Hid.CheckPoint.Shared.Domain;
using Hid.Checkpoint.Audit.Abstractions.Attributes;
using Hid.Checkpoint.Audit.Abstractions.Enums;
using Hid.Checkpoint.Common.Enums;

namespace Hid.Checkpoint.Domain.Models;

[AuditedEntity(EntityChangesTypes.All)]
[Metadata("Организация")]
public class Organization : BaseEntity<int>
{
    [Metadata(isHidden: true)] public OrganizationType Type { get; set; }

    [Metadata("Название")] public string Name { get; set; }

    [Metadata("Адрес")] public string? Address { get; set; }

    [Metadata("Описание")] public string? Description { get; set; }

    [Metadata("Договоры", true)] public List<OrganizationContract> Contracts { get; set; } = new();

    [NotMapped]
    public IEnumerable<OrganizationContract> ContractsActual =>
        Contracts?.Where(q =>
            !q.ValidTo.HasValue || q.ValidTo.Value.ToDateTime(TimeOnly.Parse("00:00")) < DateTime.UtcNow)
        ?? Enumerable.Empty<OrganizationContract>();

    #region Internal

    [Metadata("Внешний идентификатор")] public Guid? ExternalId { get; set; }

    [Metadata("Код организации")]
    [MaxLength(32)]
    public string? Code { get; set; }

    [Metadata("ИНН")] [MaxLength(32)] public string? Inn { get; set; }

    [Metadata("КПП")] [MaxLength(32)] public string? Kpp { get; set; }

    [Metadata("ОКПО")] [MaxLength(32)] public string? Okpo { get; set; }

    [Metadata("ОКАТО")] [MaxLength(32)] public string? Okato { get; set; }

    [Metadata("Код ИМНС")] [MaxLength(32)] public string? Imns { get; set; }

    [Metadata("Орган ИМНС")] public string? ImnsName { get; set; }

    [Metadata("ОКОПФ")] [MaxLength(32)] public string? Okopf { get; set; }

    [Metadata("ОКВЕД")] [MaxLength(32)] public string? Okved { get; set; }

    [Metadata("ОКМО")] [MaxLength(32)] public string? Oktmo { get; set; }

    /// <summary>
    /// дата расформирования
    /// </summary>
    [Metadata("Дата расформирования")]
    public DateOnly? DisbandDate { get; set; }

    [Metadata("Подразделения")] public List<Subdivision>? Subdivisions { get; set; }

    #endregion Internal
}
