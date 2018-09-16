using _2xBet.BLL.DTO;
using _2xBet.BLL.Infrastructure;
using _2xBet.BLL.Interfaces;
using _2xBet.WEB.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace _2xBet.WEB.Controllers
{
    public class AccountController : Controller
    {
        IUserService userservice;
        public AccountController(IUserService service)
        {
            userservice = service;
        }
        // GET: Account
        [AllowAnonymous]
        public ActionResult login()
        {
            return PartialView();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model)
        {
            var userDTO = new UserDTO { User_Id = model.User_Id, Login = model.Login, Password = model.Password };
            if (!ModelState.IsValid)
            {
                return PartialView(model);
            }

            return PartialView(model);
        }
        [AllowAnonymous]
        public ActionResult Register()
        {
            return PartialView();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterViewModel model)
        {
            try
            {
                var userDTO = new UserDTO { User_Id = model.User_Id, Email = model.Email, Login = model.Login, Password = model.Password };
                userservice.MakeUser(userDTO);
                return Content("<h2>Регистрация прошла успешно</h2>");
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            return PartialView(model);
        }
    }
}