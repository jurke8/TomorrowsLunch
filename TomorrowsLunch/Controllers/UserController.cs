using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TommorowsLunch.Providers;
using TomorrowsLunch.Models;
using System.Web.Http;
using System.Net.Http;

namespace TomorrowsLunch.Controllers
{
    public class UserController : ApiController
    {
        private UserRepository userRepository;

        public UserController()
        {
            this.userRepository = new UserRepository();
        }
        public User Create()
        {
            return (User)userRepository.Create(new User());
        }
        public HttpResponseMessage Post(User user)
        {
            this.userRepository.Create(user);

            var response = Request.CreateResponse<User>(System.Net.HttpStatusCode.Created, user);

            return response;
        }
        //public ActionResult Login()
        //{
        //    ViewBag.ShowLogin = false;
        //    return View();
        //}
        //public ActionResult Registration()
        //{
        //    ViewBag.ShowLogin = true;
        //    return View();
        //}

    }
}