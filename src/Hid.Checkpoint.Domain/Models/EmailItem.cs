using Hid.CheckPoint.Shared.Attributes;
using Hid.CheckPoint.Shared.Domain;

namespace Hid.Checkpoint.Domain.Models;

public class EmailItem : BaseEntity<int>
{
    [Metadata("UUID")] public Guid EmailId { get; set; }
    [Metadata("Отправлено")] public bool Sent { get; set; }
    [Metadata("Кому")] public string To { get; set; }
    [Metadata("Тема")] public string? Subject { get; set; }
    [Metadata("Тело письма")] public string? Body { get; set; }

    [Metadata("Ошибка")] public string? ErrorMessage { get; set; }
}
