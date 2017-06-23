using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication6.Model;
namespace WebApplication6.Controllers
{
    public class AdministrationController : BaseController
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

                    return Redirect("/Administration/Visits");
                }
            }
            return Redirect("/Shared/Error");

        }



        public ActionResult DeleteUser(int ID)
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
                    users.Reverse();
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

     

        [HttpGet]
        public ActionResult EditUser(int id)
        {
            User tmp = Repository.Users.Where(p => p.ID == id).FirstOrDefault();

            return View(tmp);

        }

        [HttpPost]
        public ActionResult EditUser(User temp)
        {

            Repository.UpdateUser(temp);
           
            return Redirect("/Administration/UsersEdit");

        }




        public ActionResult Visits()
        {
            if (CurrentUser != null)
            {
                if (CurrentUser.InRoles("Administrator"))
                {
                    var visits = Repository.Visits.ToList();

                    return View(visits);
                }
            }
            return Redirect("/Shared/Error");
        }

        public ActionResult Visitscheck(int id)
        {
            Visits cache = Repository.Visits.Where(p => p.ID == id).FirstOrDefault();
            if (cache.IsVisited == false) cache.IsVisited = true;
            else cache.IsVisited = false;
            Repository.UpdateVisit(cache);         
            return Redirect("/Administration/Visits");
        }

 
 


        public ActionResult AddVisit()
        {
            //  ) Set your data to a List()
            //2) Set the data - list to a ViewBag object (ViewBag.datalist = myData;)
            //3) Create your dropdown: @Html.DropDownList("MyDataList", new SelectList(ViewBag.datalist, "ValueColumn", "TextDisplayColumn"))
            var users = Repository.Users.ToList();
            ViewBag.datalist = users;
            var services = Repository.Services.ToList();
            ViewBag.servicelist = services;

            var times = Repository.Times.ToList();
            ViewBag.timeslist = times;

            return View();
        }
        [HttpPost]
        public ActionResult AddVisit(Visits visit)
        {

            Repository.CreateVisit(visit);

            return Redirect("/Administration/Visits");
        }
    }
}