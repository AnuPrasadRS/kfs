using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Catalog.ViewModel;
using Catalog.Models;
using Catalog.Helpers;

namespace Catalog.Controllers
{
    [SessionAuthorize(Roles = "vesselcrew,shorestaff")]
    public class ReportController : Controller
    {
        CatalogEntities db = new CatalogEntities();
        // GET: Report
        public ActionResult MonthlyReportVessel()
        {
            ViewBag.Ships = new SelectList(db.Ships.ToList(), "Id", "ShipName");
            return View();
        }
        [HttpPost]
        public ActionResult MonthlyReportVessel(ReportViewModel report)
        {
            if (ModelState.IsValid)
            {
                report.EnteredBY= Convert.ToInt32(Session["UserID"]);
                ReportHelper RptHlp = new ReportHelper();
                int head_id = Convert.ToInt32(RptHlp.Add_vessel_head(report));
                if (head_id != 0)
                {
                    RptHlp.Add_ptwinspection(head_id, report);
                    RptHlp.Add_Pob(head_id, report);
                    RptHlp.Add_Monthly_Rob(head_id, report);
                    RptHlp.Add_Monthly_Activity(head_id, report);
                    RptHlp.Add_HseleadingIndent(head_id, report);
                    RptHlp.Add_HseLaggingwaste(head_id, report);
                }
                return RedirectToAction("ViewEnteredReport");
              
            }
            ViewBag.Ships = new SelectList(db.Ships.ToList(), "Id", "ShipName", report.ShipsId);
            return View();
        }
      
        public ActionResult _VesselHead()
        {
            return View();
        }
        public ActionResult _MonthlyActivitySummary()
        {
            return View();
        }
        public ActionResult _MonthlyROB()
        {
            return View();
        }
        public ActionResult _POB()
        {
            return View();
        }
        public ActionResult _HSELeading()
        {
            return View();
        }
        public ActionResult _HSELeading_Incident()
        {
            return View();
        }
        public ActionResult _HSELagging_WasteProdc()
        {
            return View();
        }
        public ActionResult _Permit_Inspection_Remark()
        {
            return View();
        }
        public ActionResult ViewEnteredReport()
        {
            List<ReportViewModel> repmv = new List<ViewModel.ReportViewModel>();
            int user_id = Convert.ToInt32(Session["UserID"]);
            var head = db.vessel_head.Where(m => m.EnteredBY == user_id).OrderBy(a=>a.date).ToList();
            if (head != null)
            {

                foreach (var item in head)
                {
                    ReportViewModel rm = new ReportViewModel();
                    rm.ShipsName = db.Ships.Where(a => a.Id == item.ShipsId).Select(a => a.ShipName).Single();
                    rm.date = item.date;
                    rm.id = item.id;
                    rm.master = item.master;
                    rm.type = item.type;
                    repmv.Add(rm);
                }
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

        [HttpGet]
        public ActionResult ViewReport(int id)
        {
            if (id != 0)
            {
                ViewBag.Ships = new SelectList(db.Ships.ToList(), "Id", "ShipName");

                ReportHeadViewmodel headModel = new ViewModel.ReportHeadViewmodel();
                int user_id = Convert.ToInt32(Session["UserID"]);
                var vesselhead = db.vessel_head.Where(m => m.EnteredBY == user_id).Where(a => a.id == id).SingleOrDefault();
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
                    return View(headModel);
                }

            }
            return RedirectToAction("ViewEnteredReport");

        }
        public ActionResult CumilativeRpt()
        {
            return View();
        }
    }
}