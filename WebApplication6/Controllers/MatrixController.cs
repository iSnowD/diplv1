using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication6.Model;
namespace WebApplication6.Controllers
{
    public class MatrixController : Controller
    {
        // GET: Matrix
        public ActionResult Index()
        {
            return View();
        }



        [HttpGet]
        public ActionResult calc()
        {
            var data = new Model.MatrixView();
            return View(data);
        }

        [HttpPost]
        public ActionResult calc(Model.MatrixView data)
        {


             
           
                int[] p = new int[6];
            if(data.m11!=null)  p[0] =   Int32.Parse(data.m11);
            if (data.m12 != null) p[1] = Int32.Parse(data.m12);
            if (data.m22 != null) p[2] = Int32.Parse(data.m22);
            if (data.m32 != null) p[3] = Int32.Parse(data.m32);
            if (data.m42 != null) p[4] = Int32.Parse(data.m42);
            if (data.m52 != null) p[5] = Int32.Parse(data.m52);

            //     MatrixChain go1=new MatrixChain();

            //   go1.multiplyOrder(p);

            data.result = MatrixChain.multiplyOrder(p).ToString();
            return View(data);
        }




    }
}