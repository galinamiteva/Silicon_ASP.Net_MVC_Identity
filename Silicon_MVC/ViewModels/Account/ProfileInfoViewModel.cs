namespace Silicon_MVC.ViewModels.Account
{
    public class ProfileInfoViewModel
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        
        public bool AccountExternal { get; set; }

        public BasicInfoFormViewModel? BasicInfoForm { get; set; }

        public string? ProfileImageUrl { get; set; } = "profile-image.svg";

        //public string? ProfileImageUrl { get; set; }

    }

}
