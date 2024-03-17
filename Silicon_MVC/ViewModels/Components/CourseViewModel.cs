namespace Silicon_MVC.ViewModels.Components;

public class CourseViewModel
{
    public ImageViewModel Image { get; set; } = null!;
    public string? Tag { get; set; }
    public string Icon { get; set; } = null!;
    public string Title { get; set; } = null!;
    public string Author { get; set; } = null!;
    public string Price { get; set; } = null!;
    public string? SalesPrice { get; set; }
    public string Duration { get; set; } = null!;
    public string Rating { get; set; } = null!;
}
