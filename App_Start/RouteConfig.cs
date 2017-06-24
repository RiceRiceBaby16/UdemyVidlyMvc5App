using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CourseByMosh
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapMvcAttributeRoutes();

            //// define routes from most specific to generic *** THIS IS CONVENTION-BASED ROUTING ***
            //routes.MapRoute(
            //    "MoviesByReleaseDate",//name
            //    "movies/released/{year}/{month}",//url
            //    new { controller = "Movies", action = "ByReleaseDate" },//defaults
            //    //new { year = @"\d{4}", month = @"\d{2}" });// constraints => regex for 4-digit year and 2-digit month
            //    new { year = @"2016|2017", month = @"\d{2}" });// constraints

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
