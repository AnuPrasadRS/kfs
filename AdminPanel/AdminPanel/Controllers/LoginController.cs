using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dapper;
using AdminPanel.ViewModel;
using System.Data;
using System.Data.SqlClient;

namespace AdminPanel.Controllers
{
    public class LoginController : Controller
    {
        IDbConnection SqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["CatalogEntities"].ConnectionString);
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Login_VM User)
        {
       
            var result = SqlCon.ExecuteReader("SELECT * FROM Login where Username='"+ User.UserName+ "' AND Password='"+User.Password+"'");
            if (result.Read())
            {
                Session["ROLL"]  = result["Role"].ToString();
                return RedirectToAction("Home", "Home");
            }
            else
            {
                return RedirectToAction("Login");
            }
          
        }
    }
}