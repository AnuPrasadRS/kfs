using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Catalog.Models;
using Catalog.ViewModel;
using System.IO;

namespace Catalog.Controllers
{
    public class FormsUploadController : Controller
    {
        private CatalogEntities db = new CatalogEntities();
        [SessionAuthorize(Roles = "Admin,Assistant,Cordinator")]

        // GET: FormsUpload
        public ActionResult Index()
        {
            ViewBag.Category = new SelectList(db.Categories, "Category_ID", "Name");

            return View(db.Forms.ToList());
        }
        public ActionResult JsonForms(int val = 0)
        {
            ViewBag.Categories = new SelectList(db.Categories.ToList(), "Category_ID", "Name");

            var collection = db.Forms.ToList();
            if (val != 0)
            {
                collection = db.Forms.Where(a => a.Category == val).ToList();
            }

            List<FormViewModel> frms = new List<FormViewModel>();
            foreach (var item in collection)
            {
                FormViewModel frmobj = new FormViewModel();
                frmobj.Id = item.Id;
                frmobj.Name = item.Name;
                frmobj.Link = " <a href='/Files/" + item.Link + "' target='_blank' class='btn btn-labeled btn - success'><span class='btn - label'><i class='fa fa-download'></i></span>Download</a>  ";

                if (Session["Role"].ToString() == "Admin")
                {
                    frmobj.Action = " <a href='/FormsUpload/Delete/" + item.Id + "' class='btn btn-labeled btn - warning'><span class='btn - label'><i class='fa fa-download'></i></span>Delete</a>  ";
                }
                else
                {
                    frmobj.Action = " ";

                }
                frms.Add(frmobj);
            }
            return Json(frms, JsonRequestBehavior.AllowGet);

        }

        // GET: FormsUpload/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Form form = db.Forms.Find(id);
            if (form == null)
            {
                return HttpNotFound();
            }
            return View(form);
        }

        // GET: FormsUpload/Create
        public ActionResult Create()
        {
            ViewBag.Category = new SelectList(db.Categories, "Category_ID", "Name");
            return View();
        }

        // POST: FormsUpload/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name,Link,Category")] Form form, HttpPostedFileBase Link)
        {
            if (ModelState.IsValid)
            {
                if (Link != null && Link.ContentLength > 0)
                {
                    Random rnd = new Random();
                    int rand = rnd.Next(9999, 99999);
                    // extract only the filename
                    ///// var fileName = Path.GetFileName(Link.FileName);

                    var filenameonly = Path.GetFileNameWithoutExtension(Link.FileName);
                    var fileName = filenameonly + rand + Path.GetExtension(Link.FileName);
                    // store the file inside ~/App_Data/uploads folder
                    var path = Path.Combine(Server.MapPath("~/Files/Uploads"), fileName);
                    Link.SaveAs(path);
                    form.Link = "Uploads/" + fileName;
                }

                db.Forms.Add(form);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Category = new SelectList(db.Categories, "Category_ID", "Name", form.Category);

            return View(form);
        }

        // GET: FormsUpload/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Form form = db.Forms.Find(id);
            if (form == null)
            {
                return HttpNotFound();
            }
            return View(form);
        }

        // POST: FormsUpload/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Link,Order_O,Category")] Form form)
        {
            if (ModelState.IsValid)
            {
                db.Entry(form).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(form);
        }

        // GET: FormsUpload/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Form form = db.Forms.Find(id);
            if (form == null)
            {
                return HttpNotFound();
            }
            return View(form);
        }

        // POST: FormsUpload/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Form form = db.Forms.Find(id);
            db.Forms.Remove(form);
            string fullPath = Request.MapPath("~/Files/" + form.Link);
            if (System.IO.File.Exists(fullPath))
            {
                System.IO.File.Delete(fullPath);
            }
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
