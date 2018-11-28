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

    public class UserToShipsController : Controller
    {
        private CatalogEntities db = new CatalogEntities();

        // GET: UserToShips
        public ActionResult Index()
        {
            var userToShips = db.UserToShips.Include(u => u.Login).Include(u => u.Ship);
            return View(userToShips.ToList());
        }

        // GET: UserToShips/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserToShip userToShip = db.UserToShips.Find(id);
            if (userToShip == null)
            {
                return HttpNotFound();
            }
            return View(userToShip);
        }

        // GET: UserToShips/Create
        public ActionResult Create()
        {
            var addedUser = db.UserToShips.Select(a=>a.UserID).ToList();
            var addedShips = db.UserToShips.Select(a => a.ShipId).ToList();

            ViewBag.UserID = new SelectList(db.Logins.Where(a=>a.Role== "vesselcrew").Where(a=>!addedUser.Contains(a.Id)), "Id", "Username");
            ViewBag.ShipId = new SelectList(db.Ships.Where(a => !addedShips.Contains(a.Id)), "Id", "ShipName");
            return View();
        }

        // POST: UserToShips/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,UserID,ShipId")] UserToShip userToShip)
        {
            if (ModelState.IsValid)
            {
                userToShip.EnteredOn = DateTime.Now;
                db.UserToShips.Add(userToShip);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserID = new SelectList(db.Logins, "Id", "Username", userToShip.UserID);
            ViewBag.ShipId = new SelectList(db.Ships, "Id", "ShipName", userToShip.ShipId);
            return View(userToShip);
        }

        // GET: UserToShips/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserToShip userToShip = db.UserToShips.Find(id);
            if (userToShip == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserID = new SelectList(db.Logins, "Id", "Username", userToShip.UserID);
            ViewBag.ShipId = new SelectList(db.Ships, "Id", "ShipName", userToShip.ShipId);
            return View(userToShip);
        }

        // POST: UserToShips/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,UserID,ShipId")] UserToShip userToShip)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userToShip).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserID = new SelectList(db.Logins, "Id", "Username", userToShip.UserID);
            ViewBag.ShipId = new SelectList(db.Ships, "Id", "ShipName", userToShip.ShipId);
            return View(userToShip);
        }

        // GET: UserToShips/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserToShip userToShip = db.UserToShips.Find(id);
            if (userToShip == null)
            {
                return HttpNotFound();
            }
            return View(userToShip);
        }

        // POST: UserToShips/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserToShip userToShip = db.UserToShips.Find(id);
            db.UserToShips.Remove(userToShip);
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
