using Catalog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Catalog.ViewModel;
using Catalog.Views.ViewModel;
using System.Data.Entity;
using System.Net.Mime;
using System.Threading.Tasks;
using System.Net;

namespace Catalog.Controllers
{
    public class SessionAuthorizeAttribute : AuthorizeAttribute
    {
        public new string Roles { get; set; }

        public bool stat = false;
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            string UserID = null;
            string Role = null;
            string Username = null;
            HttpCookie cookieObj = HttpContext.Current.Request.Cookies["mybigcookie"];

            //--- Check for null 
            if (cookieObj != null)
            {
                //--- To read values from cookie collection we will use Keys used while creating cookie.
                UserID = cookieObj["UserID"];
                Role = cookieObj["Role"];
                Username = cookieObj["Username"];
            }
            #region session
            //if ((HttpContext.Current.Session["UserID"] == null) || (HttpContext.Current.Session["Role"] == null))
            //{
            //    return false;
            //}
            //string[] values = Roles.Split(',');
            //try
            //{
            //    stat = false;
            //    if (HttpContext.Current.Session["Role"] != null)
            //    {
            //        if (values.Contains("Users"))
            //        {
            //            return true;
            //        }
            //        else
            //        {
            //            this.stat = true;
            //            var CurrentRole = HttpContext.Current.Session["Role"].ToString().Trim();

            //            foreach (var role in values)
            //            {
            //                if (CurrentRole.Contains(role.Trim()))
            //                {
            //                    stat = true;
            //                }
            //            }
            //            /* for (int i = 0; i < values.Length; i++)
            //                 {
            //                     string session_role = HttpContext.Current.Session["Role"]. ToString();
            //                     if (values[i].Trim().ToLower() == session_role.Trim().ToLower())
            //                     {
            //                         stat = true;
            //                     }
            //                 }*/
            //        }
            //    }
            //    return stat;
            //}
            //catch (Exception)
            //{

            //    return stat;
            //}
            #endregion
            if ((UserID == null) || (Role == null))
            {
                return false;
            }
            string[] values = Roles.Split(',');
            try
            {
                HttpContext.Current.Session["Role"] = Role;
                HttpContext.Current.Session["UserID"] = UserID;
                HttpContext.Current.Session["Username"] = Username;
                stat = false;
                if (HttpContext.Current.Session["Role"] != null)
                {
                    if (values.Contains("Users"))
                    {
                        return true;
                    }
                    else
                    {
                        this.stat = true;
                        var CurrentRole = HttpContext.Current.Session["Role"].ToString().Trim();

                        foreach (var role in values)
                        {
                            if (CurrentRole.Contains(role.Trim()))
                            {
                                stat = true;
                            }
                        }
                        /* for (int i = 0; i < values.Length; i++)
                             {
                                 string session_role = HttpContext.Current.Session["Role"]. ToString();
                                 if (values[i].Trim().ToLower() == session_role.Trim().ToLower())
                                 {
                                     stat = true;
                                 }
                             }*/
                    }
                }
                return stat;
            }
            catch (Exception)
            {

                return stat;
            }
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {


            if (HttpContext.Current.Session["Role"] == null)
            {
                base.HandleUnauthorizedRequest(filterContext);
            }
            else
            {
                filterContext.Result = new RedirectResult("/NotAuthorized");

            }

        }
    }

    //public static class GlobalVariables
    //{
    //    // readonly variable
    //    public static string UserID
    //    {
    //        get
    //        {
    //            return FormsAuthentication.Decrypt(HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName].Value).Name.Split('|')[0];
    //        }
    //    }
    //    public static string Role
    //    {
    //        get
    //        {
    //            return FormsAuthentication.Decrypt(HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName].Value).Name.Split('|')[1];
    //        }
    //    }
    //}

    public class LoginController : Controller
    {
        CatalogEntities db = new CatalogEntities();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AdminLogin()
        {
            return View();
        }
        public ActionResult ForgotPassword()
        {
            Random rnd = new Random();
            int Code = rnd.Next(111111, 999999);
            var admin_rec = db.Logins.Where(a => a.Role == "Admin").FirstOrDefault();
            admin_rec.Code = Code.ToString();
            admin_rec.Code_Created = DateTime.Now;
            db.Entry(admin_rec).State = EntityState.Modified;
            db.SaveChanges();
            Send_Email("qhse@khalidfarajshipping.com", "Reset Pssword Code", "Please use " + Code + " code to reset the Admin Password ");
            return View();
        }
        [HttpPost]
        public ActionResult ForgotPassword(ForgotPassViewmodel login)
        {
            if (string.IsNullOrEmpty(login.Code))
            {
                ModelState.AddModelError("Code", "Code is required");
            }
            if (string.IsNullOrEmpty(login.CNFPassword))
            {
                ModelState.AddModelError("CNFPassword", "Confirm Password is required");
            }
            string error = null;
            if (ModelState.IsValid)
            {
                var admin_rec = db.Logins.Where(a => a.Role == "Admin" && a.Code == login.Code).FirstOrDefault();
                if (admin_rec != null)
                {
                    DateTime dt = Convert.ToDateTime(admin_rec.Code_Created);
                    TimeSpan span = dt.Subtract(DateTime.Now);

                    if (span.Minutes < 10)
                    {
                        admin_rec.Password = login.CNFPassword;
                        admin_rec.Code = "";
                        db.Entry(admin_rec).State = EntityState.Modified;
                        db.SaveChanges();
                        return RedirectToAction("AdminLogin", "Login");
                    }
                    error = "Expired Code";
                }
                error = error == null ? "Incorrect Code" : error;
                ModelState.AddModelError("Code", error);
            }
            return View();
        }
        [HttpPost]
        public ActionResult AdminLogin(AdminLogin login)
        {
            if (ModelState.IsValid)
            {
                var credential = db.Logins.Where(a => a.Username == login.Username && a.Password == login.Password).FirstOrDefault();
                // User found in the database
                if (credential != null)
                {
                    if (credential.Role == "Admin")
                    {
                        FormsAuthentication.SetAuthCookie(credential.Id + "|" + credential.Role, false);

                        Session["UserID"] = credential.Id;
                        Session["Role"] = credential.Role;
                        Session["Username"] = credential.Username;

                        HttpCookie cookie = new HttpCookie("mybigcookie");
                        cookie.Values.Add("UserID", credential.Id.ToString());
                        cookie.Values.Add("Role", credential.Role);
                        cookie.Values.Add("Username", credential.Username);
                        Response.Cookies.Add(cookie);
                        return RedirectToAction("Index", "Logins");
                    }
                }
                ModelState.AddModelError("Password", "Invalid Credentials");
            }
            return View();
        }
        [HttpPost]
        public ActionResult Index(Login login)
        {
            if (login.Username == null && login.Password == null)
            {
                ModelState.AddModelError("Username", "Enter Username");
                ModelState.AddModelError("Password", "Enter Password");
                return View(login);
            }
            else if (login.Username != null && login.Password == null)
            {
                var cred = db.Logins.Where(a => a.Username == login.Username).Where(a => a.Role != "Admin").FirstOrDefault();
                if (cred != null && cred.Id != 1)
                {
                    if (SendEmail(cred.Id))
                    {
                        TempData["EmailRequested"] = "Requested";
                        ModelState.AddModelError("Password", "Enter Password From Email");
                        return View(login);
                    }
                    ModelState.AddModelError("Username", "Error In Sending Password to Email");
                    return View(login);
                }
                ModelState.AddModelError("Username", "Invalid User");
                return View(login);
            }

            var crede = db.Logins.Where(a => a.Username == login.Username).FirstOrDefault();
            if (crede != null)
            {
                if (checkEmailPassword(login.Password, crede.Id))
                {
                    HttpCookie cookie = new HttpCookie("mybigcookie");
                    cookie.Values.Add("UserID", crede.Id.ToString());
                    cookie.Values.Add("Role", crede.Role);
                    cookie.Values.Add("Username", crede.Username);
                    Response.Cookies.Add(cookie);

                    Session["UserID"] = crede.Id;
                    Session["Role"] = crede.Role;
                    Session["Username"] = crede.Username;
                    FormsAuthentication.SetAuthCookie(crede.Id + "|" + crede.Role, true);
                    if (crede.Role != "Users")
                    {
                        return RedirectToAction("Index", "Logins");
                    }
                    return RedirectToAction("Index", "Catalog");
                }
                else
                {
                    TempData["EmailRequested"] = "Requested";
                    ModelState.AddModelError("Password", "Incorrect or Expired Password");
                    return View(login);
                }
            }
            ModelState.AddModelError("Username", "Invalid Credentials");
            return View(login);

            //return View(login);
        }
        public bool SendEmail(int Login)
        {
            try
            {
                List<UserEmail> useremails = new List<Models.UserEmail>();
                useremails = db.UserEmails.Where(a => a.LoginId == Login).ToList();
                if (useremails == null)
                    return false;
                Random rnd = new Random();
                int password = rnd.Next(111111, 999999);
                AddEmailPassword(Login, password);
                foreach (var item in useremails)
                {
                    MailMessage mail = new MailMessage();
                    mail.To.Add(item.Email);
                    mail.From = new MailAddress("admin@developer.com");
                    mail.Subject = "Password For Login";
                    string Body = "<b>Please use " + password + " to Login your Account";
                    //  string Body = Body;
                    mail.IsBodyHtml = true;
                    ContentType mimeType = new System.Net.Mime.ContentType("text/html");
                    AlternateView alternate = AlternateView.CreateAlternateViewFromString(Body, mimeType);
                    mail.AlternateViews.Add(alternate);
                    SmtpClient smtp = new SmtpClient();
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new System.Net.NetworkCredential
                    ("anuqutof@gmail.com", "asdf1234567");// Enter seders User name and password
                    smtp.EnableSsl = true;

                    smtp.Send(mail);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public async Task<string> SendMail(string Body, string Subject, string Email)
        {

            var message = new MailMessage();
            message.To.Add(new MailAddress("princeprasad90@gmail.com"));
            message.From = new MailAddress("anuqutof@gmail.com");
            message.Subject = Subject;

            message.Body = "Hello";
            message.IsBodyHtml = true;
            using (var smtp = new SmtpClient())
            {
                var credential = new NetworkCredential
                {
                    UserName = "anuqutof@gmail.com",  // replace with valid value
                    Password = "asdf123456"  // replace with valid value
                };
                smtp.Credentials = credential;
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 25;
                smtp.EnableSsl = false;
                smtp.Send(message);
                smtp.Dispose();
                message.Dispose();
                await smtp.SendMailAsync(message);
            }
            return "";
        }

        public bool AddEmailPassword(int LoginId, int password)
        {
            try
            {
                ///   db.EmailPasswords.RemoveRange(db.EmailPasswords.Where(x => x.LoginId == LoginId));
                //     db.SaveChanges();
                var credential = db.Logins.Where(a => a.Id == LoginId).FirstOrDefault();
                credential.CreatedOn = DateTime.Now;
                credential.Password = password.ToString();
                db.Entry(credential).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }
        public bool checkEmailPassword(string password, int Login_ID)
        {
            try
            {
                var crede = db.Logins.Where(a => a.Id == Login_ID).Where(a => a.Password == password).FirstOrDefault();
                if (crede != null)
                {
                    TimeSpan span = DateTime.Now.Subtract((DateTime)crede.CreatedOn);
                    if (span.Minutes < 10)
                        return true;
                }
                return false;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public bool Send_Email(string ToEmail, string subject, string body)
        {
            try
            {
                MailMessage mail = new MailMessage();
                mail.To.Add(ToEmail);
                mail.From = new MailAddress("admin@developer.com");
                mail.Subject = subject;
                // string Body = "<b>Please use " + password + " to Login your Account";
                //  string Body = Body;
                mail.IsBodyHtml = true;
                ContentType mimeType = new System.Net.Mime.ContentType("text/html");
                AlternateView alternate = AlternateView.CreateAlternateViewFromString(body, mimeType);
                mail.AlternateViews.Add(alternate);
                SmtpClient smtp = new SmtpClient();
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = new System.Net.NetworkCredential
                ("anuqutof@gmail.com", "asdf123456");// Enter seders User name and password
                smtp.EnableSsl = true;
                smtp.Send(mail);
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }
    }
}