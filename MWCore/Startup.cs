using Hangfire;
using Hangfire.Dashboard;
using Microsoft.Owin;
using Owin;
using System.Web;

[assembly: OwinStartup(typeof(MWCore.Startup))]
namespace MWCore
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
            string sConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MWCoreDB"].ConnectionString;
            GlobalConfiguration.Configuration
                .UseSqlServerStorage(sConnectionString);
            app.UseHangfireDashboard("/hangfire", new DashboardOptions
            {
                Authorization = new[] { new MyAuthorizationFilter() }
            });
            app.UseHangfireServer();
            
        }

        public class MyAuthorizationFilter : IDashboardAuthorizationFilter
        {
            public bool Authorize(DashboardContext context)
            {
                if (HttpContext.Current != null && HttpContext.Current.Session != null && HttpContext.Current.Session["UserInfo"] != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}