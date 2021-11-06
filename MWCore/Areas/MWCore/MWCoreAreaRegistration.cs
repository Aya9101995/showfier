using System.Web.Mvc;

namespace MWCore.Areas.MWCore
{
    public class MWCoreAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "MWCore";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "MWCore_default",
                "MWCore/{controller}/{action}/{id}",
                new { controller = "DashboardControl", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}