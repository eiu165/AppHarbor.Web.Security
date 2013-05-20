using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using AppHarbor.Web.Security;
using AuthenticationExample.Web.Mvc;
using Auth.Data.PersistenceSupport;
using StructureMap;
using Auth.Business;
using System.Configuration;

namespace AuthenticationExample.Web
{
	public class MvcApplication : System.Web.HttpApplication
	{
		public static void RegisterRoutes(RouteCollection routes)
		{
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
			routes.IgnoreRoute("{*favicon}", new { favicon = @"(.*/)?favicon.ico(/.*)?" });

			routes.MapRoute(
				"Default", // Route name
				"{controller}/{action}/{id}", // URL with parameters
				new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
			);
		}

		protected void Application_Start()
		{
            var connectionString = ConfigurationManager.ConnectionStrings["ApplicationConnectionString"].ConnectionString;

            ObjectFactory.Initialize(x =>
            { 
                x.For<IUserRepository>().Use<SqlUserRepository>().WithCtorArg("connectionString").EqualTo(connectionString);
                x.For<IAccountService>().Use<AccountService>();
                x.For<HttpContextBase>().Use(() => new HttpContextWrapper(HttpContext.Current));
                x.For<ICookieAuthenticationConfiguration>().Use<ConfigFileAuthenticationConfiguration>();
                x.For<IAuthenticator>().Use<CookieAuthenticator>(); 
            }); 
              
			ControllerBuilder.Current.SetControllerFactory(new StructureMapControllerFactory());

			AreaRegistration.RegisterAllAreas();

			RegisterRoutes(RouteTable.Routes);
		}
	}
}
