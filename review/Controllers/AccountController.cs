using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using review.Models;
namespace review.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(user model)
        {
            using (var context = new reviewmodeldb())
            {
                bool isValid = context.Users.Any(x => x.email == model.email && x.Password == model.Password);
                if (isValid)
                {
                    Session["email"] = model.email;
                    FormsAuthentication.SetAuthCookie(model.email, false);
                    return RedirectToAction("Index", "categories");
                }

                ModelState.AddModelError("", "Invalid username and password");
                return View();
            }
        }
        // GET: Register
        public ActionResult Registeruser()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Registeruser(user model)
        {
            try
            {
                var context = new reviewmodeldb();
                context.Users.Add(model);
                context.SaveChanges();



                return RedirectToAction("Login");
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
            {
                Exception raise = dbEx;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        string message = string.Format("{0}:{1}",
                            validationErrors.Entry.Entity.ToString(),
                            validationError.ErrorMessage);
                        // raise a new exception nesting  
                        // the current instance as InnerException  
                        raise = new InvalidOperationException(message, raise);
                    }
                }
                throw raise;
            }
            // return View();
        }
        public ActionResult Logout()
        {
            Session.Abandon();
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}