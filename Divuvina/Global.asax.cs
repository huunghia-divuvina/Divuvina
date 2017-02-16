using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Divuvina
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //Config globalization.
            //---------------------------
            Configuration config = WebConfigurationManager.OpenWebConfiguration("/");
            var globalizationSection = config.GetSection("system.web/globalization") as GlobalizationSection;
            CultureInfo culture = new CultureInfo(globalizationSection.Culture);
            CultureInfo uiCulture = new CultureInfo(globalizationSection.UICulture);
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = uiCulture;

            //---------------------------
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            
        }
        //protected void Application_BeginRequest(object sender, EventArgs e)
        //{
        //    var globalizationSection = WebConfigurationManager.GetSection("globalization") as GlobalizationSection;
        //    CultureInfo culture = new CultureInfo(globalizationSection.Culture);
        //    CultureInfo uiCulture = new CultureInfo(globalizationSection.UICulture);
        //    Thread.CurrentThread.CurrentCulture = culture;
        //    Thread.CurrentThread.CurrentUICulture = uiCulture;
        //}
    }
}
