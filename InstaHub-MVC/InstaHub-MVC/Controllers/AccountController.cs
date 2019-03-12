using InstaHub_MVC.Models;
using InstaHub_MVC.Models.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SampleMvcApp.Controllers
{
    public class AccountController : Controller
    {

        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;

        /// <summary>
        /// Constructs usercontrooler object to manage user registration and sign-in
        /// </summary>
        /// <param name="userManager">User manager services</param>
        /// <param name="signInManager">SignIn manager services</param>
        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        //Set up registration view-carlos
        [HttpGet]
        public IActionResult Register() => View();

        [HttpPost]
        public async Task<IActionResult> Register(RegisterUser rvm)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = new ApplicationUser()
                {
                    UserName = rvm.UserName,
                    //Email = rvm.Email,
                    //FirstName = rvm.FirstName,
                    //LastName = rvm.LastName,
                };

                var result = await _userManager.CreateAsync(user, rvm.Password);

                if (result.Succeeded)
                {

                    Claim userNameClaim = new Claim("UserName", $"{user.UserName}");
                    //Claim fullNameClaim = new Claim("FullName", $"{user.FirstName} {user.LastName}");
                    //Claim emailClaim = new Claim(ClaimTypes.Email, $"{user.Email}", ClaimTypes.Email);

                    //List<Claim> claims = new List<Claim> { userNameClaim ,fullNameClaim, emailClaim };
                    List<Claim> claims = new List<Claim> { userNameClaim };

                    await _userManager.AddClaimsAsync(user, claims);
                    await _signInManager.SignInAsync(user, isPersistent: false);
                }
            }
            return View(rvm);
        }

        [HttpGet]
        public IActionResult Login() => View();

        [HttpPost]
        public async Task<IActionResult> Login(LoginUser lvm)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(lvm.Email, lvm.Password, false, false);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Folder");
                }
            }
            ModelState.TryAddModelError(string.Empty, "Invalid Login Attempt");
            return View(lvm);
        }

        //*****************************************External Login******************************
        /// <summary>
        /// External Login
        /// </summary>
        /// <param name="error"></param>
        /// <returns></returns>
        /*
        [HttpGet]
        public async Task<IActionResult> ExternalLoginCallBack(string error = null)
        {
            if (error != null)
            {
                TempData["Error"] = "Error with the Provider";
                return RedirectToAction("Login");
            }

            var info = await _signInManager.GetExternalLoginInfoAsync();

            if (info == null)
            {
                return RedirectToAction(nameof(Login));
            }

            var result = await _signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, isPersistent: false, bypassTwoFactor: true);

            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Folder");
            }

            var email = info.Principal.FindFirstValue(ClaimTypes.Email);

            return View("ExternalLogin", new ExternalLogin { Email = email });
        }

        public async Task<IActionResult> ExternalLoginConfirmation(ExternalLogin elvm)
        {
            if (ModelState.IsValid)
            {
                var info = await _signInManager.GetExternalLoginInfoAsync();
                if (info == null)
                {
                    TempData["Error"] = "Error loggin in!";
                }

                var user = new ApplicationUser
                {
                    UserName = elvm.Email,
                    Email = elvm.Email,
                    FirstName = elvm.FirstName,
                    LastName = elvm.LastName,
                };

                var result = await _userManager.CreateAsync(user);

                if (result.Succeeded)
                {
                    Claim fullNameFromClaim = new Claim("FullName", $"{user.FirstName}{user.LastName}");
                    await _userManager.AddClaimAsync(user, fullNameFromClaim);

                    result = await _userManager.AddLoginAsync(user, info);

                    if (result.Succeeded)
                    {
                        await _signInManager.SignInAsync(user, isPersistent: false);

                        return RedirectToAction("Index", "Folder");
                    }
                }
            }
            return View(elvm);
        }
        */
        //**********************************************************************

        public async Task ExternalLogin(string returnUrl = "/")
        {
            await HttpContext.ChallengeAsync("Auth0", new AuthenticationProperties() { RedirectUri = returnUrl });
        }
        
        [Authorize]
        public async Task Logout()
        {
            await HttpContext.SignOutAsync("Auth0", new AuthenticationProperties
            {
                // Indicate here where Auth0 should redirect the user after a logout.
                // Note that the resulting absolute Uri must be whitelisted in the 
                // **Allowed Logout URLs** settings for the client.
                RedirectUri = Url.Action("Index", "Home")
            });
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            await _signInManager.SignOutAsync();
        }

        /// <summary>
        /// This is just a helper action to enable you to easily see all claims related to a user. It helps when debugging your
        /// application to see the in claims populated from the Auth0 ID Token
        /// </summary>
        /// <returns></returns>
        [Authorize]
        public IActionResult Claims()
        {
            return View();
        }

        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
