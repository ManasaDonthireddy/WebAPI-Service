using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace Capsule_TaskManager
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
           
        }
        protected void Application_BeginStart(object sender,EventArgs e)
        {
            var context = HttpContext.Current;

            // enable CORS
            context.Response.AddHeader("Access-Control-Allow-Origin", "*");
            context.Response.AddHeader("X-Frame-Options", "ALLOW-FROM *");

            if (context.Request.HttpMethod == "OPTIONS")
            {
                context.Response.AddHeader("Access-Control-Allow-Methods", "GET, POST");
                context.Response.AddHeader("Access-Control-Allow-Headers", "Content-Type, Accept");
                context.Response.AddHeader("Access-Control-Max-Age", "1728000");
                context.Response.End();
            }
        }
    }
}
