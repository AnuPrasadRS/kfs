using Catalog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Catalog.Controllers
{
    [SessionAuthorize(Roles = "Users")]

    public class IMSManualController : Controller
    {
        private CatalogEntities db = new CatalogEntities();

        public ActionResult ShowDetails(int id = 0)
        {
            if (id == 0)
                RedirectToAction("Index", "Catalog");
            var model = (from a in db.NForms
                         join b in db.NLinks on a.Id equals b.NformId
                         where a.Id == id
                         select new NLinksVM
                         {
                             Nlink1 = b.Nlink1,
                             NformId = b.NformId,
                             NLinkId = b.NLinkId,
                             Norder=(b.Norder.HasValue)? b.Norder.Value:0,
                         }).OrderBy(d=>d.Norder).ToList();
            return View(model);
        }
        // GET: IMSManual
        public ActionResult Revision_History() { return View(); }
        public ActionResult Introduction() { return View(); }
        public ActionResult ImsManagement_Principles() { return View(); }
        public ActionResult GeneralManager_message() { return View(); }
        public ActionResult Scope() { return View(); }
        public ActionResult Exclusion() { return View(); }
        public ActionResult Vision_Mission() { return View(); }
        public ActionResult Company_Profile() { return View(); }
        public ActionResult Distribution() { return View(); }
        public ActionResult Structuture_Manual() { return View(); }
        public ActionResult Process_Interaction() { return View(); }
        public ActionResult Understanding_Needs() { return View(); }
        public ActionResult Organisation_Chart() { return View(); }
        public ActionResult Definitions_Abbreviations() { return View(); }
        public ActionResult IMS_Policy() { return View(); }
        public ActionResult Quality_Policy() { return View(); }
        public ActionResult Health_Safety() { return View(); }
        public ActionResult Environment_Protection() { return View(); }
        public ActionResult NonSmoking() { return View(); }
        public ActionResult Drug_Alcohol() { return View(); }
        public ActionResult HazardIdentification() { return View(); }
        public ActionResult AspectIdentification() { return View(); }
        public ActionResult Legal_OtherRequirements() { return View(); }
        public ActionResult Objectives_Targets() { return View(); }
        public ActionResult Resource_Roles() { return View(); }
        public ActionResult Purchase() { return View(); }
        public ActionResult Competency_Training() { return View(); }
        public ActionResult Communication_Participation() { return View(); }
        public ActionResult HR_Crewing() { return View(); }
        public ActionResult Operational_Control() { return View(); }
        public ActionResult Shipboard_Operations() { return View(); }
        public ActionResult Emergency_Response() { return View(); }
        public ActionResult Accident_Incident() { return View(); }
        public ActionResult Control_Nonconfirming() { return View(); }
        public ActionResult Corrective_Actions() { return View(); }
        public ActionResult Documented_Information() { return View(); }
        public ActionResult Records() { return View(); }
        public ActionResult Performance_Measurement() { return View(); }
        public ActionResult Internal_IMS() { return View(); }
        public ActionResult Management_Review() { return View(); }
        public ActionResult Monitoring_Measurement() { return View(); }
        public ActionResult Evaluation_Compliance() { return View(); }
        public ActionResult Store_Management() { return View(); }
        public ActionResult Chartering_Tendering() { return View(); }
        public ActionResult Information_Technology() { return View(); }
        public ActionResult Occupational_Health() { return View(); }
        public ActionResult Identification_Tracebility() { return View(); }
        public ActionResult Vendor_Subcontractor() { return View(); }
        public ActionResult Asset_Management() { return View(); }

    }
}