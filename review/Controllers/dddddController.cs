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
    public class dddddController : Controller
    {
        private reviewmodeldb db = new reviewmodeldb();

        // GET: ddddd
        public ActionResult Index()
        {
            var reviews = db.Reviews.Include(r => r.Product).Include(r => r.user);
            return View(reviews.ToList());
        }

        // GET: ddddd/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                return Content("hello");
            }
            Review review = db.Reviews.Find(id);
            if (review == null)
            {
                return HttpNotFound();
            }
            return View(review);
        }

        // GET: ddddd/Create
        public ActionResult Create()
        {
            ViewBag.productId = new SelectList(db.Products, "Id", "productname");
            ViewBag.userId = new SelectList(db.Users, "id", "name");
            return View();
        }

        // POST: ddddd/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,content,rating,dape_post,productId,userId")] Review review)
        {
            if (ModelState.IsValid)
            {
                db.Reviews.Add(review);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.productId = new SelectList(db.Products, "Id", "productname", review.productId);
            ViewBag.userId = new SelectList(db.Users, "id", "name", review.userId);
            return View(review);
        }

        // GET: ddddd/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Review review = db.Reviews.Find(id);
            if (review == null)
            {
                return HttpNotFound();
            }
            ViewBag.productId = new SelectList(db.Products, "Id", "productname", review.productId);
            ViewBag.userId = new SelectList(db.Users, "id", "name", review.userId);
            return View(review);
        }

        // POST: ddddd/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,content,rating,dape_post,productId,userId")] Review review)
        {
            if (ModelState.IsValid)
            {
                db.Entry(review).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.productId = new SelectList(db.Products, "Id", "productname", review.productId);
            ViewBag.userId = new SelectList(db.Users, "id", "name", review.userId);
            return View(review);
        }

        // GET: ddddd/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Review review = db.Reviews.Find(id);
            if (review == null)
            {
                return HttpNotFound();
            }
            return View(review);
        }

        // POST: ddddd/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Review review = db.Reviews.Find(id);
            db.Reviews.Remove(review);
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
