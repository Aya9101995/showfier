/*****************************************************************************/
/* File Name     : SystemSettingsControlController.cs                       */
/* Created By    : Abdulla Hawwash                                         */
/* Creation Date : 19/12/2017                                             */
/* Comment       : System Settings Controller                            */
/************************************************************************/

using MWCore.Areas.MWCore.Models;
using MWCore.Areas.MWCore.Models.BaseController;
using MWCore.Areas.MWCore.Models.Modules.SystemSettings;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Mvc;

namespace MWCore.Areas.MWCore.Controllers
{
    public class SystemSettingsControlController : MWCoreController
    {
        // GET: MWCore/SystemSettingsControl
        #region ActionResult :: Index
        public ActionResult Index()
        {
            SystemSettingsCOM oSystemSettings = new SystemSettingsCOM();
            MWCoreModel oModel = new MWCoreModel();
            oModel.oSystemSettings = oSystemSettings.GetSystemSettings();
            return View(oModel);
        }
        #endregion

        #region ActionResult :: SaveSystemSettings
        public ActionResult SaveSystemSettings(MWCoreModel oModel)
        {
            SystemSettingsCOM oSystemSettings = new SystemSettingsCOM();
            oModel.oSystemSettings = oSystemSettings.SaveSystemSettings(oModel);
            if (oModel.oSystemSettings.ID > 0)
            {
                ViewBag.Result = "Saved Successfully.";
            }
            else
            {
                ViewBag.Result = "Error, Data Not Saved.";
            }
            return PartialView("_SystemSettings", oModel);
        }
        #endregion

        #region JsonResult :: UploadHeaderLogo (Post)
        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult UploadHeaderLogo()
        {
            string sFileName = string.Empty;
            if (System.Web.HttpContext.Current.Request.Files.AllKeys.Any())
            {
                var pic = System.Web.HttpContext.Current.Request.Files["HeaderLogo"];
                if (pic.ContentLength > 0)
                {
                    string sFileExtenction = Path.GetExtension(pic.FileName);

                    System.IO.FileInfo oFileInfo = new FileInfo(pic.FileName);
                    sFileName = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + oFileInfo.Extension;
                    var path = Path.Combine(Server.MapPath("~/assets/images/Logo"));
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

        #region JsonResult :: UploadFooterLogo (Post)
        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult UploadFooterLogo()
        {
            string sFileName = string.Empty;
            if (System.Web.HttpContext.Current.Request.Files.AllKeys.Any())
            {
                var pic = System.Web.HttpContext.Current.Request.Files["FooterLogo"];
                if (pic.ContentLength > 0)
                {
                    string sFileExtenction = Path.GetExtension(pic.FileName);

                    System.IO.FileInfo oFileInfo = new FileInfo(pic.FileName);
                    sFileName = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + oFileInfo.Extension;
                    var path = Path.Combine(Server.MapPath("~/assets/images/Logo"));
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
    }
}