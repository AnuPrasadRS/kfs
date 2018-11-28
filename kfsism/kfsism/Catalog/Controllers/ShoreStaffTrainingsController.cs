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
    public class ShoreStaffTrainingsController : Controller
    {
        private CatalogEntities db = new CatalogEntities();

        // GET: ShoreStaffTrainings
        public ActionResult Index()
        {
            int userid = Convert.ToInt32(Session["UserID"]);
            var ShoreStaffTrainings = db.ShoreStaffTrainings.Where(a => a.Entered_By == userid).Include(t => t.Login);
            return View(ShoreStaffTrainings.ToList());
        }

        // GET: ShoreStaffTrainings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShoreStaffTraining shoreStaffTraining = db.ShoreStaffTrainings.Find(id);
            if (shoreStaffTraining == null)
            {
                return HttpNotFound();
            }
            var UserId = Convert.ToInt32(Session["UserID"]);
            if (shoreStaffTraining.Entered_By != UserId)
            {
                return HttpNotFound();

            }
            return View(shoreStaffTraining);
        }

        // GET: ShoreStaffTrainings/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ShoreStaffTrainings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ShoreStaffTrainingID,AttendanceSheet,EvaluationSheet,Entered_On,Entered_By")] ShoreStaffTraining shoreStaffTraining, HttpPostedFileBase AttendanceSheet, HttpPostedFileBase EvaluationSheet)
        {
            if (ModelState.IsValid)
            {
                /*----------------------------File Upload-----------------------------------------*/
                if (AttendanceSheet != null && AttendanceSheet.ContentLength > 0)
                {
                    Random rnd = new Random();
                    int rand = rnd.Next(9999, 99999);
                    // extract only the filename
                    ///// var fileName = Path.GetFileName(Link.FileName);

                    var filenameonly = Path.GetFileNameWithoutExtension(AttendanceSheet.FileName);
                    var fileName = filenameonly + rand + Path.GetExtension(AttendanceSheet.FileName);
                    // store the file inside ~/App_Data/uploads folder
                    var path = Path.Combine(Server.MapPath("~/TrainingsFilesShoreStaff/Attendance"), fileName);
                    AttendanceSheet.SaveAs(path);
                    shoreStaffTraining.AttendanceSheet = fileName;
                }
                if (EvaluationSheet != null && EvaluationSheet.ContentLength > 0)
                {
                    Random rnd = new Random();
                    int rand = rnd.Next(9999, 99999);
                    // extract only the filename
                    ///// var fileName = Path.GetFileName(Link.FileName);

                    var filenameonly = Path.GetFileNameWithoutExtension(EvaluationSheet.FileName);
                    var fileName = filenameonly + rand + Path.GetExtension(EvaluationSheet.FileName);
                    // store the file inside ~/App_Data/uploads folder
                    var path = Path.Combine(Server.MapPath("~/TrainingsFilesShoreStaff/Evaluation"), fileName);
                    EvaluationSheet.SaveAs(path);
                    shoreStaffTraining.EvaluationSheet = fileName;
                }
                /*----------------------------File Upload-----------------------------------------*/
                shoreStaffTraining.Entered_By = Convert.ToInt32(Session["UserID"]);
                shoreStaffTraining.Entered_On = DateTime.Now;
                db.ShoreStaffTrainings.Add(shoreStaffTraining);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(shoreStaffTraining);
        }

        // GET: ShoreStaffTrainings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShoreStaffTraining shoreStaffTraining = db.ShoreStaffTrainings.Find(id);
            if (shoreStaffTraining == null)
            {
                return HttpNotFound();
            }
            var UserId = Convert.ToInt32(Session["UserID"]);
            if (shoreStaffTraining.Entered_By != UserId)
            {
                return HttpNotFound();

            }
            return View(shoreStaffTraining);
        }

        // POST: ShoreStaffTrainings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ShoreStaffTrainingID,AttendanceSheet,EvaluationSheet,Entered_On,Entered_By")] ShoreStaffTraining shoreStaffTraining, HttpPostedFileBase AttendanceSheet, HttpPostedFileBase EvaluationSheet)
        {
            if (ModelState.IsValid)
            {
                var shoreStaffTrainings = db.ShoreStaffTrainings.Find(shoreStaffTraining.ShoreStaffTrainingID);

                /*----------------------------File Upload-----------------------------------------*/
                if (AttendanceSheet != null && AttendanceSheet.ContentLength > 0)
                {
                    Random rnd = new Random();
                    int rand = rnd.Next(9999, 99999);
                    // extract only the filename
                    ///// var fileName = Path.GetFileName(Link.FileName);

                    var filenameonly = Path.GetFileNameWithoutExtension(AttendanceSheet.FileName);
                    var fileName = filenameonly + rand + Path.GetExtension(AttendanceSheet.FileName);
                    // store the file inside ~/App_Data/uploads folder
                    var path = Path.Combine(Server.MapPath("~/TrainingsFiles/Attendance"), fileName);
                    AttendanceSheet.SaveAs(path);
                    shoreStaffTraining.AttendanceSheet = fileName;
                }
                else
                {
                    shoreStaffTraining.AttendanceSheet = shoreStaffTrainings.AttendanceSheet;
                }
                if (EvaluationSheet != null && EvaluationSheet.ContentLength > 0)
                {
                    Random rnd = new Random();
                    int rand = rnd.Next(9999, 99999);
                    // extract only the filename
                    ///// var fileName = Path.GetFileName(Link.FileName);
                    var filenameonly = Path.GetFileNameWithoutExtension(EvaluationSheet.FileName);
                    var fileName = filenameonly + rand + Path.GetExtension(EvaluationSheet.FileName);
                    // store the file inside ~/App_Data/uploads folder
                    var path = Path.Combine(Server.MapPath("~/TrainingsFiles/Evaluation"), fileName);
                    EvaluationSheet.SaveAs(path);
                    shoreStaffTraining.EvaluationSheet = fileName;
                }
                else
                {
                    shoreStaffTraining.EvaluationSheet = shoreStaffTrainings.EvaluationSheet;
                }
                /*----------------------------File Upload-----------------------------------------*/
                shoreStaffTraining.Entered_By = Convert.ToInt32(Session["UserID"]);
                shoreStaffTraining.Entered_On = DateTime.Now;
                db.Entry(shoreStaffTrainings).State = EntityState.Detached;
                db.Entry(shoreStaffTraining).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(shoreStaffTraining);
        }

        // GET: ShoreStaffTrainings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShoreStaffTraining shoreStaffTraining = db.ShoreStaffTrainings.Find(id);
            if (shoreStaffTraining == null)
            {
                return HttpNotFound();
            }
            var UserId = Convert.ToInt32(Session["UserID"]);
            if (shoreStaffTraining.Entered_By != UserId)
            {
                return HttpNotFound();

            }
            return View(shoreStaffTraining);
        }

        // POST: ShoreStaffTrainings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ShoreStaffTraining shoreStaffTraining = db.ShoreStaffTrainings.Find(id);
            var UserId = Convert.ToInt32(Session["UserID"]);
            if (shoreStaffTraining.Entered_By != UserId)
            {
                return HttpNotFound();

            }
            db.ShoreStaffTrainings.Remove(shoreStaffTraining);
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
