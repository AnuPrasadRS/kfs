using Catalog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Catalog.Controllers
{
    [SessionAuthorize(Roles = "Users,Cordinator")]
    public class CatalogController : Controller
    {
        CatalogEntities db = new CatalogEntities();
       
        // GET: Catalog
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Login");
        }
       
        public ActionResult DownloadForms()
        {
            return View();
        }
       
        public ActionResult UploadForms()
        {
            return View();
        }
       
        public ActionResult Level1()
        {
            return View();
        }
       
        public ActionResult RevisionHistory()
        {
            return View();
        }
       
        public ActionResult Introduction()
        {
            return View();
        }
       
        public ActionResult Scope()
        {
            return View();
        }
       
        public ActionResult AscpectIdentification()
        {
            return View();
        }
       
        public ActionResult ApplicationForms()
        {
            ViewBag.Categories = new SelectList(db.Categories.ToList(), "Category_ID", "Name");
            return View(db.Forms.ToList());
        }
       
        public ActionResult JsonForms(int val)
        {
            
            var collection = db.Forms.ToList();
            if (val != 0)
            {
                collection = db.Forms.Where(a => a.Category == val).ToList();
            }

            List<Form> frms = new List<Form>();
            foreach (var item in collection)
            {
                Form frmobj = new Form();
                frmobj.Id = item.Id;
                frmobj.Name = item.Name;
                frmobj.Link = " <a href='/Files/" + item.Link + "' target='_blank' class='btn btn-labeled btn - success'><span class='btn - label'><i class='fa fa-download'></i></span>Download</a>  ";
                frms.Add(frmobj);
            }
            return Json(frms, JsonRequestBehavior.AllowGet);

        }
       
        public ActionResult IMSIndex()
        {
            return View();
        }
       
        //public ActionResult IMSRevision_History()
        //{
        //    return View();
        //}
       
        //public ActionResult IMSIntroduction()
        //{
        //    return View();
        //}
       
        //public ActionResult IMS_IMS_Mgmt_Priciples_Aim()
        //{
        //    return View();
        //}
       
        //public ActionResult IMS_Gneral_Manager_Message()
        //{
        //    return View();
        //}
       
        //public ActionResult IMS_Scope()
        //{
        //    return View();
        //}
        //public ActionResult IMSExclusion()
        //{
        //    return View();
        //}
       
        //public ActionResult IMS_Vision_Mission()
        //{
        //    return View();
        //}
       
        //public ActionResult IMS_Company_Profile()
        //{
        //    return View();
        //}
       
        //public ActionResult IMSDistribution()
        //{
        //    return View();
        //}
       
        //public ActionResult IMSCompany_Profile()
        //{
        //    return View();
        //}
       
        //public ActionResult IMS_Structure_of_the_Manual()
        //{
        //    return View();
        //}
       
        //public ActionResult IMSProcess_Interaction()
        //{
        //    return View();
        //}
       
        //public ActionResult IMS_UNderstanding_and_Expectations()
        //{
        //    return View();
        //}
       
        //public ActionResult IMSOrganiation_Chart()
        //{
        //    return View();
        //}
       
        //public ActionResult IMS_Defenistions_Abbrevations()
        //{
        //    return View();
        //}
       
        //public ActionResult IMS_IMS_Policy()
        //{
        //    return View();
        //}
       
        //public ActionResult IMS_Quallity_Policy()
        //{
        //    return View();
        //}



        //public ActionResult IMSHealth_Safety_Policy()
        //{
        //    return View();
        //}
        //public ActionResult IMS_Environment_Protector_Policy()
        //{
        //    return View();
        //}
        //public ActionResult IMSNon_Smoking_Policy()
        //{
        //    return View();
        //}
        //public ActionResult IMSDrug_Alcohol_Policy()
        //{
        //    return View();
        //}
        //public ActionResult IMS_Hazard_Identification()
        //{
        //    return View();
        //}
        //public ActionResult IMSAspect_Identification()
        //{
        //    return View();
        //}
        //public ActionResult IMSLegal_Requirements()
        //{
        //    return View();
        //}
        //public ActionResult IMSObjectives_Targets()
        //{
        //    return View();
        //}
        //public ActionResult IMSResources_Roles_Responsibility()
        //{
        //    return View();
        //}
        //public ActionResult IMSPurchase()
        //{
        //    return View();
        //}
        //public ActionResult IMSCompetency_Training()
        //{
        //    return View();
        //}
        //public ActionResult IMS_Communication_Participation()
        //{
        //    return View();
        //}
        //public ActionResult IMSHR_Crewing()
        //{
        //    return View();
        //}
        //public ActionResult IMSOperational_Control()
        //{
        //    return View();
        //}
        //public ActionResult IMSShip_Board_Operations()
        //{
        //    return View();
        //}
        //public ActionResult IMSEmergency_Reponse()
        //{
        //    return View();
        //}
        //public ActionResult IMSAccident_Investigation()
        //{
        //    return View();
        //}
        //public ActionResult IMSNon_Confirming_Service()
        //{
        //    return View();
        //}
        //public ActionResult IMSCorrective_Action()
        //{
        //    return View();
        //}
        //public ActionResult IMSDocumented_Information()
        //{
        //    return View();
        //}
        //public ActionResult IMSRecords()
        //{
        //    return View();
        //}
        //public ActionResult IMSPerformace_Measurement()
        //{
        //    return View();
        //}
        //public ActionResult IMSInternal_IMS_Audit()
        //{
        //    return View();
        //}
        //public ActionResult IMSMangement_Review()
        //{
        //    return View();
        //}
        //public ActionResult IMSMonitoring_Measurement()
        //{
        //    return View();
        //}
        //public ActionResult IMSEvaluation_Complaince()
        //{
        //    return View();
        //}
        //public ActionResult IMSStore_Management()
        //{
        //    return View();
        //}
        //public ActionResult IMSChartering_Tendering()
        //{
        //    return View();
        //}
        //public ActionResult IMSInformation_Technology()
        //{
        //    return View();
        //}

        //public ActionResult IMSOccupational_Health_Mgmnt()
        //{
        //    return View();
        //}
        //public ActionResult IMSIdentification_Tracability()
        //{
        //    return View();
        //}
        //public ActionResult IMSVendor_Subcontract_Mgmmnt()
        //{
        //    return View();
        //}
        //public ActionResult IMSAsset_Mgmnt()
        //{
        //    return View();
        //}
    }
}