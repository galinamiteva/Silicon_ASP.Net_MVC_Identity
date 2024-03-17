using Infrastructure.Entities;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Silicon_MVC.ViewModels.Account;

namespace Silicon_MVC.Controllers;

[Authorize]
public class AccountController(UserManager<UserEntity> userManager, AddressManager addressManager) : Controller
{
    private readonly UserManager<UserEntity> _userManager = userManager;
    private readonly AddressManager _addressManager = addressManager;


    #region Details
    [HttpGet]
    [Route("/account/details")]
    public async Task<IActionResult> Details()
    {
        var claims = HttpContext.User.Identities.FirstOrDefault();
        var viewModel = new AccountDetailsViewModel
        {
            ProfileInfo = await PopulateProfileInfoAsync()
        };
        viewModel.BasicInfoForm ??= await PopulateBasicInfoAsync();
        viewModel.AddressInfoForm ??= await PopulateAddressInfoAsync();

        return View(viewModel);
    }
    #endregion


    #region [HttpPost] Details
    [HttpPost]
    [Route("/account/details")]
    public async Task<IActionResult> Details(AccountDetailsViewModel viewModel)
    {
        if (viewModel.BasicInfoForm != null)
        {
            if (viewModel.BasicInfoForm.FirstName != null && viewModel.BasicInfoForm.LastName != null && viewModel.BasicInfoForm.Email != null)
            {
                var user = await _userManager.GetUserAsync(User);

                if (user != null)
                {
                    user.FirstName = viewModel.BasicInfoForm.FirstName;
                    user.LastName = viewModel.BasicInfoForm.LastName;
                    user.Email = viewModel.BasicInfoForm.Email;
                    user.PhoneNumber = viewModel.BasicInfoForm.PhoneNumber;
                    user.Bio = viewModel.BasicInfoForm.Biography;

                    var result = await _userManager.UpdateAsync(user);

                    if (!result.Succeeded)
                    {
                        ModelState.AddModelError("IncorrectValues", "Something went wrong! Unable to save data!");
                        ViewData["ErrorMessage"] = "Unable to save user information";
                    }
                }
            }
        }

        if (viewModel.AddressInfoForm != null)
        {
            if (viewModel.AddressInfoForm.Addressline_1 != null && viewModel.AddressInfoForm.PostalCode != null && viewModel.AddressInfoForm.City != null)
            {
                var user = await _userManager.GetUserAsync(User);

                if (user != null)
                {
                    var address = await _addressManager.GetAddressAsync(user.Id);
                    
                    if (address != null)
                    {
                        address.Addressline_1 = viewModel.AddressInfoForm.Addressline_1;
                        address.Addressline_2 = viewModel.AddressInfoForm.Addressline_2;
                        address.PostalCode = viewModel.AddressInfoForm.PostalCode;
                        address.City = viewModel.AddressInfoForm.City;

                        var result = await _addressManager.UpdateAddressAsync(address);
                        if (!result)
                        {
                            ModelState.AddModelError("IncorrectValues", "Something went wrong! Unable to save data!");
                            ViewData["ErrorMessage"] = "Unable to save address information";
                        }

                    }

                    else
                    {
                        address = new AddressEntity
                        {
                            UserId = user.Id,
                            Addressline_1 = viewModel.AddressInfoForm.Addressline_1,
                            Addressline_2 = viewModel.AddressInfoForm.Addressline_2,
                            PostalCode = viewModel.AddressInfoForm.PostalCode,
                            City = viewModel.AddressInfoForm.City,
                        };

                        var result = await _addressManager.CreateAddressAsync(address);
                        if (!result)
                        {
                            ModelState.AddModelError("IncorrectValues", "Something went wrong! Unable to save data!");
                            ViewData["ErrorMessage"] = "Unable to save address information";
                        }


                    }
                }
            }
        }

        viewModel.ProfileInfo = await PopulateProfileInfoAsync();
        viewModel.BasicInfoForm ??= await PopulateBasicInfoAsync();
        viewModel.AddressInfoForm ??= await PopulateAddressInfoAsync();



        return View(viewModel);
    }
    #endregion


    private async Task<ProfileInfoViewModel> PopulateProfileInfoAsync()
    {
        var user = await _userManager.GetUserAsync(User);

        return new ProfileInfoViewModel()
        {
            FirstName = user!.FirstName,
            LastName = user.LastName,
            Email = user.Email!,
        };
    }

    private async Task<BasicInfoFormViewModel> PopulateBasicInfoAsync()
    {
        var user = await _userManager.GetUserAsync(User);

        return new BasicInfoFormViewModel()
        {
            UserId = user!.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Email = user.Email!,
            PhoneNumber = user.PhoneNumber,
            Biography = user.Bio,
        };

    }

    private async Task<AddressInfoFormViewModel> PopulateAddressInfoAsync()
    {

        var user = await _userManager.GetUserAsync(User);
        if (user != null)
        {
            var address = await _addressManager.GetAddressAsync(user.Id);
            if (address != null)
            {
                return new AddressInfoFormViewModel()
                {

                    Addressline_1 = address.Addressline_1,
                    Addressline_2 = address.Addressline_2,
                    PostalCode = address.PostalCode,
                    City = address.City,
                };
            }
        }

        return new AddressInfoFormViewModel();

    }

    #region Security

    [HttpGet]
    [Route("/account/security")]
    public async Task<IActionResult> Security()
    {
        var viewModel = new AccountSecurityViewModel
        {
            PassForm = await PopulateSecurityPassFormAsync()
        };

        viewModel.BasicInfoForm ??= await PopulateBasicInfoAsync();
        viewModel.ProfileInfo ??= await PopulateProfileInfoAsync();
        return View(viewModel);
    }

    [HttpPost]
    [Route("/account/security")]
    public async Task<IActionResult> Security(AccountSecurityViewModel viewModel)
    {
        if (viewModel.PassForm != null)
        {
            if (viewModel.PassForm.CurrentPassword != null &&
                viewModel.PassForm.NewPassword != null &&
                viewModel.PassForm.ConfirmNewPassword != null)
            {
                if (viewModel.PassForm.NewPassword == viewModel.PassForm.ConfirmNewPassword)
                {
                    var user = await _userManager.GetUserAsync(User);

                    if (user != null)
                    {
                        var result = await _userManager.ChangePasswordAsync(user, viewModel.PassForm.CurrentPassword, viewModel.PassForm.NewPassword);

                        if (!result.Succeeded)
                        {
                            ModelState.AddModelError("IncorrectValues", "Failed to update user information");
                            ViewData["ErrorMessage"] = "Failed to update password";
                        }
                        else
                        {
                            ViewData["SuccessMessage"] = "Password updated successfully!";
                        }
                    }
                }
                else
                {
                    ModelState.AddModelError("PasswordMismatch", "New password and confirm password do not match.");
                    ViewData["ErrorMessage"] = "New password and confirm password do not match.";
                }
            }
        }

        viewModel.BasicInfoForm = await PopulateBasicInfoAsync();
        viewModel.ProfileInfo = await PopulateProfileInfoAsync();
        viewModel.PassForm = await PopulateSecurityPassFormAsync();

        return View(viewModel);
    }


    private async Task<PassFormViewModel> PopulateSecurityPassFormAsync()
    {
        var user = await _userManager.GetUserAsync(User);
        
        if (user != null)
        {
            return new PassFormViewModel()
            {
                UserId = user!.Id,
                ConfirmNewPassword = user.PasswordHash!,
                CurrentPassword = user.PasswordHash!,
                NewPassword = user.PasswordHash!,
            };
        }
       
        return null!;

    }






    [HttpPost]
    [Route("/account/delete")]
    public async Task<IActionResult> DeleteAccount()
    {
        var user = await _userManager.GetUserAsync(User);

        if (user != null)
        {
            var result = await _userManager.DeleteAsync(user);

            if (result.Succeeded)
            {
                await HttpContext.SignOutAsync();
                ViewData["SuccessMessage"] = "Account deleted successfully!";
                await Task.Delay(1000);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewData["ErrorMessage"] = "Failed to delete the account";
            }
        }
        else
        {
            ViewData["ErrorMessage"] = "User not found";
        }

        return View("AccountDeletedConfirmation");
    }

    #endregion
}
