using MWCore.Areas.MWCore.Models.SignalRHubs;
using MWCore.Controllers;
using PubnubApi;
using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MWCore
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public static Pubnub pubnub;
        public static MWRTCConnecter.MWRTCConnecter RTCConnecter;
        //public static List<DriversCurrentLocationsModel> lstDriversCurrentLocations;
        protected async void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            bool EnablePubNub = Convert.ToBoolean(System.Configuration.ConfigurationManager.AppSettings["EnablePubNub"].ToString());
            if (EnablePubNub)
            {
                RTCConnecter = await RTCManager.StartAsync();
            }
            
        }
        protected void Application_BeginRequest()
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetExpires(DateTime.UtcNow.AddHours(-1));
            Response.Cache.SetNoStore();
        }
        protected void Session_Start()
        {

        }
        protected void Application_Error(object sender, EventArgs e)
        {
            Exception exception = Server.GetLastError();
            // Log the exception.

            
            Response.Clear();

            HttpException httpException = exception as HttpException;

            RouteData routeData = new RouteData();
            routeData.Values.Add("lang", "en");
            routeData.Values.Add("controller", "PageNotFound");

            if (httpException == null)
            {
                routeData.Values.Add("action", "Index");
            }
            else //It's an Http Exception, Let's handle it.
            {
                switch (httpException.GetHttpCode())
                {
                    case 404:
                        // Page not found.
                        routeData.Values.Add("action", "Index");
                        break;
                    case 500:
                        // Server error.
                        routeData.Values.Add("action", "Index");
                        break;

                    // Here you can handle Views to other error codes.
                    // I choose a General error template  
                    default:
                        routeData.Values.Add("action", "Index");
                        break;
                }
            }

            

            // Clear the error on server.
            Server.ClearError();

            // Avoid IIS7 getting in the middle
            Response.TrySkipIisCustomErrors = true;

            // Call target Controller and pass the routeData.
            IController errorController = new PageNotFoundController();
            errorController.Execute(new RequestContext(
                 new HttpContextWrapper(Context), routeData));
        }

    }
}
