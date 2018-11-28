using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dapper;
using AdminPanel.ViewModel;
using System.IO;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using AdminPanel.Models;
namespace AdminPanel.Controllers
{
    
    public class HomeController : Controller
    {
        catalog1Entities db = new catalog1Entities();
        IDbConnection SqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["CatalogEntities"].ConnectionString);
        public ActionResult Home()
        {
            Bind();
            return View();
        }
        public ActionResult ManageItems()
        {
            Bind();
            return View();
        }
        public void Bind()
        {
            var rslt = SqlCon.Query<Upload_VM>("SELECT * FROM NCategory").ToList();
            var result3 = new SelectList(rslt, "NCtgID", "NCtgName");
            ViewData["NCtgID"] = result3;
        }
        [HttpPost]
        public ActionResult Home(Upload_VM VM)
        {
            try
            {

                string sql = @"INSERT INTO NForms (Name, NCategory)VALUES(@Name,@NCtgID);SELECT CAST(SCOPE_IDENTITY() AS INT)";
                int rslt = SqlCon.Query<int>(sql, new { Name = VM.Name, NCtgID = VM.NCtgID }).Single();
                foreach (var item in VM.File)
                {
                    if (item.ContentType.ToLower() != "image/jpg" &&
                   item.ContentType.ToLower() != "image/jpeg" &&
                   item.ContentType.ToLower() != "image/pjpeg" &&
                   item.ContentType.ToLower() != "image/gif" &&
                   item.ContentType.ToLower() != "image/x-png" &&
                   item.ContentType.ToLower() != "image/png")
                    {
                        TempData["Message"] = "File upload failed!! Only image Filees allowed";
                        return RedirectToAction("Home");

                    }
                    var fileName = Path.GetFileName(item.FileName);
                    var rondom = Guid.NewGuid() + fileName;

                    var folderpath = @"C:\HostingSpaces\kfsimsmc\kfsimsm.com\wwwroot\Uploaded\"+VM.NCtgID+"\\"+rondom;
                    //   var path = Path.Combine(Server.MapPath(folderpath + "/" + VM.NCtgID), rondom);
                    item.SaveAs(folderpath);
                    SqlCon.Query("INSERT INTO NLinks (NformId, Nlink)VALUES("+rslt+", '/"+VM.NCtgID+"/"+rondom+"')");
                }
                TempData["Message"] = "File Uploaded Successfully!!";

            }
            catch (Exception ex)
            {
                TempData["Message"] = "File upload failed!!" + ex.Message;
            }
            return RedirectToAction("Home");
        }

        public ActionResult Category_Read([DataSourceRequest]DataSourceRequest request)
        {
            var result = (from a in db.NCategories
                          select new Upload_VM
                          {
                              NCtgID=a.NCtgID,
                              NCtgName=a.NCtgName
                          }
                          ).ToList().OrderBy(d => d.NCtgID);            
            return Json(result.ToDataSourceResult(request),JsonRequestBehavior.AllowGet);
        }
        public ActionResult Form_Read([DataSourceRequest]DataSourceRequest request, int id)
        {
            var result = (from a in db.NForms
                          where a.NCategory == id
                          select new Upload_VM
                          {   Id=a.Id,
                              Name = a.Name                              
                          }
                          ).ToList().OrderBy(d => d.Order_O);
            return Json(result.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }
        public ActionResult Form_Update([DataSourceRequest]DataSourceRequest request, List<Entity_Forms> ListItem)
        {
            foreach (var item in ListItem.ToList())
            {
                var feature = db.NForms
                                     .Where(h => h.Id == item.Id).ToList();
                feature.ForEach(a => a.Order_O = item.Order_O);
            }
            db.SaveChanges();
            return Json(request, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult Form_Delete([DataSourceRequest]DataSourceRequest request, int id)
        {
            var result = db.NForms.FirstOrDefault(s => s.Id == id);
            if (result != null)
            {
                db.NForms.Remove(result);
                db.SaveChanges();
            }
            return Json(result);
        }
        public ActionResult NLinks_Read([DataSourceRequest]DataSourceRequest request, int id)
        {
            var result = (from a in db.NLinks
                          where a.NformId == id
                          select new Upload_VM
                          {
                              NLinkId = a.NLinkId,
                              Nlink=a.Nlink1
                          }
                          ).ToList();
            return Json(result.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }
        public ActionResult Link_Update([DataSourceRequest]DataSourceRequest request, List<Entity_Links> ListItem)
        {
            foreach (var item in ListItem.ToList())
            {
                var feature = db.NLinks
                                     .Where(h => h.NLinkId == item.NLinkId).ToList();
                feature.ForEach(a => a.Norder = item.Norder);
            }
            db.SaveChanges();
            return Json(request, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult Link_Delete([DataSourceRequest]DataSourceRequest request, int id)
        {
            var result = db.NLinks.FirstOrDefault(s => s.NLinkId == id);
            if (result != null)
            {
                db.NLinks.Remove(result);
                db.SaveChanges();
            }
            return Json(result);
        }
    }
}