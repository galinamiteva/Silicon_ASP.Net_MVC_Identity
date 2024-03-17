using Infrastructure.Models;

namespace Silicon_MVC.ViewModels;

public class WantViewModel
{
    public string Title { get; set; } = "Subscribe*";
    public WantModel Form { get; set; } = new WantModel();
}
