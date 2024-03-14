using Silicon_MVC.ViewModels;

namespace Silicon_MVC.Views;

public class HomeIndexViewModel
{
    public string? Title { get; set; } = "Ultimate Task Managment Assistant";
    public ShowcaseViewModel Showcase { get; set; } = new ShowcaseViewModel
    {
        Id = "overview",
        ShowcaseImage = new() { ImageUrl = "/images/showcase-taskmaster.png", AltText = "Task Managment Assistant" },
        Title = "Task Management Assistant You Gonna Love",
        Text = "We offer you a new generation of task management system. Plan, manage & track all your tasks in one flexible tool.",
        Link = new() { ControllerName = "Downloads", ActionName = "Index", Text = "Get started for free" },
        BrandsText = "Largest companies use our tool to work efficiently",
        Brands =
                [
                    new() { ImageUrl = "/images/brands/brand_1.png", AltText = "Brand Name 1" },
                    new() { ImageUrl = "/images/brands/brand_2.png", AltText = "Brand Name 2" },
                    new() { ImageUrl = "/images/brands/brand_3.png", AltText = "Brand Name 3" },
                    new() { ImageUrl = "/images/brands/brand_4.png", AltText = "Brand Name 4" },

                ],
    };
}
