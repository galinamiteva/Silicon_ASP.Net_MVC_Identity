using Infrastructure.Helpers;
using System.ComponentModel.DataAnnotations;

namespace Silicon_MVC.ViewModels.Account
{
    public class DeleteFormViewModel
    {
        [Display(Name = "Yes, I want to delete my account.", Order = 4)]
        [CheckBoxRequired(ErrorMessage = "Please, check the box before deleting")]
        public bool IsDeleted { get; set; } = false;
    }
}
