using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using AppHarbor.Web.Security; 
using AuthenticationExample.Castle.Web.Infastructure;
using Castle.Windsor;
using AuthenticationExample.Castle.Web.PersistenceSupport;
using Castle.MicroKernel.Registration;

namespace AuthenticationExample.Castle.Web
{
	public class MvcApplication : System.Web.HttpApplication
    {

        public static IWindsorContainer _container;

		public static void RegisterRoutes(RouteCollection routes)
		{
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
			routes.IgnoreRoute("{*favicon}", new { favicon = @"(.*/)?favicon.ico(/.*)?" });

            routes.MapRoute(
                "Default", // Route name

                "{controller}/{action}/{id}", // URL with parameters

                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
                , new string[] { "AuthenticationExample.Castle.Web.Controllers" }
            );
		}

		protected void Application_Start()
        {
            BootstrapContainer();
             

			AreaRegistration.RegisterAllAreas();

			RegisterRoutes(RouteTable.Routes);
		}



        private static void BootstrapContainer()
        {
            _container = new WindsorContainer();
            var controllerFactory = new WindsorControllerFactory(_container.Kernel);
            ControllerBuilder.Current.SetControllerFactory(controllerFactory);



            _container.Install(
                //new CommonInstaller(),
                new ControllersInstaller()
                );


            _container.Register(Component.For<IRepository>().ImplementedBy<InMemoryRepository>().LifeStyle.Singleton);
            _container.Register(Component.For<ICookieAuthenticationConfiguration>().ImplementedBy<ConfigFileAuthenticationConfiguration>().LifeStyle.PerWebRequest);
            _container.Register(Component.For<IAuthenticator>().ImplementedBy<CookieAuthenticator>().LifeStyle.PerWebRequest);

        }


	}
}
