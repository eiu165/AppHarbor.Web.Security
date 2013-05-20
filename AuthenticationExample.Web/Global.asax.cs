using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using AppHarbor.Web.Security;
using AuthenticationExample.Web.Mvc;
using Auth.Data.PersistenceSupport;
using StructureMap;
using Auth.Business;

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
			ControllerBuilder.Current.SetControllerFactory(new StructureMapControllerFactory());
            
            ObjectFactory.Configure(x => x.ForRequestedType<IUserRepository>().TheDefaultIsConcreteType<InMemoryUserRepository>());
            ObjectFactory.Configure(x => x.ForRequestedType<ICookieAuthenticationConfiguration>().TheDefaultIsConcreteType<ConfigFileAuthenticationConfiguration>());
            ObjectFactory.Configure(x => x.ForRequestedType<IAuthenticator>().TheDefaultIsConcreteType<CookieAuthenticator>());
            ObjectFactory.Configure(x => x.ForRequestedType<IAccountService>().TheDefaultIsConcreteType<AccountService>()); 
            ObjectFactory.Initialize(x => 
            {
				x.For<HttpContextBase>().Use(() => new HttpContextWrapper(HttpContext.Current)); 
			});
              

			AreaRegistration.RegisterAllAreas();

			RegisterRoutes(RouteTable.Routes);
		}
	}
}
