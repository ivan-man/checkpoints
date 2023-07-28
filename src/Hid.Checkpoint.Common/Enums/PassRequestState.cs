using System.ComponentModel.DataAnnotations;

namespace Hid.Checkpoint.Common.Enums
{
    public enum PassRequestState
    {
        [Display(Name = "Черновик")] Draft,
        // Clearance = 1,

        [Display(Name = "Ожидает подверждения")]
        NeedApprove = 2,
        [Display(Name = "Активен")] Active = 3,
        // [Display(Name = "Выдан")] Passed = 4,
        [Display(Name = "Утерян")] Lost = 5,
        [Display(Name = "Отклонен")] Declined = 6,
        [Display(Name = "Истёк")] Expired = 7,
    }
}
