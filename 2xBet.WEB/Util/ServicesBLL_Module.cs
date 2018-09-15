using _2xBet.BLL.Interfaces;
using _2xBet.BLL.Services;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _2xBet.WEB.Util
{
    public class ServicesBLL_Module: NinjectModule
    {
        public override void Load()
        {
            Bind<IBetService>().To<BetService>();
            Bind<IUserService>().To<UserService>();
            Bind<ICardService>().To<CardService>();
            Bind<ICoefficentService>().To<CoefficentService>();
            Bind<IMatchService>().To<MatchService>();
        }
    }
}