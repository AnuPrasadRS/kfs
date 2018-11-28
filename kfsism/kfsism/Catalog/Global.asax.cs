using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Catalog
{
    public class MvcApplication : System.Web.HttpApplication
    {

        protected void Application_Start()
        {
           // GlobalFilters.Filters.Add(new MyActionFilterAttribute());

            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
        void Session_Start(object sender, EventArgs e)
        {
            Session.Timeout = 60;
        }
    }
}
