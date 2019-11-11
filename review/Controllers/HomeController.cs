using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using review.Models;
namespace review.Controllers
{
    public class HomeController : Controller
    {
        private reviewmodeldb db = new reviewmodeldb();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Search(string search)
        {
            //  return Content("Deb" + search);
            if (search == "")
            {
                ViewBag.flag = "false1";
            }
            else
            {
                if (db.Products.FirstOrDefault(d => d.productname.Contains(search)) == null)
                {
                    ViewBag.flag = "false2";
                }
                else
                {
                    var pt = db.Products.Where(d => d.productname.Contains(search)).ToList();

                    return View(pt);
                }
            }
            return View(db.Products.FirstOrDefault(d => d.productname == search));
        }
     
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}