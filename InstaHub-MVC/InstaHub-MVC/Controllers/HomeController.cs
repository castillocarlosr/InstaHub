using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using InstaHub_MVC.Models.Interfaces;
using InstaHub_MVC.Models;
using Microsoft.AspNetCore.Identity;

namespace InstaHub_MVC.Controllers
{
    public class HomeController : Controller
    {
        private IGroup _group { get; }
        private IAppUser _user { get; }
        private UserManager<ApplicationUser> _userManager;

        public HomeController(IGroup group, IAppUser user)
        {
            _group = group;
            _user = user;
        }
        // Set props
        // Build constructor
        public async Task<IActionResult> Index()
        {
            var query = await _userManager.CreateAsync(user);

            // If the user is authenticated, then this is how you can get the access_token and id_token
            if (User.Identity.IsAuthenticated)
            {
                string accessToken = await HttpContext.GetTokenAsync("access_token");

                // if you need to check the access token expiration time, use this value
                // provided on the authorization response and stored.
                // do not attempt to inspect/decode the access token
                DateTime accessTokenExpiresAt = DateTime.Parse(
                    await HttpContext.GetTokenAsync("expires_at"),
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.RoundtripKind);
                
                string idToken = await HttpContext.GetTokenAsync("id_token");

                // -------------------------------------------------------//
                var handler = new JwtSecurityTokenHandler();
                var tokenS = handler.ReadToken(idToken) as JwtSecurityToken;
                string email = tokenS.Claims.FirstOrDefault(c => c.Type == "email").Value;
                if (await _user.GetApplicationUserByEmail(email) == null)
                {
                    ApplicationUser appUser = new ApplicationUser();
                    appUser.Name = tokenS.Claims.FirstOrDefault(c => c.Type == "name").Value;
                    appUser.Email = tokenS.Claims.FirstOrDefault(c => c.Type == "email").Value;
                    appUser.Avatar = tokenS.Claims.FirstOrDefault(c => c.Type == "picture").Value;

                    await _user.AddAppUser(appUser);
                    IEnumerable<Group> groups = await _group.GetPublicGroups();
                    return View(groups);
                }
                // -------------------------------------------------------//


                // Now you can use them. For more info on when and how to use the
                // access_token and id_token, see https://auth0.com/docs/tokens

            }
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}