using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using RP_CardAPI.Services;

namespace RP_CardAPI
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {

            Thread FeeService = new Thread(new ThreadStart(UFEScheduler.StartScheduler));

            FeeService.IsBackground = true;

            FeeService.Name = "FeeService";

            FeeService.Start();


            GlobalConfiguration.Configure(WebApiConfig.Register);
            
        }
    }
}
