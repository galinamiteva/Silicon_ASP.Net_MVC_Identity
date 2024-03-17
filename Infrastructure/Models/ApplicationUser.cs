

using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Models;

public class ApplicationUser: IdentityUser
{
    [Required]
    [Display(Name = "First Name")]
    [ProtectedPersonalData]

    public string FirstName { get; set; } = null!;

    [Required]
    [Display(Name = "Last Name")]
    [ProtectedPersonalData]

    public string LastName { get; set; } = null!;
}
