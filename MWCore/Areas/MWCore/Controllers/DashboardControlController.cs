/*****************************************************************************/
/* File Name     : DashboardControlController.cs                            */
/* Created By    : Abdulla Hawwash                                         */
/* Creation Date : 19/12/2017                                             */
/* Comment       : Dashboard Controller                                  */
/************************************************************************/

using MawaqaaCodeLibrary;
using MWCore.Areas.MWCore.Models;
using MWCore.Areas.MWCore.Models.BaseController;
using MWCore.Areas.MWCore.Models.Common;
using MWCore.Areas.MWCore.Models.DBClasses;
using MWCore.Areas.MWCore.Models.DBClasses.Settings;
using MWCore.Areas.MWCore.Models.Modules.Dashboard;
using MWCore.Areas.MWCore.Models.SignalRHubs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web.Mvc;
using System.Xml.Linq;

namespace MWCore.Areas.MWCore.Controllers
{
    public class DashboardControlController : MWCoreController
    {
        // GET: MWCore/DashboardControl
        #region ActionResult :: Index
        public ActionResult Index()
        {
            MWCoreModel oModel = new MWCoreModel();
            return View(oModel);
        }
        #endregion

        #region ActionResult :: Index (Post)
        [HttpPost]
        public ActionResult Index(MWCoreModel oModel)
        {

            return View(oModel);
        }
        #endregion

        public ActionResult GetDriverDetails(int DriverID)
        {
            MWCoreModel oModel = new MWCoreModel();
            DashboardCOM oDashboard = new DashboardCOM();
            return PartialView("_InfoWindow", oModel);
        }

        public JsonResult LoadMapData(DashboardModel oDashboardModel)
        {
            DashboardCOM oDashboardCOM = new DashboardCOM();
            oDashboardModel = oDashboardCOM.LoadDashboard(oDashboardModel);
            return Json(oDashboardModel, JsonRequestBehavior.AllowGet);
        }

        //public JsonResult GetAverageOrders(int BranchID)
        //{
        //    DashboardCOM oDashboardCOM = new DashboardCOM();
        //    double TotalAverage = oDashboardCOM.GetAverageOrders(BranchID);
        //    return Json(TotalAverage, JsonRequestBehavior.AllowGet);
        //}
        public static string GetLocationName(double latitude, double longitude)
        {
            string baseUri = string.Format("https://maps.googleapis.com/maps/api/geocode/xml?latlng={0},{1}&sensor=false&key=AIzaSyBTBqvwcnNFONw1Q-4r0yQCQS2RSD8-n-Y&origins=", latitude, longitude);
            XElement responseElement = XElement.Load(baseUri);
            IEnumerable<XElement> statusElement = from st in responseElement.Elements("status") select st;
            if (statusElement.FirstOrDefault() != null)
            {
                string status = statusElement.FirstOrDefault().Value;
                if (status.ToLower() == "ok")
                {
                    IEnumerable<XElement> resultElement = from rs in responseElement.Elements("result") select rs;
                    if (resultElement.FirstOrDefault() != null)
                    {
                        IEnumerable<XElement> typeElement = from te in resultElement.Elements("formatted_address") select te;
                        return typeElement.FirstOrDefault().Value;
                    }
                }
            }
            return "";
        }

        #region Method :: ChangeLanguage
        public void ChangeLanguage(int LanguageID, string CurrentURL)
        {
            using (MWCoreEntity db = new MWCoreEntity())
            {
                MW_SystemLanguages oSystemLanguage = db.MW_SystemLanguages.Single(x => x.ID == LanguageID);
                Session["SystemLangugage"] = oSystemLanguage;
                Response.Redirect(CurrentURL);
            }
        }
        #endregion

        #region JsonResult :: UploadImage (Post)
        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult UploadImage(int width = 0, int height = 0)
        {
            string sFileName = string.Empty;
            if (System.Web.HttpContext.Current.Request.Files.AllKeys.Any())
            {
                var pic = System.Web.HttpContext.Current.Request.Files["MyImages"];
                if (pic.ContentLength > 0)
                {
                    string sFileExtenction = Path.GetExtension(pic.FileName);
                    if (sFileExtenction.ToLower() == ".jpg" || sFileExtenction.ToLower() == ".jpeg" || sFileExtenction.ToLower() == ".png" || sFileExtenction.ToLower() == ".mp4" || sFileExtenction.ToLower() == ".pdf" || sFileExtenction.ToLower() == ".doc" || sFileExtenction.ToLower() == ".docx")
                    {
                        System.IO.FileInfo oFileInfo = new FileInfo(pic.FileName);
                        sFileName = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + oFileInfo.Extension;
                        var path = Path.Combine(Server.MapPath("~/assets/images/Uploads"));
                        string sPath = System.IO.Path.Combine(path.ToString());
                        if (!System.IO.Directory.Exists(sPath))
                        {
                            System.IO.Directory.CreateDirectory(sPath);
                        }
                        var sUploadPath = string.Format("{0}\\{1}", sPath, sFileName);
                        if (width == 0 && height == 0)
                        {
                            pic.SaveAs(sUploadPath);
                        }
                        else
                        {
                            Stream strm = pic.InputStream;
                            System.Drawing.Image img = System.Drawing.Image.FromStream(strm, true);
                            using (var resized = ImageUtilities.ResizeImage(img, width, height))
                            {
                                //save the resized image as a jpeg with a quality of 90
                                ImageUtilities.SaveJpeg(sUploadPath, resized, 50);
                            }
                        }

                    }
                    else
                    {
                        sFileName = "Error";
                    }


                }
            }
            return Json(Convert.ToString(sFileName), JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region JsonResult :: UploadFile (Post)
        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult UploadFile()
        {
            string sFileName = string.Empty;
            if (System.Web.HttpContext.Current.Request.Files.AllKeys.Any())
            {
                var pic = System.Web.HttpContext.Current.Request.Files["MyImages"];
                if (pic.ContentLength > 0)
                {
                    string sFileExtenction = Path.GetExtension(pic.FileName);
                    System.IO.FileInfo oFileInfo = new FileInfo(pic.FileName);
                    sFileName = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + oFileInfo.Extension;
                    var path = Path.Combine(Server.MapPath("~/assets/images/Uploads"));
                    string sPath = System.IO.Path.Combine(path.ToString());
                    if (!System.IO.Directory.Exists(sPath))
                    {
                        System.IO.Directory.CreateDirectory(sPath);
                    }
                    var sUploadPath = string.Format("{0}\\{1}", sPath, sFileName);
                    pic.SaveAs(sUploadPath);


                }
            }
            return Json(Convert.ToString(sFileName), JsonRequestBehavior.AllowGet);
        }
        #endregion

        public JsonResult UpdateMapUsingWeb()
        {
            MWCoreHub oHub = new MWCoreHub();
            oHub.UpdateMap();
            return Json("Done", JsonRequestBehavior.AllowGet);
        }

        
    }
    public class Coordinates
    {
        public double MinLat { get; set; }
        public double MaxLat { get; set; }
        public double minLong { get; set; }
        public double MaxLong { get; set; }
        public List<DriverLocation> lstLocations { get; set; }
    }

    public class DriverLocation
    {
        public int id { get; set; }
        public string name { get; set; }
        public string locationname { get; set; }
        /// <summary>
        /// 1 => Bike Rider
        /// 2 => Car Driver
        /// </summary>
        public int drivertype { get; set; }
        /// <summary>
        /// 1 => Available
        /// 2 => Away
        /// 3 => Offline
        /// </summary>
        public int driverstatus { get; set; }
        public DateTime updateddate { get; set; }
        public Position position { get; set; }
    }
    public class Position
    {
        public double Lat { get; set; }
        public double Long
        {
            get; set;
        }
    }
    public class MapFilters
    {
        public bool Rider { get; set; }
        public bool Driver { get; set; }
        public bool Available { get; set; }
        public bool Away { get; set; }
        public bool Offline { get; set; }
    }
}