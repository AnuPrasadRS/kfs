using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Catalog.Models;
using System.IO;

namespace Catalog.Controllers
{
    [SessionAuthorize(Roles = "Admin,vesselcrew")]

    public class AttendancesController : Controller
    {
        private CatalogEntities db = new CatalogEntities();

        // GET: Attendances
        public ActionResult Index()
        {
            var UserId = Convert.ToInt32(Session["UserID"]);

            var attendances = db.Attendances.Include(a => a.Login).Where(a => a.UserId == UserId);

            return View(attendances.ToList());
        }

        // GET: Attendances/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var UserId = Convert.ToInt32(Session["UserID"]);

            Attendance attendance = db.Attendances.Find(id);
            if (attendance == null)
            {
                return HttpNotFound();
            }
            if (attendance.UserId != UserId)
            {
                return HttpNotFound();

            }
            return View(attendance);
        }

        // GET: Attendances/Create
        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.Logins, "Id", "Username");
            return View();
        }

        // POST: Attendances/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Attendance attendance, HttpPostedFileBase FileUrl)
        {
            if (FileUrl == null || FileUrl.ContentLength <= 0)
            {
                ModelState.AddModelError("FileUrl", "Select File");
            }
            if (ModelState.IsValid)
            {
                if (FileUrl != null && FileUrl.ContentLength > 0)
                {
                    Random rnd = new Random();
                    int rand = rnd.Next(9999, 99999);
                    // extract only the filename
                    ///// var fileName = Path.GetFileName(Link.FileName);

                    var filenameonly = Path.GetFileNameWithoutExtension(FileUrl.FileName);
                    var fileName = filenameonly + rand + Path.GetExtension(FileUrl.FileName);
                    // store the file inside ~/App_Data/uploads folder
                    var path = Path.Combine(Server.MapPath("~/Attendance"), fileName);
                    FileUrl.SaveAs(path);
                    attendance.FileUrl = fileName;
                }
                attendance.UserId = Convert.ToInt32(Session["UserID"]);
                attendance.EnteredOn = DateTime.Now;

                db.Attendances.Add(attendance);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.Logins, "Id", "Username", attendance.UserId);
            return View(attendance);
        }

        // GET: Attendances/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Attendance attendance = db.Attendances.Find(id);
            if (attendance == null)
            {
                return HttpNotFound();
            }
            var UserId = Convert.ToInt32(Session["UserID"]);
            if (attendance.UserId != UserId)
            {
                return HttpNotFound();

            }
            ViewBag.UserId = new SelectList(db.Logins, "Id", "Username", attendance.UserId);
            return View(attendance);
        }

        // POST: Attendances/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Attendance attendance, HttpPostedFileBase FileUrl)
        {
            if (ModelState.IsValid)
            {
                Attendance attendancess = db.Attendances.Find(attendance.AttendanceId);
                var UserId = Convert.ToInt32(Session["UserID"]);
                if (attendancess.UserId != UserId)
                {
                    return HttpNotFound();

                }
                if (FileUrl != null && FileUrl.ContentLength > 0)
                {
                    Random rnd = new Random();
                    int rand = rnd.Next(9999, 99999);
                    // extract only the filename
                    ///// var fileName = Path.GetFileName(Link.FileName);

                    var filenameonly = Path.GetFileNameWithoutExtension(FileUrl.FileName);
                    var fileName = filenameonly + rand + Path.GetExtension(FileUrl.FileName);
                    // store the file inside ~/App_Data/uploads folder
                    var path = Path.Combine(Server.MapPath("~/Attendance"), fileName);
                    FileUrl.SaveAs(path);
                    attendancess.FileUrl = fileName;
                }
                attendancess.EnteredOn = DateTime.Now;
                attendancess.Description = attendance.Description;
                db.Entry(attendancess).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.Logins, "Id", "Username", attendance.UserId);
            return View(attendance);
        }

        // GET: Attendances/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Attendance attendance = db.Attendances.Find(id);
            if (attendance == null)
            {
                return HttpNotFound();
            }
            var UserId = Convert.ToInt32(Session["UserID"]);
            if (attendance.UserId != UserId)
            {
                return HttpNotFound();

            }
            return View(attendance);
        }

        // POST: Attendances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Attendance attendance = db.Attendances.Find(id);
            var UserId = Convert.ToInt32(Session["UserID"]);
            var Role = Session["Role"].ToString();
            if (attendance.UserId != UserId || Role != "Admin")
            {
                return HttpNotFound();

            }
            db.Attendances.Remove(attendance);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult DeleteCrewlist(int id)
        {
            Attendance attendance = db.Attendances.Find(id);
            var UserId = Convert.ToInt32(Session["UserID"]);
            var Role = Session["Role"].ToString();
            if (attendance.UserId != UserId && Role != "Admin")
            {
                return HttpNotFound();

            }
            db.Attendances.Remove(attendance);
            db.SaveChanges();
            return RedirectToAction("ViewAttendance");
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        public ActionResult ViewAttendance()
        {
            ViewBag.ShipId = new SelectList(db.Ships, "Id", "ShipName");
            return View();
        }
        public ActionResult GetAttendaceWithShipID(int val = 0)
        {
            if (val != 0)
            {
                var userId = db.UserToShips.Where(a => a.ShipId == val).Select(a => a.UserID).FirstOrDefault();
                var attendance = db.Attendances.Where(a => a.UserId == userId).OrderByDescending(a => a.AttendanceId).Take(3);

                List<AttendanceVM> frms = new List<AttendanceVM>();
                foreach (var item in attendance)
                {
                    AttendanceVM frmobj = new AttendanceVM();
                    frmobj.AttendanceId = item.AttendanceId;
                    frmobj.Description = item.Description;
                    frmobj.FileUrl = " <a href='/Attendance/" + item.FileUrl + "' target='_blank' class='btn btn-labeled btn - success'><span class='btn - label'><i class='fa fa-download'></i></span>Download</a>  ";
                    if (Session["Role"].ToString() == "Admin")
                    {
                        frmobj.deletelink = " <a href='/Attendances/DeleteCrewlist/" + item.AttendanceId + "' class='btn btn-labeled btn - success'><span class='btn - label'><i class='fa fa-download'></i></span>Delete</a>  ";
                    }
                    frms.Add(frmobj);
                }
                return Json(frms, JsonRequestBehavior.AllowGet);
            }
            return null;
        }
    }
}
