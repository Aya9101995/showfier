/*****************************************************************************/
/* File Name     : ContentPagesControlController.cs                         */
/* Created By    : Abdulla Hawwash                                         */
/* Creation Date : 19/12/2017                                             */
/* Comment       : Content Pages Controller                              */
/************************************************************************/

using MWCore.Areas.MWCore.Models;
using MWCore.Areas.MWCore.Models.BaseController;
using MWCore.Areas.MWCore.Models.Modules.ContentPages;
using System.Web.Mvc;

namespace MWCore.Areas.MWCore.Controllers
{
    public class ContentPagesControlController : MWCoreController
    {
        #region ActionResult :: Index
        public ActionResult Index()
        {
            MWCoreModel oModel = new MWCoreModel();
            ContentPagesCOM oContentPage = new ContentPagesCOM();
            oModel.lstContentPages = oContentPage.GetContentPages(oModel.oSystemLanguage.ID);
            return View(oModel);
        }
        #endregion

        #region ActionResult :: EditContentPage
        public ActionResult EditContentPage(int PageID)
        {
            MWCoreModel oModel = new MWCoreModel();
            ContentPagesCOM oContentPage = new ContentPagesCOM();
            oModel.oContentPage_Loc = oContentPage.GetContentPageDetails(PageID, oModel.oSystemLanguage.ID);
            return View(oModel);
        }
        #endregion

        #region ActionResult :: SaveContentPage (Post)
        [HttpPost]
        public ActionResult SaveContentPage(MWCoreModel oModel)
        {
            ContentPagesCOM oContentPage = new ContentPagesCOM();
            oModel.lstContentPages = oContentPage.SaveContentPage(oModel);
            return RedirectToAction("Index");
        }
        #endregion
    }
}