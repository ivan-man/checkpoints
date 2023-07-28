using System.ComponentModel.DataAnnotations;
using Hid.CheckPoint.Shared.Domain;
using Hid.Checkpoint.Audit.Abstractions.Attributes;
using Hid.Checkpoint.Audit.Abstractions.Enums;
using Hid.CheckPoint.Shared.Attributes;

namespace Hid.Checkpoint.Domain.Models;

[AuditedEntity(EntityChangesTypes.All)]
public class Subdivision : BaseEntity<int>
{
    [Metadata("Название")] public string Title { get; set; }

    [Metadata("Внешний ID")] public Guid? ExternalId { get; set; }

    [Metadata("Код подразделения"), MaxLength(32)]
    public string? Code { get; set; }

    [Metadata("КПП"), MaxLength(32)] public string? Kpp { get; set; }
    [Metadata("ОКПО"), MaxLength(32)] public string? Okpo { get; set; }
    [Metadata("ОКАТО"), MaxLength(32)] public string? Okato { get; set; }

    [Metadata("Адрес")] public string? Address { get; set; }

    /// <summary>
    /// Идентификатор руководителя
    /// </summary>
    [Metadata("ID руководителя")]
    public int ManagerId { get; set; }

    /// <summary>
    /// руководитель
    /// </summary>
    [Metadata("Руководитель")]
    public Person Manager { get; set; }

    /// <summary>
    /// Дата расформирования
    /// </summary>
    [Metadata("Дата расформирования")]
    public DateOnly? DisbandDate { get; set; }

    [Metadata("ID организации")] public int OrganizationId { get; set; }
    [Metadata("Организация")] public Organization? Organization { get; set; }

    [Metadata("ID родительского подразделения")]
    public int? ParentSubdivisionId { get; set; }

    /// <summary>
    /// Родительское подразделение
    /// </summary>
    [Metadata("Родительское подразделение")]
    public Subdivision? ParentSubdivision { get; set; }

    [Metadata("Список сотрудников")] public List<Person>? Employees { get; set; }
}
