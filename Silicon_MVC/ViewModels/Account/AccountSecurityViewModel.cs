namespace Silicon_MVC.ViewModels.Account;

public class AccountSecurityViewModel
{
    public BasicInfoFormViewModel BasicInfoForm { get; set; } = null!;
    public ProfileInfoViewModel ProfileInfo { get; set; } = null!;

    public PassFormViewModel PassForm { get; set; } = null!;
    public DeleteFormViewModel DeleteForm { get; set; } = null!;

}
