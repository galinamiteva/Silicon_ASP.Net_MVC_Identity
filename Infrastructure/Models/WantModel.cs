

using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Models;

public class WantModel
{

    [Display(Name = "Daily Newsletter", Order = 0)]
    public bool Checkbox1 { get; set; } = false;

    [Display(Name = "Event Updates", Order = 1)]
    public bool Checkbox2 { get; set; } = false;

    [Display(Name = "Advertising Updates", Order = 2)]
    public bool Checkbox3 { get; set; } = false;

    [Display(Name = "Startups Weekly", Order = 3)]
    public bool Checkbox4 { get; set; } = false;

    [Display(Name = "Week in Review", Order = 4)]
    public bool Checkbox5 { get; set; } = false;

    [Display(Name = "Podcasts", Order = 5)]
    public bool Checkbox6 { get; set; } = false;

    [Display(Prompt = "Your email", Order = 6)]
    [DataType(DataType.EmailAddress)]
    [Required(ErrorMessage = "Email is required")]
    public string Email { get; set; } = null!;
}
