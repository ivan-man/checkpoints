using System.ComponentModel.DataAnnotations;

namespace Hid.Checkpoint.Common.Enums
{
    public enum ApproveState
    {
        [Display(Name = "-")] None,
        [Display(Name = "Ожидание")] Waiting = 1,
        [Display(Name = "На согласовании")] NeedApprove = 2,
        [Display(Name = "Согласовано")] Approved = 3,
        [Display(Name = "Отклонено")] Declined = 4,
    }
}
