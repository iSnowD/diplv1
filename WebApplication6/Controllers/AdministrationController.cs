using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication6.Model;
namespace WebApplication6.Controllers
{
    public class AdministrationController : DefaultController
    {


        public AdministrationController()
        {

          


        }
        // GET: Administration
        public ActionResult Index()
        {
            if (CurrentUser != null)
            {
                if (CurrentUser.InRoles("Administrator"))
                {
                    //  var users = Repository.Users.ToList();

                    return View();
                }
            }
            return Redirect("/Shared/Error");

        }



        public ActionResult DeleteUser(int  ID)
        {

            Repository.RemoveUser(ID);
           return Redirect("/Administration/UsersEdit");
        }

        public ActionResult UsersEdit()
        {
            if (CurrentUser != null)
            {
                if (CurrentUser.InRoles("Administrator"))
                {
                     var users = Repository.Users.ToList();

                    return View(users);
                }
            }
            return Redirect("/Shared/Error");
        }


        public ActionResult NewsEdit()
        {
            if (CurrentUser != null)
            {
                if (CurrentUser.InRoles("Administrator"))
                {
                    var users = Repository.News.ToList();

                    return View(users);
                }
            }
            return Redirect("/Shared/Error");
        }


        public ActionResult DeleteNew(int ID)
        {

            Repository.RemoveNew(ID);
            return Redirect("/Administration/NewsEdit");
        }


        public ActionResult AddNew()
        {
            var new1 = new News();
             
            return View(new1);
        }
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult AddNew(News new1)
        {
            new1.AddedDate = DateTime.Now;
            new1.UserID = CurrentUser.ID;
            Repository.CreateNew(new1);
            return Redirect("/Administration/NewsEdit");
        }
        public ActionResult HideChange(int id)
        {

            News cache = Repository.News.Where(p => p.ID == id).FirstOrDefault();
            if (cache.Hide == false) cache.Hide = true;
            else cache.Hide = false;
            Repository.UpdateNew(cache);
            return Redirect("/Administration/NewsEdit");
        }
        

    }
}