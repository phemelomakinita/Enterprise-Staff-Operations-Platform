using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using EnterpriseStaffOperationsPlatform.Models;


namespace EnterpriseStaffOperationsPlatform.Controllers
{
    public class AccessController : Controller
    {
        //Display the administrator login page
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        //Process the administrator login
        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            //Verify if the administrators login details are correct
            if (username == "admin" && password == "admin123")
            {   
                //Create claims that contain the admmins information
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, username),
                    new Claim(ClaimTypes.Role, "Administrator")
                };

                //Create an identity using the cookie authentication scheeme
                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                //Creating the authenticated users principal
                var principal = new ClaimsPrincipal(identity);

                //Sign in the adminstrator
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                return RedirectToAction("Index", "Staff");
            }

            //Show the admin error when credentials are ncorrect
            ModelState.AddModelError("", "Invalid username or password");

            //Rteurn to the login page
            return View();
        }

        //Logout the admin
        public async Task<IActionResult> Logout()
        {
            //Remove the administrators authentication cookie
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            //Redirect the admin back to the login page
            return RedirectToAction("Login");
        }
    }
}
    
