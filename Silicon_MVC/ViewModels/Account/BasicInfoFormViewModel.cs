using System.ComponentModel.DataAnnotations;

namespace Silicon_MVC.ViewModels.Account;

public class BasicInfoFormViewModel
{
    public string UserId { get; set; } = null!;

    [Required(ErrorMessage = "A valid  first name is required")]
    [DataType(DataType.Text)]
    [Display(Name = "First Name", Prompt = "Enter your frist name", Order = 0)]
    public string FirstName { get; set; } = null!;

    [Required(ErrorMessage = "A valid  last name is required")]
    [Display(Name = "Last Name", Prompt = "Enter your last name", Order = 1)]
    [DataType(DataType.Text)]
    public string LastName { get; set; } = null!;

    [Display(Name = "Email address", Prompt = "Enter your email", Order = 2)]
    [DataType(DataType.EmailAddress)]
    [Required(ErrorMessage = "An valid  last name is required")]
    [RegularExpression(@"^(?=.*[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,})[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$",
    ErrorMessage = "The email format is not valid.")]
    public string Email { get; set; } = null!;

    [Display(Name = "Phone (optional)", Prompt = "Enter your phone", Order = 3)]
    [DataType(DataType.PhoneNumber)]
    public string? PhoneNumber { get; set; } = null!;

    [Display(Name = "Bio (optional)", Prompt = "Add a short bio...", Order = 4)]
    [DataType(DataType.MultilineText)]
    public string? Biography { get; set; }
}
