/*****************************************************************************/
/* File Name     : PagesKeysControlController.cs                            */
/* Created By    : Abdulla Hawwash                                         */
/* Creation Date : 19/12/2017                                             */
/* Comment       : Pages Keys Controller                                 */
/************************************************************************/

using MWCore.Areas.MWCore.Models;
using MWCore.Areas.MWCore.Models.BaseController;
using MWCore.Areas.MWCore.Models.DBClasses;
using MWCore.Areas.MWCore.Models.Modules.Pages;
using System;
using System.IO;
using System.Linq;
using System.Web.Mvc;

namespace MWCore.Areas.MWCore.Controllers
{
    public class PagesKeysControlController : MWCoreController
    {
        // GET: MWCore/PagesKeysControl
        #region ActionResult :: Index
        public ActionResult Index(int PageID)
        {
            MWCoreModel oModel = new MWCoreModel();
            PagesCOM oPagesKeys = new PagesCOM();
            oModel.lstPagesKeys = oPagesKeys.GetPagesKey(oModel.oSystemLanguage.ID, PageID);
            oModel.oPageKey = new PagesKeysModel()
            {
                LanguageID = oModel.oSystemLanguage.ID,
                PageID = PageID
            };
            return View(oModel);
        }
        #endregion

        #region ActionResult :: AddEditPageKey
        public ActionResult AddEditPageKey(int PageID, int? KeyID)
        {
            MWCoreModel oModel = new MWCoreModel();
            if (KeyID != null && KeyID > 0)
            {
                PagesCOM oPagesKeys = new PagesCOM();
                oModel.oPageKey = oPagesKeys.GetPageKeyDetails(oModel.oSystemLanguage.ID, (int)KeyID);
            }
            else
            {

                oModel.oPageKey = new PagesKeysModel()
                {
                    LanguageID = oModel.oSystemLanguage.ID,
                    PageID = PageID
                };
            }
            return View(oModel);
        }
        #endregion

        #region ActionResult :: SavePageKey
        public ActionResult SavePageKey(MWCoreModel oModel)
        {
            PagesCOM oPagesKeys = new PagesCOM();
            oModel.lstPagesKeys = oPagesKeys.SavePageKey(oModel.oPageKey, oModel.lstSystemLanguages);
            return RedirectToAction("Index", new { @PageID = oModel.oPageKey.PageID });
        }
        #endregion

        #region JsonResult :: UploadImage (Post)
        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult UploadImage()
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
                    var path = Path.Combine(Server.MapPath("~/assets/UploadedFiles"));
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