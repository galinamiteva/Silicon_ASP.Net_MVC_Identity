using Infrastructure.Models;

namespace Silicon_MVC.ViewModels;

public class SignUpViewModel
{
    public string Title { get; set; } = "Sign Up";
    public string? ErrorMessage { get; set; }
    public SignUpModel Form { get; set; } = new SignUpModel();
    
}
