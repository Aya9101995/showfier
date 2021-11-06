using Hangfire;
using Hangfire.Dashboard;
using Microsoft.Owin;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

[assembly: OwinStartup("APIStartup", typeof(MWCoreAPI.APIStartup))]
namespace MWCoreAPI
{
    public class APIStartup
    {
        public void Configuration(IAppBuilder app)
        {
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
                return true;
            }
        }
    }
}