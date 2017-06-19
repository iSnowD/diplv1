﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication6.Model;
namespace WebApplication6.Controllers
{
    public class HomeController : DefaultController
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult UserLogin()
        {
            return View(CurrentUser);
        }

        public ActionResult News()
        {
            var news = Repository.News.ToList();
          
            return View(news);
        }


        public ActionResult AdminButton()
        {
             
            return View(CurrentUser);
        }

        public ActionResult Reviews()
        {

            return View();
        }
    }

}