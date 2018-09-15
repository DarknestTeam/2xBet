using _2xBet.BLL.Infrastructure;
using _2xBet.WEB.Util;
using Ninject;
using Ninject.Modules;
using Ninject.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace _2xBet.WEB
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // Внедрение зависимостей
            NinjectModule BLL_module = new  ServicesBLL_Module();
            NinjectModule serviceMod = new ServiceModule("DefaultConnection");
            var kernel = new StandardKernel(BLL_module, serviceMod);
            
            DependencyResolver.SetResolver(new  NinjectDependencyResolver(kernel));

        }
    }
}
