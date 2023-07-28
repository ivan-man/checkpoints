using System.ComponentModel.DataAnnotations;

namespace Hid.Checkpoint.Common.Enums
{
    [Flags]
    public enum DaysOfWeekFlags
    {
        None,
        [Display(Name = "понедельник")] Monday = 1 << 0,
        [Display(Name = "вторник")] Tuesday = 1 << 1,
        [Display(Name = "среда")] Wednesday = 1 << 2,
        [Display(Name = "четверг")] Thursday = 1 << 3,
        [Display(Name = "пятница")] Friday = 1 << 4,
        [Display(Name = "суббота")] Saturday = 1 << 5,
        [Display(Name = "воскресенье")] Sunday = 1 << 6,

        [Display(Name = "вся неделя")] FullWeek = Monday | Tuesday | Wednesday | Thursday | Friday | Saturday | Sunday,
        [Display(Name = "рабочие дни")] Weekdays = Monday | Tuesday | Wednesday | Thursday | Friday,
        [Display(Name = "выходные")] Weekend = Saturday | Sunday,
    }
}
