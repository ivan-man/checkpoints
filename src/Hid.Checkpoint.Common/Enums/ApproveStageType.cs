using System.ComponentModel.DataAnnotations;

namespace Hid.Checkpoint.Common.Enums
{
    /// <summary>
    /// Тип стадии
    /// </summary>
    public enum ApproveStageType
    {
        [Display(Name = "-")] None = 0,
        [Display(Name = "Подразделение")] SubDivisionApprove = 1,

        [Display(Name = "Отдел по спецработе")]
        SpecialWorkDepartment = 2,

        [Display(Name = "Уровень доступа")] ByAccessLevel = 3,
        [Display(Name = "По рабочему месту")] ByWorkplace = 4,

        [Display(Name = "Мед. работник (пром. безопасность)")]
        IndustrialSecurity = 5,

        [Display(Name = "Дополнительная")] Additional = 6,
        [Display(Name = "БКЗ")] GreatConcertHall = 7,
    }
}
