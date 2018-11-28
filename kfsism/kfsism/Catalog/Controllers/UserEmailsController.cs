using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Catalog.Models;

namespace Catalog.Controllers
{
   [SessionAuthorize(Roles = "Admin")]
    public class UserEmailsController : Controller
    {
        private CatalogEntities db = new CatalogEntities();

        // GET: UserEmails
        public ActionResult Index()
        {
            var userEmails = db.UserEmails.Include(u => u.Login);
            return View(userEmails.ToList());
        }

        // GET: UserEmails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserEmail userEmail = db.UserEmails.Find(id);
            if (userEmail == null)
            {
                return HttpNotFound();
            }
            return View(userEmail);
        }

        // GET: UserEmails/Create
        public ActionResult Create()
        {
            ViewBag.LoginId = new SelectList(db.Logins.Where(a=>a.Role!="Admin"), "Id", "Username");
            return View();
        }

        // POST: UserEmails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,LoginId,Email")] UserEmail userEmail)
        {
            if (ModelState.IsValid)
            {
                userEmail.Entered = DateTime.Now;
                db.UserEmails.Add(userEmail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LoginId = new SelectList(db.Logins.Where(a => a.Id != 1), "Id", "Username", userEmail.LoginId);
            return View(userEmail);
        }

        // GET: UserEmails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserEmail userEmail = db.UserEmails.Find(id);
            if (userEmail == null)
            {
                return HttpNotFound();
            }
            ViewBag.LoginId = new SelectList(db.Logins.Where(a => a.Id != 1), "Id", "Username", userEmail.LoginId);
            return View(userEmail);
        }

        // POST: UserEmails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,LoginId,Email")] UserEmail userEmail)
        {
            if (ModelState.IsValid)
            {
                userEmail.Entered = DateTime.Now;
                db.Entry(userEmail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LoginId = new SelectList(db.Logins.Where(a => a.Id != 1), "Id", "Username", userEmail.LoginId);
            return View(userEmail);
        }

        // GET: UserEmails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserEmail userEmail = db.UserEmails.Find(id);
            if (userEmail == null)
            {
                return HttpNotFound();
            }
            return View(userEmail);
        }

        // POST: UserEmails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserEmail userEmail = db.UserEmails.Find(id);
            db.UserEmails.Remove(userEmail);
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
