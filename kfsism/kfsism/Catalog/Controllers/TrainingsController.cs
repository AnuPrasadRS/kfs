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
    [SessionAuthorize(Roles = "Users,Admin,Assistant,Cordinator,shorestaff,vesselcrew")]

    public class TrainingsController : Controller
    {
        private CatalogEntities db = new CatalogEntities();

        // GET: Trainings
        public ActionResult Index()
        {
            int userid = Convert.ToInt32(Session["UserID"]);
            var trainings = db.Trainings.Where(a=>a.Entered_By==userid).Include(t => t.Login);
            return View(trainings.ToList());
        }

        // GET: Trainings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Training training = db.Trainings.Find(id);
            if (training == null)
            {
                return HttpNotFound();
            }
            var UserId = Convert.ToInt32(Session["UserID"]);
            if (training.Entered_By != UserId)
            {
                return HttpNotFound();

            }
            return View(training);
        }

        // GET: Trainings/Create
        public ActionResult Create()
        {
            ViewBag.Entered_By = new SelectList(db.Logins, "Id", "Username");
            return View();
        }

        // POST: Trainings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Training training, HttpPostedFileBase AttendanceSheet, HttpPostedFileBase EvaluationSheet)
        {
            //if (AttendanceSheet == null || AttendanceSheet.ContentLength <= 0)
            //{
            //    ModelState.AddModelError("AttendanceSheet", "Select File");
            //}
            //if (EvaluationSheet == null || EvaluationSheet.ContentLength <= 0)
            //{
            //    ModelState.AddModelError("EvaluationSheet", "Select File");
            //}

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
                    var path = Path.Combine(Server.MapPath("~/TrainingsFiles/Attendance"), fileName);
                    AttendanceSheet.SaveAs(path);
                    training.AttendanceSheet = fileName;
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
                    training.EvaluationSheet = fileName;
                }
                /*----------------------------File Upload-----------------------------------------*/
                training.Entered_By = Convert.ToInt32(Session["UserID"]);
                training.Entered_On = DateTime.Now;
                db.Trainings.Add(training);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Entered_By = new SelectList(db.Logins, "Id", "Username", training.Entered_By);
            return View(training);
        }

        // GET: Trainings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Training training = db.Trainings.Find(id);
            if (training == null)
            {
                return HttpNotFound();
            }
            var UserId = Convert.ToInt32(Session["UserID"]);
            if (training.Entered_By != UserId)
            {
                return HttpNotFound();

            }
            ViewBag.Entered_By = new SelectList(db.Logins, "Id", "Username", training.Entered_By);
            return View(training);
        }

        // POST: Trainings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Training training, HttpPostedFileBase AttendanceSheet, HttpPostedFileBase EvaluationSheet)
        {
            if (ModelState.IsValid)
            {
                Training tr = db.Trainings.Find(training.TrainingID);

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
                    training.AttendanceSheet = fileName;
                }
                else
                {
                   training.AttendanceSheet = tr.AttendanceSheet;
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
                    training.EvaluationSheet = fileName;
                }
                else
                {
                    training.EvaluationSheet = tr.EvaluationSheet;
                }
                /*----------------------------File Upload-----------------------------------------*/
                training.Entered_By = Convert.ToInt32(Session["UserID"]);
                training.Entered_On = DateTime.Now;
                db.Entry(tr).State = EntityState.Detached;

                db.Entry(training).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(training);
        }

        // GET: Trainings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Training training = db.Trainings.Find(id);
          
            if (training == null)
            {
                return HttpNotFound();
            }
            var UserId = Convert.ToInt32(Session["UserID"]);
            if (training.Entered_By != UserId)
            {
                return HttpNotFound();

            }
            return View(training);
        }

        // POST: Trainings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Training training = db.Trainings.Find(id);
            var UserId = Convert.ToInt32(Session["UserID"]);
            if (training.Entered_By != UserId)
            {
                return HttpNotFound();

            }
            db.Trainings.Remove(training);
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
