using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using InstaHub_MVC.Models;
using InstaHub_MVC.Models.Interfaces;

namespace InstaHub_MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAppUser _context;
        private readonly IGroup _group;

        public HomeController(IAppUser context, IGroup group)
        {
            _context = context;
            _group = group;
        }

        
        
        
        // Set props
        // Build constructor
        public async Task<IActionResult> Index()
        {
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
                // Decrypt jwt
                var handler = new JwtSecurityTokenHandler();
                var tokenS = handler.ReadToken(idToken) as JwtSecurityToken;

                
                // First check if user in in DB, check by email
                // if(_user.GetApplicationUserByID(string email) == null)
                // {
                // ApplicationUser appUser= new ApplicationUser();
                // set props
                //  _user.AddAppUser(appUser);
                // List<Group> groups = _groups.GetPublicGroups();
                // return View(groups);
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