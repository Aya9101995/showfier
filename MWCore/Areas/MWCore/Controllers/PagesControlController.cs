using MWCore.Areas.MWCore.Models;
using MWCore.Areas.MWCore.Models.BaseController;
using MWCore.Areas.MWCore.Models.Modules.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MWCore.Areas.MWCore.Controllers
{
    public class PagesControlController : MWCoreController
    {
        // GET: MWCore/PagesControl
        public ActionResult Index(int ParentID = 0)
        {
            MWCoreModel oModel = new MWCoreModel();
            PagesCOM oPagesCOM = new PagesCOM();
            oModel.oPage = new PagesModel()
            {
                LanguageID = oModel.oSystemLanguage.ID,
                ParentID = ParentID
            };
            oModel.lstPages = oPagesCOM.GetPages(oModel.oSystemLanguage.ID, ParentID);
            return View(oModel);
        }

        public ActionResult AddEditPages(int? PageID, int ParentID)
        {
            MWCoreModel oModel = new MWCoreModel();
            if (PageID != null && PageID > 0)
            {
                PagesCOM oPagesCOM = new PagesCOM();
                oModel.oPage = oPagesCOM.GetPagesDetails((int)PageID, oModel.oSystemLanguage.ID);
            }
            else
            {

                oModel.oPage = new PagesModel()
                {
                    LanguageID = oModel.oSystemLanguage.ID,
                    ParentID = ParentID
                };
            }
            return View(oModel);
        }

        public ActionResult SavePages(MWCoreModel oModel)
        {
            PagesCOM oPagesCOM = new PagesCOM();
            oModel.lstPages = oPagesCOM.SavePages(oModel.oPage, oModel.lstSystemLanguages);
            return RedirectToAction("Index",new {@ParentID=oModel.oPage.ParentID });
        }
        public ActionResult ChangeStatus(int PageID, int ParentID)
        {
            MWCoreModel oModel = new MWCoreModel();
            PagesCOM oPagesCOM = new PagesCOM();
            oModel.lstPages = oPagesCOM.ChangeStatus(PageID, oModel.oSystemLanguage.ID);
            oModel.oPage = new PagesModel()
            {
                LanguageID = oModel.oSystemLanguage.ID,
                ParentID = ParentID
            };
            return PartialView("_Pages", oModel);
        }

        public ActionResult DeletePages(int PageID, int ParentID)
        {
            MWCoreModel oModel = new MWCoreModel();
            PagesCOM oPagesCOM = new PagesCOM();
            oModel.lstPages = oPagesCOM.DeleteRecord(PageID, oModel.oSystemLanguage.ID);
            oModel.oPage = new PagesModel()
            {
                LanguageID = oModel.oSystemLanguage.ID,
                ParentID = ParentID
            };
            return PartialView("_Pages", oModel);
        }

        [HttpPost]
        public JsonResult URLAlreadyExistsAsync(PagesModel oModel)
        {
            PagesCOM oPagesCOM = new PagesCOM();
            var result = oPagesCOM.checkURL(oModel);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}