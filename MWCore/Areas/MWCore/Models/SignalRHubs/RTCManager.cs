using MawaqaaCodeLibrary;
using Microsoft.AspNet.SignalR.Client;
using MWRTCConnecter;

namespace MWCore.Areas.MWCore.Models.SignalRHubs
{
    public class RTCManager
    {
        public static readonly object LockOnMessage = new object();
        public static async System.Threading.Tasks.Task<MWRTCConnecter.MWRTCConnecter> StartAsync()
        {
            string sHost = System.Configuration.ConfigurationManager.AppSettings["DefaultWebsiteURL"].ToString();
            MWRTCConnecter.MWRTCConnecter oMWRTCConnecter = new MWRTCConnecter.MWRTCConnecter(sHost);
            oMWRTCConnecter.OnMessage += OnMessage;
            oMWRTCConnecter.OnStatusChanged += OnStatusChanged;
            await oMWRTCConnecter.Connect();
            oMWRTCConnecter.Subscribe("BeepBeepRTC");
            return oMWRTCConnecter;
        }
        private static void OnMessage(object source, OnMessage e)
        {
            lock (LockOnMessage)
            {
                string sMessage = e.GetInfo();
                MWRTCConnecter.Modules.MainModel oMainModel = sMessage.DeserializeJsonToObject<MWRTCConnecter.Modules.MainModel>();
               if(oMainModel != null)
                {
                    if (oMainModel.Action == (int)MWRTCConnecter.Modules.enumRTCActions.Update_Location)
                    {
                        MWRTCConnecter.Modules.LocationModel oLocation = sMessage.DeserializeJsonToObject<MWRTCConnecter.Modules.LocationModel>();
                        

                    }
                    else if (oMainModel.Action == (int)MWRTCConnecter.Modules.enumRTCActions.Order_Tracking)
                    {
                        MWRTCConnecter.Modules.OrderTrackingModel oCurrentOrder = sMessage.DeserializeJsonToObject<MWRTCConnecter.Modules.OrderTrackingModel>();
                        MWCoreHub oHub = new MWCoreHub();
                        oHub.UpdateOrderMap(oCurrentOrder.OrderQRCode);
                    }
                }
            }

        }

        private static void OnStatusChanged(object source, OnStatusChanged e)
        {
            StateChange s = e.GetInfo();
        }
    }
}