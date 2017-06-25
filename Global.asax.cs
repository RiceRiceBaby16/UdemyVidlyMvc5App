﻿using CourseByMosh.App_Start;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace CourseByMosh
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AutoMapper.Mapper.Initialize(config => config.AddProfile<MappingProfile>());
            GlobalConfiguration.Configure(WebApiConfig.Register);
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
