using System.ComponentModel.DataAnnotations;

namespace Silicon_MVC.ViewModels.Account;

public class PassFormViewModel
{
    public string UserId { get; set; } = null!;

    [Display(Name = "Current password", Prompt = "Your current password", Order = 1)]
    [DataType(DataType.Password)]
    [Required(ErrorMessage = "Password is required")]

    public string CurrentPassword { get; set; } = null!;

    [Display(Name = "New password", Prompt = "Your new password", Order = 2)]
    [DataType(DataType.Password)]
    [Required(ErrorMessage = "Password is required")]

    public string NewPassword { get; set; } = null!;

    [Display(Name = "Confirm new password", Prompt = "Confirm your new password", Order = 3)]
    [DataType(DataType.Password)]
    [Required(ErrorMessage = "Password must be comfirmed")]
    public string ConfirmNewPassword { get; set; } = null!;
}
