using Auction.Libraries.HashPassword;
using AuctionHome.Data;
using AuctionHome.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AuctionHome.Controllers
{
    public class AccountController : Controller
    {
       
        private readonly IUser userInterface;
        public AccountController(IUser user)
        {
           
            userInterface = user;
        }

        [HttpGet]
        public IActionResult Login(string returnUrl)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
           // return Ok(new HashPassword().EncryptString("harry"));
        }

        [HttpPost]
        public async Task<IActionResult> Login(string username, string password, string returnUrl)
        {
            // get the previous Url
            ViewData["ReturnUrl"] = returnUrl;
            // find username and password in database
            var item = await userInterface.getByUsername(username);
            if (item != null)
            {
                //decrypt password
                var hashPassword = new HashPassword();
                string decryptPass = hashPassword.DecryptString(item.Password);
                if (password == decryptPass)
                {
                    var claims = new List<Claim>();
                    claims.Add(new Claim("username", username));
                  
                    claims.Add(new Claim(ClaimTypes.Role, username));
                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                    await HttpContext.SignInAsync(claimsPrincipal);
                    return Redirect(returnUrl);
                }

            }



            TempData["error"] = "username or password are wrong";
            return View();
        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/");
        }
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
