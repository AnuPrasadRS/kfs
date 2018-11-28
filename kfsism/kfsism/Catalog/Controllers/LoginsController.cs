using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Catalog.Models;
using System.Web.Security;
using Catalog.ViewModel;
using Catalog.Helpers;

namespace Catalog.Controllers
{

    public class LoginsController : Controller
    {
        private CatalogEntities db = new CatalogEntities();

        public PartialViewResult ShowLayoutMenu()
        {
            List<NLink> linklist = new List<NLink>();

            List<NcategoryVM> NcatgVmList = new List<NcategoryVM>();
            var model = (from a in db.NCategories
                         join b in db.NForms on a.NCtgID equals b.NCategory into ctgtm
                         select new NcategoryVM
                         {
                             NCtgID = a.NCtgID,
                             NCtgName=a.NCtgName,
                             Nforms = ctgtm.OrderBy(c=>c.Order_O).ToList()
                         }).ToList();
            return PartialView("~/Views/Shared/_maPartialView.cshtml", model);
        }
        [SessionAuthorize(Roles = "Admin,Assistant,Cordinator,shorestaff,vesselcrew")]

        // GET: Logins
        public ActionResult Index()
        {
            var data = db.Logins.GroupBy(x => x.Role).Select(g =>
                     new
                     {
                         Role = g.Key,
                         Count = g.Count()
                     }
            );
            string str = "";
            foreach (var item in data)
            {
                str += "['" + item.Role + "', " + item.Count + "],";
            }

            var data1 = db.Trainings.GroupBy(x => x.Entered_On.Value.Year).Select(g =>
                    new
                    {
                        Year = g.Key,
                        Count = g.Count()
                    }
           );
            string str1 = "";
            foreach (var item in data1)
            {
                str1 += "['" + item.Year + "', " + item.Count + "],";
            }
            ViewData["graphdata"] = str;
            ViewData["graphdata2"] = str1;
            ViewData["shipsc"] = db.Ships.Count();
            ViewData["shorestaffc"] = db.Logins.Where(a => a.Role == "shorestaff").Count();
            ViewData["vesselcrewc"] = db.Logins.Where(a => a.Role == "vesselcrew").Count();
            ViewData["Cordinatorc"] = db.Logins.Where(a => a.Role == "Cordinator").Count();


            return View();
        }
        [SessionAuthorize(Roles = "Admin,shorestaff,vesselcrew")]

        public ActionResult UserLists()
        {

            return View(db.Logins.ToList());
        }

        // GET: Logins/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Login login = db.Logins.Find(id);
            if (login == null)
            {
                return HttpNotFound();
            }
            return View(login);
        }
        [SessionAuthorize(Roles = "Admin")]
        // GET: Logins/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Logins/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [SessionAuthorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Username,Password,Role")] Login login)
        {
            if (ModelState.IsValid)
            {
                login.CreatedOn = DateTime.Now;
                db.Logins.Add(login);
                db.SaveChanges();
                return RedirectToAction("UserLists");
            }

            return View(login);
        }
        [SessionAuthorize(Roles = "Admin")]
        // GET: Logins/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Login login = db.Logins.Find(id);
            if (login == null)
            {
                return HttpNotFound();
            }
            return View(login);
        }
        [SessionAuthorize(Roles = "Admin")]
        // POST: Logins/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Username,Password,Role")] Login login)
        {
            if (ModelState.IsValid)
            {
                db.Entry(login).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("UserLists");
            }
            return View(login);
        }
        [SessionAuthorize(Roles = "Admin")]
        // GET: Logins/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Login login = db.Logins.Find(id);
            if (login == null)
            {
                return HttpNotFound();
            }
            return View(login);
        }
        [SessionAuthorize(Roles = "Admin")]
        // POST: Logins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                if (id != 1)
                {
                    Login login = db.Logins.Find(id);
                    db.Logins.Remove(login);
                    db.SaveChanges();
                }
            }
            catch (Exception)
            {

                return RedirectToAction("UserLists");
            }
            return RedirectToAction("UserLists");

        }
        [SessionAuthorize(Roles = "Admin")]
        public ActionResult ViewEnteredReport()
        {
            List<vessel_head> head = db.vessel_head.OrderBy(a => a.date).OrderByDescending(a => a.date).ToList();
            List<ReportViewModel> repmv = new List<ViewModel.ReportViewModel>();

            foreach (var item in head)
            {
                ReportViewModel rm = new ReportViewModel();
                rm.ShipsName = db.Ships.Where(a => a.Id == item.ShipsId).Select(a => a.ShipName).SingleOrDefault();
                rm.date = item.date;
                rm.EnteredBYNm = db.Logins.Where(a => a.Id == item.EnteredBY).Select(a => a.Username).SingleOrDefault();
                rm.id = item.id;
                rm.master = item.master;
                rm.type = item.type;
                repmv.Add(rm);
            }
            return View(repmv);
        }

        public ActionResult ExportExcelReport(int Id)
        {
            if (Id != 0)
            {
                ViewBag.Ships = new SelectList(db.Ships.ToList(), "Id", "ShipName");

                ReportHeadViewmodel headModel = new ViewModel.ReportHeadViewmodel();
                var vesselhead = db.vessel_head.Where(a => a.id == Id).SingleOrDefault();
                if (vesselhead != null)
                {
                    ViewBag.Viewform = true;
                    headModel.vesselhead = vesselhead;
                    headModel.ptwinspection = db.ptwinspections.Where(a => a.head_id == headModel.vesselhead.id).SingleOrDefault();
                    headModel.pob = db.pobs.Where(a => a.head_id == headModel.vesselhead.id).SingleOrDefault();
                    headModel.monthly_rob = db.monthly_rob.Where(a => a.head_id == headModel.vesselhead.id).SingleOrDefault();
                    headModel.monthly_activity = db.monthly_activity.Where(a => a.head_id == headModel.vesselhead.id).SingleOrDefault();
                    headModel.hseleadingindent = db.hseleadingindents.Where(a => a.head_id == headModel.vesselhead.id).SingleOrDefault();
                    headModel.hselaggingwaste = db.hselaggingwastes.Where(a => a.head_id == headModel.vesselhead.id).SingleOrDefault();
                    Response.AddHeader("Content-Disposition", "filename=thefilename.xls");
                    Response.ContentType = "application/vnd.ms-excel";
                    return View(headModel);
                }
            }
            return RedirectToAction("ViewEnteredReport");
        }



        [SessionAuthorize(Roles = "Admin,Cordinator")]
        [HttpGet]
        public ActionResult ViewReport(int id)
        {
            if (id != 0)
            {
                ViewBag.Ships = new SelectList(db.Ships.ToList(), "Id", "ShipName");

                ReportHeadViewmodel headModel = new ViewModel.ReportHeadViewmodel();
                var vesselhead = db.vessel_head.Where(a => a.id == id).SingleOrDefault();
                if (vesselhead != null)
                {
                    ViewBag.Viewform = true;
                    headModel.vesselhead = vesselhead;
                    headModel.ptwinspection = db.ptwinspections.Where(a => a.head_id == headModel.vesselhead.id).SingleOrDefault();
                    headModel.pob = db.pobs.Where(a => a.head_id == headModel.vesselhead.id).SingleOrDefault();
                    headModel.monthly_rob = db.monthly_rob.Where(a => a.head_id == headModel.vesselhead.id).SingleOrDefault();
                    headModel.monthly_activity = db.monthly_activity.Where(a => a.head_id == headModel.vesselhead.id).SingleOrDefault();
                    headModel.hseleadingindent = db.hseleadingindents.Where(a => a.head_id == headModel.vesselhead.id).SingleOrDefault();
                    headModel.hselaggingwaste = db.hselaggingwastes.Where(a => a.head_id == headModel.vesselhead.id).SingleOrDefault();
                    //Response.AddHeader("Content-Disposition", "filename=thefilename.xls");
                    //Response.ContentType = "application/vnd.ms-excel";
                    return View(headModel);

                }

            }

            return RedirectToAction("ViewEnteredReport");

        }
        [SessionAuthorize(Roles = "Admin,Cordinator")]
        [HttpGet]
        public ActionResult ViewReportToEXCEL(int id)
        {
            if (id != 0)
            {
                ViewBag.Ships = new SelectList(db.Ships.ToList(), "Id", "ShipName");

                ReportHeadViewmodel headModel = new ViewModel.ReportHeadViewmodel();
                var vesselhead = db.vessel_head.Where(a => a.id == id).SingleOrDefault();
                if (vesselhead != null)
                {
                    ViewBag.Viewform = true;
                    headModel.vesselhead = vesselhead;
                    headModel.ptwinspection = db.ptwinspections.Where(a => a.head_id == headModel.vesselhead.id).SingleOrDefault();
                    headModel.pob = db.pobs.Where(a => a.head_id == headModel.vesselhead.id).SingleOrDefault();
                    headModel.monthly_rob = db.monthly_rob.Where(a => a.head_id == headModel.vesselhead.id).SingleOrDefault();
                    headModel.monthly_activity = db.monthly_activity.Where(a => a.head_id == headModel.vesselhead.id).SingleOrDefault();
                    headModel.hseleadingindent = db.hseleadingindents.Where(a => a.head_id == headModel.vesselhead.id).SingleOrDefault();
                    headModel.hselaggingwaste = db.hselaggingwastes.Where(a => a.head_id == headModel.vesselhead.id).SingleOrDefault();
                    Response.AddHeader("Content-Type", "application/vnd.ms-excel");
                    Response.AddHeader("Content-Disposition", "attachment; filename=excelTest.xls");

                    return View("ViewReportToExcel", headModel);
                    //Response.AddHeader("Content-Disposition", "filename=thefilename.xls");
                    //Response.ContentType = "application/vnd.ms-excel";
                    ///   return View(headModel);
                    //return new PdfResult(headModel, "ViewReport");
                    //  return new Rotativa.ActionAsPdf("ViewReport", headModel);
                }

            }

            return RedirectToAction("ViewEnteredReport");

        }
        [SessionAuthorize(Roles = "Admin,Cordinator")]
        [HttpPost]
        public ActionResult MonthlyReportVessel(ReportViewModel report)
        {
            if (ModelState.IsValid)
            {
                ReportHelper RptHlp = new ReportHelper();
                int head_id = Convert.ToInt32(RptHlp.Update_vessel_head(report));
                if (head_id != 0)
                {
                    RptHlp.Update_ptwinspection(head_id, report);
                    RptHlp.Update_Pob(head_id, report);
                    RptHlp.Update_Monthly_Rob(head_id, report);
                    RptHlp.Update_Monthly_Activity(head_id, report);
                    RptHlp.Update_HseleadingIndent(head_id, report);
                    RptHlp.Update_HseLaggingwaste(head_id, report);
                }
                return RedirectToAction("ViewEnteredReport");

            }
            ViewBag.Ships = new SelectList(db.Ships.ToList(), "Id", "ShipName", report.ShipsId);
            return View();
        }
        [SessionAuthorize(Roles = "Admin")]
        public ActionResult ViewTraining()
        {
            IQueryable<Training> train;
            int userid = Convert.ToInt32(Session["UserID"]);
            if (Session["Role"].ToString() == "vesselcrew")
            {
                train = db.Trainings.Include(t => t.Login).Where(a => a.Entered_By == userid);
            }
            else
            {
                train = db.Trainings.Include(t => t.Login);

            }
            return View(train.ToList());
        }
        [SessionAuthorize(Roles = "Admin")]
        public ActionResult ViewVesselCrewAttnEvalution()
        {
            var ViewVesselCrewAttnEvalution = db.Trainings.Include(t => t.Login).OrderByDescending(a=>a.Entered_On);
            return View(ViewVesselCrewAttnEvalution.ToList());
        }
        [SessionAuthorize(Roles = "Admin")]
        public ActionResult ViewShorestaffCrewAttnEvalution()
        {
            var ViewShorestaffCrewAttnEvalution = db.ShoreStaffTrainings.Include(t => t.Login).OrderByDescending(a => a.Entered_On);
            return View(ViewShorestaffCrewAttnEvalution.ToList());
        }
        public ActionResult Logout()
        {
            string[] myCookies = Request.Cookies.AllKeys;
            foreach (string cookie in myCookies)
            {
                Response.Cookies[cookie].Expires = DateTime.Now.AddDays(-1);
            }
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Login");
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
