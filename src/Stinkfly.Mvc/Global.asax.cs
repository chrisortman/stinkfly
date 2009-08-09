using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Stinkfly.Mvc.Framework;

namespace Stinkfly.Mvc {
	// Note: For instructions on enabling IIS6 or IIS7 classic mode, 
	// visit http://go.microsoft.com/?LinkId=9394801

	public class MvcApplication : System.Web.HttpApplication {
		public static void RegisterRoutes(RouteCollection routes) {
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

			routes.Define(rd =>
			              	{
			              		rd.Connect("hello/{name}",opts => opts.Default("Controller","Hello")
																															.Default("Action","Hello"));
			              		rd.Connect("{controller}/{action}/{id}");
			              	});
			//routes.MapRoute(
			//  "Hello",
			//  "hello/{name}",
			//  new {controller = "Home", action = "Hello"}
			//  );

			//routes.MapRoute(
			//    "Default",                                              // Route name
			//    "{controller}/{action}/{id}",                           // URL with parameters
			//    new { controller = "Home", action = "Index", id = "" }  // Parameter defaults
			//);

			

		}

		protected void Application_Start() {
			RegisterRoutes(RouteTable.Routes);
		}
	}
}