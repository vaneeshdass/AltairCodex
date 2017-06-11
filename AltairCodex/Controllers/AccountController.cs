using AltairCodex.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AltairCodex.Controllers
{
    public class AccountController : Controller
    {
        public UserManager<IdentityUser> UserManager => HttpContext.GetOwinContext().Get<UserManager<IdentityUser>>();

        public SignInManager<IdentityUser, string> SignInManager
            => HttpContext.GetOwinContext().Get<SignInManager<IdentityUser, string>>();

        AltairCodexDbContext context = new AltairCodexDbContext();

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Register(RegisterModel model)
        {
            var identityUser = await UserManager.FindByNameAsync(model.Username);
            if (identityUser != null)
            {
                return RedirectToAction("Index", "Home");
            }

            var identityResult = await UserManager.CreateAsync(new IdentityUser(model.Username), model.Password);
            var identityUser2 = await UserManager.FindByNameAsync(model.Username);
            var user = context.AppUsers.Add(new AppUser()
            {
                IdentityId = identityUser2.Id,
            FullName = model.FullName,
                AddressLine = model.AddressLine,
                Country = model.Country,
                PinCode = model.PinCode,
                Location = DbGeography.FromText("POINT(13.0046949 77.7126473)"),
                DateCreated = DateTime.Now
            });
            context.SaveChanges();
            if (identityResult.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("", identityResult.Errors.FirstOrDefault());

            return View(model);
        }

    }

    public class RegisterModel
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public string FullName { get; set; }
        public string AddressLine { get; set; }
        public string Country { get; set; }
        public long PinCode { get; set; }
        public string Location { get; set; }

    }
}