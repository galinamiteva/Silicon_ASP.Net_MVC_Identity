using Infrastructure.Models;

namespace Silicon_MVC.ViewModels;

public class SignInViewModel
{
    public string Title { get; set; } = "Sign In";
    public string? ErrorMessage { get; set; }
    public SignInModel Form { get; set; } = new SignInModel();
   
}
