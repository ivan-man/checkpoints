using System.ComponentModel.DataAnnotations;

namespace Hid.Checkpoint.Common.Enums
{
    public enum OrganizationType
    {
        [Display(Name = "-")] None,
        [Display(Name = "Внутренняя")] Internal,
        [Display(Name = "Сторонняя")] External,
    }
}
