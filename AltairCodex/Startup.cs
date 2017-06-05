using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using Microsoft.AspNet.Identity.Owin;
using AltairCodex.Models;
using Microsoft.Owin.Security.Cookies;

[assembly: OwinStartup(typeof(AltairCodex.Startup))]

namespace AltairCodex
{
    public class Startup
    {

        /* The IAppBuilder interface is NOT a part of the OWIN specification. It is, however, a required component for a Katana host. The IAppBuilder interface provides a core set of methods required to implement the OWIN standard, and serves as a base for additional extension methods for implementing middleware.
         When the Katana host initializes the Startup class and calls Configuration(), a concrete instance of IAppBuilder is passed as the argument.We then use IAppBuilder to configure and add the application middleware components we need for our application, assembling the pipeline through which incoming HTTP requests will be processed. */
        public void Configuration(IAppBuilder app)
        {
            const string connectionString =@"Data Source=(LocalDb)\MSSQLLocalDB;Database=AltairCodex.Module1.1;trusted_connection=yes;";
            app.CreatePerOwinContext(() => new ExtendedUserDbContext(connectionString));
            app.CreatePerOwinContext<UserStore<ExtendedUser>>((opt, cont) => new UserStore<ExtendedUser>(cont.Get<ExtendedUserDbContext>()));
            app.CreatePerOwinContext<UserManager<ExtendedUser>>(
                (opt, cont) => new UserManager<ExtendedUser>(cont.Get<UserStore<ExtendedUser>>()));

            app.CreatePerOwinContext<SignInManager<ExtendedUser, string>>(
               (opt, cont) =>
                   new SignInManager<ExtendedUser, string>(cont.Get<UserManager<ExtendedUser>>(), cont.Authentication));

            //Cookie based authentication
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie
            });
        }

    }
}