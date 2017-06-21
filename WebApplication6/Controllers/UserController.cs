using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication6.Model;
using WebApplication6.Mappers;
using WebApplication6.Models;

namespace WebApplication6.Controllers

{
    public class UserController : DefaultController
    {

        [Inject]
        
        // GET: User
        public ActionResult Index()
        {
            return View();
        }
        
        [HttpGet]
        public ActionResult Register()
        {
            var newUser = new  UserView();
            return View(newUser);
        }

        [HttpPost]
        public ActionResult Register(UserView userView)
        {

            var anyUser = Repository.Users.Any(p => string.Compare(p.Email, userView.Email) == 0);
            if (anyUser)
            {
                ModelState.AddModelError("Email", "Пользователь с таким email уже зарегистрирован");
            }

            if (ModelState.IsValid)
            {
               var  ModelMapper = new CommonMapper();
                var user = (User)ModelMapper.Map(userView, typeof(UserView), typeof(User));

                Repository.CreateUser(user);
                return RedirectToAction("Index");
            }

            return View(userView);

        }



    }
}