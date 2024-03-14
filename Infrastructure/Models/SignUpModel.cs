
using Infrastructure.Helpers;
using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Models;

public class SignUpModel
{
    [DataType(DataType.Text)]
    [Display(Name = "First Name", Prompt = "Enter your first name", Order = 0)]
    [Required(ErrorMessage = "First name is required")]
    [MinLength(2, ErrorMessage = "First name must be at least 2 characters long")]
    public string FirstName { get; set; } = null!;

    [DataType(DataType.Text)]
    [Display(Name = "Last Name", Prompt = "Enter your last name", Order = 1)]
    [Required(ErrorMessage = "Last name is required")]
    [MinLength(2, ErrorMessage = "Last name must be at least 2 characters long")]
    public string LastName { get; set; } = null!;

    [DataType(DataType.EmailAddress)]
    [Display(Name = "Email", Prompt = "Enter your email", Order = 2)]
    [Required(ErrorMessage = "Email is required")]
    [RegularExpression(@"^(?=.*[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,})[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$",
                          ErrorMessage = "The email format is not valid.")]
    public string Email { get; set; } = null!;

    [Display(Name = "Password", Prompt = "Enter your password", Order = 3)]
    [DataType(DataType.Password)]
    [Required(ErrorMessage = "Password is required")]
    [RegularExpression(@"^(?=.*[A-Z])(?=.*\d)(?=.*[^a-zA-Z\d\s])(?=.*[a-zA-Z\d]).{8,}$",
                      ErrorMessage = " At least one lowercase, uppercase letter and  one special character.")]
    public string Password { get; set; } = null!;

    [Display(Name = "Confirm Password", Prompt = "Confirm your password", Order = 4)]
    [DataType(DataType.Password)]
    [Required(ErrorMessage = "Password must be comfirmd")]
    [Compare("Password", ErrorMessage = "The confirmation password do not match.")]
    public string ConfirmPassword { get; set; } = null!;

    [Display(Name = "I agree to the Terms and Conditions", Order = 5)]
    [CheckBoxRequired(ErrorMessage = "Please agree to the terms and conditions")]
    public bool TermsAndConditions { get; set; } = false;
}
