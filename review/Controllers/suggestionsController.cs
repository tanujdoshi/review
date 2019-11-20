using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using review.Models;

namespace review.Controllers
{
    public class suggestionsController : Controller
    {
        private reviewmodeldb db = new reviewmodeldb();

        // GET: suggestions
        public ActionResult Index()
        {
            return View(db.suggestions.ToList());
        }

        // GET: suggestions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            suggestion suggestion = db.suggestions.Find(id);
            if (suggestion == null)
            {
                return HttpNotFound();
            }
            return View(suggestion);
        }

        // GET: suggestions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: suggestions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "sId,email,suggest")] suggestion suggestion)
        {
            if (ModelState.IsValid)
            {
                db.suggestions.Add(suggestion);
                db.SaveChanges();

                try
                {
                    if (ModelState.IsValid)
                    {
                        var senderEmail = new MailAddress("tanujdoshi3920@gmail.com", "Tanuj DOshi");
                        var receiverEmail = new MailAddress(suggestion.email, "Receiver");
                        var password = "tanuj3920";
                        var sub = "Thank You for your suggestion";
                        var body = "Thank you For Suggestion "+suggestion.suggest+"We are back with this very soon!!";
                        var smtp = new SmtpClient
                        {
                            Host = "smtp.gmail.com",
                            Port = 587,
                            EnableSsl = true,
                            DeliveryMethod = SmtpDeliveryMethod.Network,
                            UseDefaultCredentials = false,
                            Credentials = new NetworkCredential(senderEmail.Address, password)
                        };
                        using (var mess = new MailMessage(senderEmail, receiverEmail)
                        {
                            Subject = "Thank you",
                            Body = body
                        })
                        {
                            smtp.Send(mess);
                        }
                        Response.Write("<script>alert('Please Login Firs')</script>");
                        return View();
                    }
                }
                catch (Exception)
                {
                    ViewBag.Error = "Some Error";
                }


                return RedirectToAction("Index");
            }

            return View(suggestion);
        }

        // GET: suggestions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            suggestion suggestion = db.suggestions.Find(id);
            if (suggestion == null)
            {
                return HttpNotFound();
            }
            return View(suggestion);
        }

        // POST: suggestions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "sId,email,suggest")] suggestion suggestion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(suggestion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(suggestion);
        }

        // GET: suggestions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            suggestion suggestion = db.suggestions.Find(id);
            if (suggestion == null)
            {
                return HttpNotFound();
            }
            return View(suggestion);
        }

        // POST: suggestions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            suggestion suggestion = db.suggestions.Find(id);
            db.suggestions.Remove(suggestion);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
