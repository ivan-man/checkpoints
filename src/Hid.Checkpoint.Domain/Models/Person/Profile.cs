using System.ComponentModel.DataAnnotations;
using Hid.CheckPoint.Shared.Attributes;
using Hid.CheckPoint.Shared.Domain;
using Hid.Checkpoint.Audit.Abstractions.Attributes;
using Hid.Checkpoint.Audit.Abstractions.Enums;
using Hid.Checkpoint.Common.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Hid.Checkpoint.Domain.Models;

[Owned, AuditedEntity(EntityChangesTypes.All)]
public class Profile : BaseEntity<int>, IPersonName
{
    [Metadata("Дата рождения")] public DateOnly? DateOfBirth { get; set; }

    [MaxLength(64), Metadata("Имя")] public string Name { get; set; }
    [MaxLength(64), Metadata("Фамилия")] public string Surname { get; set; }
    [MaxLength(64), Metadata("Отчество")] public string? Patronymic { get; set; }

    [Metadata("Номер телефона")] public string? Phone { get; set; }
    [Metadata("Электронная почта")] public string? Email { get; set; }

    [Metadata("Id организации")] public int OrganizationId { get; set; }

    [Metadata("Организация")] public Organization Organization { get; set; }

    /// <summary>
    /// Дата смены профиля сотрудника (Ведем историчность)
    /// </summary>
    [Metadata("Дата создания новой версии профиля", IsHidden = true)]
    public DateOnly? DisabledDate { get; set; }


    [Metadata("Id страны")] public int? CountryId { get; set; }
    [Metadata("Страна")] public Country? Country { get; set; }

    [Metadata("Признак сотрудника")] public bool IsEmployee { get; set; }


    #region Employee

    [Metadata("Внешний Id")] public Guid? ExternalId { get; set; }
    [Metadata("Внешний код")] public Guid? ExternalIndividual { get; set; }

    [Metadata("Табельный номер")] public string? TabN { get; set; }

    /// <summary>
    /// код физлица
    /// </summary>
    [MaxLength(256), Metadata("Код физлица")]
    public string? Code { get; set; }

    [Metadata("ИНН"), MaxLength(16)] public string? Inn { get; set; }

    /// <summary>
    /// Дата найма  
    /// </summary>
    [Metadata("Дата найма")]
    public DateOnly? EmploymentDate { get; set; }

    /// <summary>
    /// Дата увольнения
    /// </summary>
    [Metadata("Дата увольнения")]
    public DateOnly? DismissalDate { get; set; }


    /// <summary>
    /// Код должности
    /// </summary>
    [MaxLength(32), Metadata("Код должности")]
    public string? PositionCode { get; set; }

    /// <summary>
    /// Код должности в классифкаторе профессий и должностей
    /// </summary>
    [MaxLength(32), Metadata("Код должности в классифкаторе профессий и должностей")]
    public string? Okpdtr { get; set; }

    /// <summary>
    /// Название должности из классификатора профессий и должностей
    /// </summary>
    [Metadata("Название должности из классификатора профессий и должностей")]
    public string? OkpdtrTitle { get; set; }

    [Metadata("Id позиции")] public int? PositionId { get; set; }
    [Metadata("Позиция")] public Position? Position { get; set; }

    #endregion Employee
}
