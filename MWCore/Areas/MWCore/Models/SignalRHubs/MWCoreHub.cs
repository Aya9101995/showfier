/*****************************************************************************/
/* File Name     : MWCoreHub.cs                                             */
/* Created By    : Abdulla Hawwash                                         */
/* Creation Date : 19/12/2017                                             */
/* Comment       : MWCore Hub For SignalR                                */
/************************************************************************/

using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using MWCore.Areas.MWCore.Models.DBClasses;
using MWCore.Areas.MWCore.Models.Modules.SystemSettings;
using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MWCore.Areas.MWCore.Models.SignalRHubs
{
    [HubName("mwcorehub")]
    public class MWCoreHub : Hub
    {


        public void NotifyAll(string Title, string Message, string URL)
        {
            var context = GlobalHost.ConnectionManager.GetHubContext<MWCoreHub>();
            context.Clients.All.PushNotification(Title, Message, URL);
        }
        public void UpdateMap()
        {
            var context = GlobalHost.ConnectionManager.GetHubContext<MWCoreHub>();
            //string conid = HttpContext.Current.Session["ConID"].ToString();
            //context.Clients.AllExcept(conid).PushNotification(Message + "  " + HttpContext.Current.Session.SessionID);
            context.Clients.All.UpdateMap();
        }

        public void UpdateOrderMap(string OrderID)
        {
            var context = GlobalHost.ConnectionManager.GetHubContext<MWCoreHub>();
            context.Clients.All.UpdateOrderMap(OrderID);
        }
        public static async System.Threading.Tasks.Task UpdateMapUsingWeb()
        {
            HttpClient client = new HttpClient();
            SystemSettingsModel oSystemSettings = SystemSettingsCOM.GetSystemSettingsDetails();
            var response = await client.GetAsync(oSystemSettings.DefaultWebsiteURL + "/MWCore/DashboardControl/UpdateMapUsingWeb");
        }
        public static void OrderNotify(long OrderID, int ShopID, int ShopBranchID, string Title, string Message)
        {
            var context = GlobalHost.ConnectionManager.GetHubContext<MWCoreHub>();
            context.Clients.All.OrderNotify(OrderID, ShopID, ShopBranchID, Title, Message);
        }

        public Task Subscribe(string ChannleName)
        {
            return Groups.Add(Context.ConnectionId, ChannleName);
        }
        public Task UnSubscribe(string ChannleName)
        {
            return Groups.Remove(Context.ConnectionId, ChannleName);
        }

        public Task Publish(string ChannleName, string Message)
        {
            return Clients.Group(ChannleName).SendAsync(Message);
        }


    }
}