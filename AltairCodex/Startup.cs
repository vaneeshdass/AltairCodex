using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using Microsoft.AspNet.Identity.Owin;
using AltairCodex.Models;
using Microsoft.Owin.Security.Cookies;
using System.Configuration;

[assembly: OwinStartup(typeof(AltairCodex.Startup))]

namespace AltairCodex
{
    public class Startup
    {

        /* The IAppBuilder interface is NOT a part of the OWIN specification. It is, however, a required component for a Katana host. The IAppBuilder interface provides a core set of methods required to implement the OWIN standard, and serves as a base for additional extension methods for implementing middleware.
         When the Katana host initializes the Startup class and calls Configuration(), a concrete instance of IAppBuilder is passed as the argument.We then use IAppBuilder to configure and add the application middleware components we need for our application, assembling the pipeline through which incoming HTTP requests will be processed. */
        public void Configuration(IAppBuilder app)
        {
            string connectionString = ConfigurationManager.AppSettings["ConnString"];
;
            app.CreatePerOwinContext(() => new IdentityDbContext(connectionString));

            app.CreatePerOwinContext<UserStore<IdentityUser>>((opt, cont) => new UserStore<IdentityUser>(cont.Get<IdentityDbContext>()));

            app.CreatePerOwinContext<UserManager<IdentityUser>>(
                (opt, cont) => new UserManager<IdentityUser>(cont.Get<UserStore<IdentityUser>>()));

            app.CreatePerOwinContext<SignInManager<IdentityUser, string>>(
               (opt, cont) =>
                   new SignInManager<IdentityUser, string>(cont.Get<UserManager<IdentityUser>>(), cont.Authentication));

            //Cookie based authentication
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie
            });
        }

    }
}