using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MStrudel.WebUI
{
	public class RouteConfig
	{
		public static void RegisterRoutes(RouteCollection routes)
		{
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

			routes.MapRoute(null, "Cat{categoryId}", new { controller = "Product", action = "Index", page = 1 });

			routes.MapRoute(null, "Page{page}", new { controller = "Product", action = "Index", categoryId = (int?)null });

			routes.MapRoute(null, "Cat{categoryId}/Page{page}", new { controller = "Product", action = "Index" });

			routes.MapRoute(null, "Category/Index", new { controller = "Category", action = "Index" });

			routes.MapRoute(
				name: "Default",
				url: "{controller}/{action}/{id}",
				defaults: new { controller = "Product", action = "Index", id = UrlParameter.Optional }
			);
		}
	}
}
