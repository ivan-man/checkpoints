using Hid.CheckPoint.Shared.Attributes;
using Hid.CheckPoint.Shared.Domain;
using Hid.Checkpoint.Common.Enums;

namespace Hid.Checkpoint.Domain.Models;

public class Device : BaseEntity<int>
{
    [Metadata("Наименование")] public string Title { get; set; }
    [Metadata("Описание")] public string? Description { get; set; }
    [Metadata("Модель")] public string? Model { get; set; }
    [Metadata("Серийный номер")] public string SN { get; set; }
    [Metadata("Количество")] public int Quantity { get; set; } = 1;
    
    [Metadata("Тип материального пропуска")]
    public DevicePassType PassType { get; set; }
    
    /// <summary>
    /// Причина
    /// </summary>
    [Metadata("Причина")]
    public string? Cause { get; set; }

    public int PersonId { get; set; }
    public Person Person { get; set; }
    public List<PassRequest>? PassRequests { get; set; }
}
