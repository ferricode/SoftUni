﻿using BasicWebServer.Server.Attributes;
using BasicWebServer.Server.Controllers;
using BasicWebServer.Server.HTTP;
using FootballManager.Contracts;
using FootballManager.Models;
using FootballManager.Models.Users;

namespace FootballManager.Controllers
{
    public class UsersController : Controller
    {

        private readonly IUserService userService;

        public UsersController(
            Request request,
            IUserService _userService)
            : base(request)
        {
            userService = _userService;
        }
      
        public Response Login()
        {
            if (User.IsAuthenticated)
            {
                return Redirect("/");

            }

            return View(new { IsAuthenticated = false });

        }

        public Response Register()
        {
            if (User.IsAuthenticated)
            {
                // return Redirect("/Players/All");
                return Redirect("/Users/Login");

            }


            return View(new { IsAuthenticated = false });
        }


        [HttpPost]
        public Response Register(RegisterViewModel model)
        {
            var (isValid, errors) = userService.ValidateRegisterModel(model);

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
                return View(new List<ErrorViewModel>() { new ErrorViewModel("Unexpected Error") }, "/Error");
            }

            return Redirect("/Users/Login");
        }

        [HttpPost]
        public Response Login(LoginViewModel model)
        {
            Request.Session.Clear();

            (string userId, bool isCorrect) = userService.IsLoginCorrect(model);

            if (isCorrect)
            {
                SignIn(userId);

                CookieCollection cookies = new CookieCollection();
                cookies.Add(Session.SessionCookieName,
                    Request.Session.Id);

                return Redirect("/");
                //return Redirect("/Players/All");
            }

            return View(new List<ErrorViewModel>() { new ErrorViewModel("Login incorrect") }, "/Error");
        }

        [Authorize]
        public Response Logout()
        {
            SignOut();

            return Redirect("/");
        }
    }
}