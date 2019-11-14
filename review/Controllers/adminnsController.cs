using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using review.Models;

namespace review.Controllers
{
    public class adminnsController : Controller
    {
        private reviewmodeldb db = new reviewmodeldb();

        // GET: adminns
        public ActionResult Index()
        {
            return View(db.Admins.ToList());
        }

        // GET: adminns/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            adminn adminn = db.Admins.Find(id);
            if (adminn == null)
            {
                return HttpNotFound();
            }
            return View(adminn);
        }

        // GET: adminns/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: adminns/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Adminid,email,password")] adminn adminn)
        {
            if (ModelState.IsValid)
            {
                db.Admins.Add(adminn);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(adminn);
        }

        // GET: adminns/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            adminn adminn = db.Admins.Find(id);
            if (adminn == null)
            {
                return HttpNotFound();
            }
            return View(adminn);
        }

        // POST: adminns/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Adminid,email,password")] adminn adminn)
        {
            if (ModelState.IsValid)
            {
                db.Entry(adminn).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(adminn);
        }

        // GET: adminns/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            adminn adminn = db.Admins.Find(id);
            if (adminn == null)
            {
                return HttpNotFound();
            }
            return View(adminn);
        }

        // POST: adminns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            adminn adminn = db.Admins.Find(id);
            db.Admins.Remove(adminn);
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
