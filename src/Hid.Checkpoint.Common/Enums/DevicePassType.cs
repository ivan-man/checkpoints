using System.ComponentModel.DataAnnotations;

namespace Hid.Checkpoint.Common.Enums;

[Flags]
public enum DevicePassType
{
    None,
    [Display(Name = "Внос")]
    In = 1 << 0,
    [Display(Name = "Вынос")]
    Out = 1 << 1,
    
    [Display(Name = "Вынос, вынос")]
    InOut = In | Out,
}
