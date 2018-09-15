using _2xBet.BLL.Interfaces;
using Microsoft.Owin;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

[assembly: OwinStartup(typeof(_2xBet.WEB.App_Start.Startup))]

namespace _2xBet.WEB.App_Start
{
    public class Startup
    {
         private IUserService UserService;

        public void Configuration(IAppBuilder app)
        {
            app.CreatePerOwinContext<>

        }
        
    }
}