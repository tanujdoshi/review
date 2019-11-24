using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using review.Models;

namespace review.Controllers
{
    public class subcategoriesController : Controller
    {
        private reviewmodeldb db = new reviewmodeldb();

        // GET: subcategories
        public ActionResult Index()
        {
           
            return View(db.subcategories.ToList());
        }

        // GET: subcategories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var group = db.subcategories.Where(d => d.catId == id);
            return View(group);
        }
        public ActionResult Upload()
        {
            ViewBag.catt = db.categories.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase uploadfile)
        {
            if (uploadfile != null && uploadfile.FileName != "")
            {
                ViewBag.catt = db.categories.ToList();
                string pic = Path.GetFileName(uploadfile.FileName);
                string p = Path.Combine(Server.MapPath("~/Content/images/"), pic);
                uploadfile.SaveAs(p);
                ViewBag.fil = "~/Content/images/" + pic;

            }
            else
            {
                ViewBag.fil = "nullk";
            }
            return View("Create");
        }
        // GET: subcategories/Create
        public ActionResult Create()
        {
           ViewBag.catt = db.categories.ToList();
            return View();
        }

        // POST: subcategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,img,catId")] subcategory subcategory)
        {
            if (ModelState.IsValid)
            {
                db.subcategories.Add(subcategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(subcategory);
        }

        // GET: subcategories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            subcategory subcategory = db.subcategories.Find(id);
            if (subcategory == null)
            {
                return HttpNotFound();
            }
            return View(subcategory);
        }

        // POST: subcategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,img,catId")] subcategory subcategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(subcategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(subcategory);
        }

        // GET: subcategories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            subcategory subcategory = db.subcategories.Find(id);
            if (subcategory == null)
            {
                return HttpNotFound();
            }
            return View(subcategory);
        }

        // POST: subcategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            subcategory subcategory = db.subcategories.Find(id);
            db.subcategories.Remove(subcategory);
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
