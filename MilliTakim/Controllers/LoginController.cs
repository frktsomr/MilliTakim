using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using MilliTakim.Models.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MilliTakim.Controllers
{
    public class LoginController : Controller
    {
        WebContext webContext;

        public LoginController(WebContext _webContext)
        {
            webContext = _webContext;
        }

        

        [HttpGet]
         public IActionResult GirisYap()
         {
          return View();
         }

        public async Task <IActionResult> GirisYap(Admin admin)
        {
            var bilgiler = webContext.admins.FirstOrDefault(x => x.adminAd == admin.adminAd && x.adminSifre == admin.adminSifre);
            if(bilgiler!=null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,admin.adminAd)
                };
                var useridentity = new ClaimsIdentity(claims, "Login");
                ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);
                await HttpContext.SignInAsync(principal);
                return RedirectToAction("Privacy", "Home");

            }
            return View();
        }
    }
}
