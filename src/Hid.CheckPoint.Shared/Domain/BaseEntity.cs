using System.ComponentModel.DataAnnotations;
using Hid.CheckPoint.Shared.Attributes;

namespace Hid.CheckPoint.Shared.Domain;

public abstract class BaseEntity : IBaseEntity
{
    [Metadata("Создано")]
    public DateTime Created { get; set; } = DateTime.UtcNow;

    [Metadata("Обновлено")]
    public DateTime? Updated { get; set; }

    [Metadata("Удалено")]
    public bool Removed { get; set; }
}

public abstract class BaseEntity<TId> : BaseEntity, IBaseEntity<TId>
{
    [Key, Display(Name = "ID"), Metadata]
    public TId Id { get; set; }
}

public interface IBaseEntity
{
    [Metadata("Создано")]
    public DateTime Created { get; set; }

    [Metadata("Обновлено")]
    public DateTime? Updated { get; set; }

    [Metadata("Удалено")]
    public bool Removed { get; set; }
}

public interface IBaseEntity<TId> : IBaseEntity
{
    [Key]
    TId Id { get; set; }
}
