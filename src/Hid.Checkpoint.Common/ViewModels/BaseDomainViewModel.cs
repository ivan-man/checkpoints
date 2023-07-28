using System.ComponentModel.DataAnnotations;

namespace Hid.Checkpoint.Common.ViewModels;

public class BaseDomainViewModel<TId> 
{
    [Display(Name = "Создано")] public DateTime Created { get; set; } = DateTime.UtcNow;
    [Display(Name = "Обновлено")] public DateTime? Updated { get; set; }

    [Display(Name = "Удалено")] public bool? Removed { get; set; }
    
    [Key, Display(Name = "Идентификатор")] public TId Id { get; set; }
}
