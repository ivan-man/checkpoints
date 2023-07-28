using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace Hid.Checkpoint.Common.Enums
{
    [Flags]
    public enum RoleFlags : ulong
    {
        [Display(Name = "-")] None = 0,
        [Display(Name = "Пользователь")] User = 1 << 0,
        [Display(Name = "Система")] System = 1 << 1 | User,
        [Display(Name = "Администратор")] Administrator = 1 << 2 | User,
        [Display(Name = "Инициатор")] Initiator = 1 << 3 | User,
        [Display(Name = "Аудитор")] Auditor = 1 << 4 | User,

        [Display(Name = "Подтверждающий доступ для согласования заявок")]
        ApproversConfirmation = 1 << 5 | User,

        [Display(Name = "Подтверждающий доступ для согласования заявок на выход в выходные дни")]
        ApproversWeekendConfirmation = 1 << 6 | User,

        [Display(Name = "Согласующий по стадии")]
        ApproverStage = 1 << 7 | User,

        [Display(Name = "Согласующий по подразделению")]
        ApproverSubdivision = 1 << 8 | User,

        [Display(Name = "Согласующий заявки на выход в выходные")]
        ApproverWeekend = 1 << 9 | User,
    }
}
