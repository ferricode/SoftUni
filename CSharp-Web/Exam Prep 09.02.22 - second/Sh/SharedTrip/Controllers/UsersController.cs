﻿
using BasicWebServer.Server.Attributes;
using BasicWebServer.Server.Controllers;
using BasicWebServer.Server.HTTP;
using SharedTrip.Contracts;
using SharedTrip.Data.Models.Users;
using SharedTrip.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedTrip.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserService userService;
        public UsersController(Request request, IUserService _useerService) 
            : base(request)
        {
            userService = _useerService;
        }
        public Response Login()
        {
            if (User.IsAuthenticated)
            {
                return Redirect("/Trips/All");
            }
            return View();
        }
        public Response Register()
        {
            if (User.IsAuthenticated)
            {
                return Redirect("/Trips/All");
            }
            return View();
        }

        [HttpPost]
        public Response Register(RegisterViewModel model)
        {
            var(isValid, errors)=userService.ValidateModel(model);
            
            if (!isValid)
            {
                return View(errors, "/Error");
            }
           

            try
            {
                userService.RegisterUser(model);
            }
            catch (ArgumentException aex)
            {
                return View(new List<ErrorViewModel>() { new ErrorViewModel(aex.Message) }, "/Error");
            }
            catch (Exception)
            {
                return View(new List<ErrorViewModel>() {new ErrorViewModel("Unexpected Error") }, "/Error");
            }

            return Redirect("/Users/Login");
        }
        public Response Login(loginViewModel model)
        {
            Request.Session.Clear();

            (string userId, bool isCorrect) = userService.IsLoginCorrect(model);
            if (isCorrect)
            {
                SignIn(userId);

                CookieCollection cookies = new CookieCollection();
                cookies.Add(Session.SessionCookieName,
                    Request.Session.Id);



                return Redirect("/Trips/All");
            }

            return View(new List<ErrorViewModel>() { new ErrorViewModel("Login incorect") }, "/Error");
        }
        [Authorize]
        public Response Logout()
        {
            SignOut();
            return Redirect("/");
        }

    }
}