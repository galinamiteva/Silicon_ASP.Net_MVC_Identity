using Silicon_MVC.ViewModels;
using Silicon_MVC.ViewModels.Components;

namespace Silicon_MVC.Views;

public class CoursesIndexViewModel
{
    public string Title { get; set; } = "Courses";
    public CoursesViewModel Course { get; set; } = new CoursesViewModel
    {
        Course =
            [
                new() { Image = new() { ImageUrl = "/images/courses/fulstack.svg", AltText = "fulstack's kurs" }, Tag = "Best Seller", Icon = "fa-regular fa-bookmark",  Title = "Fullstack Web Developer Course from Scratch", Author = "by Robert Fox", Price = "12.50", Duration = "220 hours", Rating = "94% (4.2K)" },
                    new() { Image = new() { ImageUrl = "/images/courses/developer.svg", AltText = "developer's kurs" }, Icon = "fa-regular fa-bookmark", Title = "HTML , CSS , JavaScript , Web  Developer", Author = "By Jenny Wilson & Marvin McKinney", Price = "15.99", Duration = "160 hours", Rating = "92% (3.1K)" },
                    new() { Image = new() { ImageUrl = "/images/courses/front_end.svg", AltText = "frontend's kurs" }, Icon = "fa-regular fa-bookmark", Title = "The Complete Front-End Web Development Course", Author = "By Albert Flores", Price = "44.99", SalesPrice = "9.99", Duration = "100 hours", Rating = "98% (2.7K)" },
                    new() { Image = new() { ImageUrl = "/images/courses/ios.svg", AltText = "ios app kurs" }, Icon = "fa-regular fa-bookmark",  Title = "iOS & Swift - The Complete iOS App Development Course", Author = "By Marvin McKinney", Price = "15.99", Duration = "160 hours", Rating = "92% (3.1K)" },
                    new() { Image = new() { ImageUrl = "/images/courses/python.svg", AltText = "science kurs" }, Tag = "Best Seller", Icon = "fa-regular fa-bookmark", Title = "Data Science & Machine Learning with Python", Author = "By Esther Howard", Price = "11.20", Duration = "160 hours", Rating = "92% (3.1K)" },
                    new() { Image = new() { ImageUrl = "/images/courses/css.svg", AltText = "art kurs" }, Icon = "fa-regular fa-bookmark", Title = "Creative CSS Drawing Course: Make Art With CSS", Author = "By Robert Fox", Price = "10.50", Duration = "220 hours", Rating = "94% (4.2K)" },
                    new() { Image = new() { ImageUrl = "/images/courses/blender.svg", AltText = "video games kurs" }, Icon = "fa-regular fa-bookmark",  Title = "Blender Character Creator v2.0 for Video Games Design", Author = "By Ralph Edwards", Price = "18.99", Duration = "160 hours", Rating = "92% (3.1K)" },
                    new() { Image = new() { ImageUrl = "/images/courses/ultimate.svg", AltText = "mobile game developer's kurs" }, Icon = "fa-regular fa-bookmark", Title = "The Ultimate Guide to 2D Mobile Game Development with Unity", Author = "By Albert Flores", Price = "44.99", SalesPrice = "12.50", Duration = "100 hours", Rating = "98% (2.7K)" },
                    new() { Image = new() { ImageUrl = "/images/courses/jmeter.svg", AltText = "jmeter kurs" }, Icon = "fa-regular fa-bookmark", Title = "Learn JMETER from Scratch on Live Apps-Performance Testing", Author = "By Jenny Wilson", Price = "14.50", Duration = "160 hours", Rating = "92% (3.1K)" },
                ]
    };
    public Get_StartedViewModel Started { get; set; } = new Get_StartedViewModel
    {
        Question = "Ready to get started?",
        Title1 = "Take Your ",
        BlueTitle = "Skills",
        Title2 = " to the Next Level",
        Link = new() { Text = "Work with us", ControllerName = "", ActionName = "" },
        Image = new() { ImageUrl = "/images/courses/illustration.svg", AltText = "Illustration" }

    };
}
