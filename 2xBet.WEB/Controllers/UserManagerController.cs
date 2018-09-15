using _2xBet.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Owin.Security;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.AspNet.Identity;



namespace _2xBet.WEB.Controllers
{
    public class UserManagerController : Controller
    {

        private IUserService UserService
        {
            get
            {
                return HttpContext.GetOwinContext.GetUserManger<IUserService>();

            }
        }

        // GET: UserManager
        [HttpGet]
        public ActionResult ChangePassword()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangePassword(ChangePassword model )
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
           // var result ; /// подумай оовине и как это сделать
            else
            {

            }
        }
        public ActionResult ()
        { }

    }
}