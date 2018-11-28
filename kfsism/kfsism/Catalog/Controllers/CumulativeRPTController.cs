using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Catalog.ViewModel;
using Catalog.Models;

namespace Catalog.Controllers
{
    [SessionAuthorize(Roles = "Admin,Assistant,Cordinator,shorestaff,vesselcrew")]

    public class CumulativeRPTController : Controller
    {

        private CatalogEntities db = new CatalogEntities();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult vessel_headVM_Read([DataSourceRequest]DataSourceRequest request)
        {
            db.Configuration.ProxyCreationEnabled = false;
            List<vessel_head> vessel_headvm = db.vessel_head.ToList();
            List<ReportHeadViewmodel> headModellist = new List<ViewModel.ReportHeadViewmodel>();

            foreach (var item in vessel_headvm)
            {
                ReportHeadViewmodel headModel = new ReportHeadViewmodel();

                headModel.vesselhead = item;
                headModel.vesselhead.vessel = db.Ships.Where(a => a.Id == item.ShipsId).Select(x => x.ShipName).SingleOrDefault();
                headModel.ptwinspection = db.ptwinspections.Where(a => a.head_id == item.id).SingleOrDefault();
                headModel.pob = db.pobs.Where(a => a.head_id == item.id).SingleOrDefault();
                headModel.monthly_rob = db.monthly_rob.Where(a => a.head_id == item.id).SingleOrDefault();
                headModel.monthly_activity = db.monthly_activity.Where(a => a.head_id == item.id).SingleOrDefault();
                headModel.hseleadingindent = db.hseleadingindents.Where(a => a.head_id == item.id).SingleOrDefault();
                headModel.hselaggingwaste = db.hselaggingwastes.Where(a => a.head_id == item.id).SingleOrDefault();
                headModellist.Add(headModel);

            }
            DataSourceResult result = headModellist.ToDataSourceResult(request, c => new ReportHeadViewmodel
            {
                vesselhead = c.vesselhead,
                pob = c.pob,
                hselaggingwaste = c.hselaggingwaste,
                hseleadingindent = c.hseleadingindent,
                monthly_activity = c.monthly_activity,
                monthly_rob = c.monthly_rob,
                ptwinspection = c.ptwinspection

            });

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Excel_Export_Save(string contentType, string base64, string fileName)
        {
            var fileContents = Convert.FromBase64String(base64);

            return File(fileContents, contentType, fileName);
        }

        [HttpPost]
        public ActionResult Pdf_Export_Save(string contentType, string base64, string fileName)
        {
            var fileContents = Convert.FromBase64String(base64);

            return File(fileContents, contentType, fileName);
        }
        public ActionResult Read_Categories([DataSourceRequest] DataSourceRequest request, int id)
        {
            var catgories = new List<CategoriesVM>
        {
         new CategoriesVM  { CatgName = "Alabaster Almonds1", CategID = id },
          new CategoriesVM  { CatgName = "Alabaster Almonds2", CategID =id },
            new CategoriesVM  { CatgName = "Alabaster Almonds3", CategID = id },
              new CategoriesVM  { CatgName = "Alabaster Almonds4", CategID = id },
       };
            //DataSourceResult result = (db.monthly_activity.Where(o => o.head_id == id).ToDataSourceResult(request, o => new Monthly_ActivityVM()
            //{
            //    anchoragemcr = o.anchoragemcr,
            //    downconsumption = o.downconsumption,
            //    berthconsumption = o.berthconsumption,
            //}));
            return Json(catgories.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }
        public ActionResult PerformanceReports()
        {
            return View();
        }
        [HttpPost]
        public ActionResult PerformanceReport(string btnsubmit,int year=0)
        {
            if (year != 0)
            {
                ViewData["year"] = year;
                db.Configuration.ProxyCreationEnabled = false;
                List<vessel_head> vessel_headvm = db.vessel_head.Where(x => x.date.Value.Year == year).ToList();
                var lists = vessel_headvm.GroupBy(x => x.date.Value.Month).Select(g => new
                {
                    Month = g.Key,
                    RecordIDs = g.Select(c => c.id)
                });

                List<ReportHeadViewmodel> headModellistSec = new List<ViewModel.ReportHeadViewmodel>();

                foreach (var item in lists)
                {
                    List<ReportHeadViewmodel> headModellist = new List<ViewModel.ReportHeadViewmodel>();

                    foreach (var item1 in item.RecordIDs)
                    {
                        ReportHeadViewmodel headModel = new ReportHeadViewmodel();

                        headModel.vesselhead = db.vessel_head.Where(x => x.id == item1).FirstOrDefault();
                        headModel.vesselhead.vessel = db.Ships.Where(a => a.Id == headModel.vesselhead.ShipsId).Select(x => x.ShipName).SingleOrDefault();
                        headModel.ptwinspection = db.ptwinspections.Where(a => a.head_id == headModel.vesselhead.id).SingleOrDefault();
                        headModel.pob = db.pobs.Where(a => a.head_id == headModel.vesselhead.id).SingleOrDefault();
                        headModel.monthly_rob = db.monthly_rob.Where(a => a.head_id == headModel.vesselhead.id).SingleOrDefault();
                        headModel.monthly_activity = db.monthly_activity.Where(a => a.head_id == headModel.vesselhead.id).SingleOrDefault();
                        headModel.hseleadingindent = db.hseleadingindents.Where(a => a.head_id == headModel.vesselhead.id).SingleOrDefault();
                        headModel.hselaggingwaste = db.hselaggingwastes.Where(a => a.head_id == headModel.vesselhead.id).SingleOrDefault();
                        headModellist.Add(headModel);

                    }
                    ReportHeadViewmodel headModelSectree = new ReportHeadViewmodel();
                    Helpers.ReportHelper helper = new Helpers.ReportHelper();
                    headModelSectree = helper.CalcSumForPerformance(headModellist);
                    headModelSectree.MonthFromDate = item.Month;
                  
                    headModellistSec.Add(headModelSectree);
                }
                if(btnsubmit=="Excel")
                {
                    ViewData["Excel"] = "True";
                      Response.AddHeader("Content-Type", "application/vnd.ms-excel");
                    Response.AddHeader("content-disposition", "attachment;filename=Performancereport.xls");

                }
                return View(headModellistSec);
            }
            return RedirectToAction("PerformanceReports");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
