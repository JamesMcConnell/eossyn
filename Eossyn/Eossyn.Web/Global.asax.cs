using System;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Eossyn.Infrastructure.Utilities;
using Eossyn.Infrastructure.Injection;
using NServiceBus;
using Eossyn.ServiceContracts;

namespace Eossyn.Web
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : HttpApplication
    {
        private IBus _bus { get; set; }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();

            _bus = Configure.With()
                .DefaultBuilder()
                .ForMVC()
                .Log4Net()
                .XmlSerializer()
                .MsmqTransport()
                .UnicastBus()
                .SendOnly();
        }

        protected void Session_End(object sender, EventArgs e)
        {
            // Eventually, we will want to fire an NSB event to handle the removal from session
            // as well as update for the database without clogging up our global with unnecessary coupling.
            _bus.Send(new UserSessionEnd
            {
                UserSessionId = Guid.NewGuid()
            });
        }
    }
}