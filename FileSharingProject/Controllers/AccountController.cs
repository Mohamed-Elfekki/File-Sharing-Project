using AutoMapper;
using FileSharingProject.Data;
using FileSharingProject.Helpers.Mail;
using FileSharingProject.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Operations;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FileSharingProject.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IMapper mapper;
        private readonly IMailHelper mailHelper;

        public AccountController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager,
            IMapper mapper, IMailHelper mailHelper)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.mapper = mapper;
            this.mailHelper = mailHelper;
        }


        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var existedUser = await userManager.FindByEmailAsync(model.Email);
                if (existedUser == null)
                {
                    TempData["Error"] = "Invalid Email or Password";
                    return View(model);
                }

                if (!existedUser.IsBlocked)
                {
                    var result = await signInManager.PasswordSignInAsync(model.Email, model.Password, true, true);
                    if (result.Succeeded)
                    {
                        if (!string.IsNullOrEmpty(returnUrl))
                        {
                            return LocalRedirect(returnUrl);
                        }

                        return RedirectToAction("Create", "Uploads");
                    }
                    else if (result.IsNotAllowed)
                    {
                        TempData["Error"] = "Require Email Confirmation!";
                    }
                }
                else
                {
                    TempData["Error"] = "This account has been blocked";
                }
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email, FirstName = model.FirstName, LastName = model.LastName };
                var result = await userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    //create Link
                    var token = await userManager.GenerateEmailConfirmationTokenAsync(user);
                    var url = Url.Action("ConfirmEmail", "Account", new { token = token, userId = user.Id }, Request.Scheme);
                    //Send Email
                    StringBuilder body = new StringBuilder();
                    body.AppendLine("File Sharing Application: Email Confirmation");
                    body.AppendFormat("to confirm your email, you should <a href='{0}'> click here </a>", url);
                    mailHelper.SendMail(new InputEmailMessage
                    {
                        Body = body.ToString(),
                        Email = model.Email,
                        Subject = "Email Confirmation"
                    });

                    return RedirectToAction("RequireEmailConfirm");

                    // await signInManager.SignInAsync(user, isPersistent: true);
                    // return RedirectToAction("Create", "Uploads");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

            }

            return View(model);
        }

        [HttpGet]
        public IActionResult RequireEmailConfirm()
        {
            return View();
        }


        [HttpGet]
        public async Task<IActionResult> LogOut()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        //--------External Login----------------//

        public IActionResult ExternalLogin(string provider) // provider = "Facebook", "Google"
        {
            var properties = signInManager.ConfigureExternalAuthenticationProperties(provider, "/Account/ExternalResponse");
            return Challenge(properties, provider);
        }
        public async Task<IActionResult> ExternalResponse()
        {
            var info = await signInManager.GetExternalLoginInfoAsync();
            if (info == null)
            {
                TempData["Message"] = "Login Failed";
                return RedirectToAction("Login");
            }

            var loginResult = await signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, false);
            if (loginResult.Succeeded)
            {
                var email = info.Principal.FindFirstValue(ClaimTypes.Email);
                var firstName = info.Principal.FindFirstValue(ClaimTypes.GivenName);
                var lastName = info.Principal.FindFirstValue(ClaimTypes.Surname);
                //Create Local Account
                var userToCreate = new ApplicationUser
                {
                    Email = email,
                    UserName = email,
                    FirstName = firstName,
                    LastName = lastName,
                    EmailConfirmed = true
                };

                var createResult = await userManager.CreateAsync(userToCreate);
                if (createResult.Succeeded)
                {
                    var exLoginResult = await userManager.AddLoginAsync(userToCreate, info);//AspNetUserLogin ""Table""
                    if (exLoginResult.Succeeded)
                    {
                        await signInManager.SignInAsync(userToCreate, false, info.LoginProvider);
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        await userManager.DeleteAsync(userToCreate);
                    }
                }
                return RedirectToAction("Login");
            }


            if (info.Principal.HasClaim(c => c.Type == ClaimTypes.Email))
            {
                var email = info.Principal.FindFirstValue(ClaimTypes.Email);
                var existedUser = await userManager.FindByEmailAsync(email);
                if (existedUser == null)
                {
                    TempData["Error"] = "Invalid Email or Password";
                    return RedirectToAction("Login");
                }
                if (existedUser.IsBlocked)
                {
                    await signInManager.SignOutAsync();
                    TempData["Error"] = "This account has been blocked";
                    return RedirectToAction("Login");
                }
            }
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Info()
        {
            var currentUser = await userManager.GetUserAsync(User);

            if (currentUser != null)
            {
                var model = mapper.Map<UserViewModel>(currentUser);

                return View(model);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Info(UserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var currentUser = await userManager.GetUserAsync(User);

                if (currentUser != null)
                {
                    currentUser.FirstName = model.FirstName;
                    currentUser.LastName = model.LastName;

                    var result = await userManager.UpdateAsync(currentUser);
                    if (result.Succeeded)
                    {
                        TempData["Success"] = "Name Changed Successfully!";
                        return RedirectToAction("Info");
                    }
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }

                }
                else
                {
                    return NotFound();
                }
            }
            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            var currentUser = await userManager.GetUserAsync(User);

            if (currentUser != null)
            {
                if (ModelState.IsValid)
                {
                    var result = await userManager.ChangePasswordAsync(currentUser, model.CurrentPassword, model.NewPassword);
                    if (result.Succeeded)
                    {
                        TempData["Success"] = " Password Changed Successfully, Please Sign In!";
                        await signInManager.SignOutAsync();
                        return RedirectToAction("Login");
                    }
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            else
            {
                return NotFound();
            }
            return View("Info", mapper.Map<UserViewModel>(currentUser));
        }


        [HttpPost]
        public async Task<IActionResult> AddPassword(AddPasswordViewModel model)
        {
            var currentUser = await userManager.GetUserAsync(User);

            if (currentUser != null)
            {
                if (ModelState.IsValid)
                {
                    var result = await userManager.AddPasswordAsync(currentUser, model.Password);
                    if (result.Succeeded)
                    {
                        TempData["Success"] = " Password Added Successfully!";
                        return RedirectToAction("Info");
                    }
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            else
            {
                return NotFound();
            }
            return View("Info", mapper.Map<UserViewModel>(currentUser));
        }

        public async Task<IActionResult> ConfirmEmail(ConfirmEmailViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByIdAsync(model.UserId);
                if (user != null)
                {
                    if (!user.EmailConfirmed)
                    {
                        var result = await userManager.ConfirmEmailAsync(user, model.Token);
                        if (result.Succeeded)
                        {
                            TempData["Success"] = "Your Email already confirmed";
                            return RedirectToAction("Login");
                        }
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError("", error.Description);
                        }
                    }
                    else
                    {

                        TempData["Success"] = "Your Email already confirmed";
                    }

                }

            }
            return View();
        }


        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var existedUser = await userManager.FindByEmailAsync(model.Email);
                if (existedUser != null)
                {
                    var token = await userManager.GeneratePasswordResetTokenAsync(existedUser);
                    var url = Url.Action("ResetPassword", "Account", new { token, model.Email }, Request.Scheme);
                    StringBuilder body = new StringBuilder();
                    body.AppendLine("File Sharing Application: Reset Password");
                    body.AppendLine("We are sending this email, because we have received a reset password request to your account");
                    body.AppendFormat("to reset new password, you should <a href='{0}'> click here </a>", url);

                    mailHelper.SendMail(new InputEmailMessage
                    {
                        Email = model.Email,
                        Subject = "Reset Password",
                        Body = body.ToString()
                    });
                }
                TempData["Success"] = "If your email matched an existed account in our system, you should Receive an Email";
            }
            return View(model);
        }


        public async Task<IActionResult> ResetPassword(VerifyRestPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var existedUser = await userManager.FindByEmailAsync(model.Email);
                if (existedUser != null)
                {
                    var isValid = await userManager.VerifyUserTokenAsync(existedUser, TokenOptions.DefaultProvider, "ResetPassword", model.Token);
                    if (isValid)
                    {
                        return View();
                    }
                    else
                    {
                        TempData["Error"] = "Token is invalid";
                    }
                }

            }
            return RedirectToAction("Login");
        }

        public async Task<IActionResult> ResetPasswod(ResetPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var existedUser = await userManager.FindByNameAsync(model.Email);
                if (existedUser != null)
                {
                    var result = await userManager.ResetPasswordAsync(existedUser, model.Token, model.NewPassword);
                    if (result.Succeeded)
                    {
                        TempData["Success"] = "Reset Password Completed Successfully!.";
                        return RedirectToAction("Login");
                    }
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return View(model);
        }

    }
}
