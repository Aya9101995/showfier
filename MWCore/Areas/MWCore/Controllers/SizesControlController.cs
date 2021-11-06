using MWCore.Areas.MWCore.Models;
using MWCore.Areas.MWCore.Models.BaseController;
using MWCore.Areas.MWCore.Models.Modules.Sizes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MWCore.Areas.MWCore.Controllers
{
    public class SizesControlController : MWCoreController
    {
        // GET: MWCore/SizesControl
        public ActionResult Index()
    {
        MWCoreModel oModel = new MWCoreModel();
        SizesCOM oSizesCOM = new SizesCOM();
        oModel.lstSizes = oSizesCOM.GetSizes(oModel.oSystemLanguage.ID);
        return View(oModel);
    }
    public ActionResult AddEditSizes(int? SizeID)
    {
        MWCoreModel oModel = new MWCoreModel();
        if (SizeID != null && SizeID > 0)
        {
            SizesCOM oSizesCOM = new SizesCOM();
            oModel.oSizes = oSizesCOM.GetSizeDetails((int)SizeID, oModel.oSystemLanguage.ID);
        }
        else
        {
            oModel.oSizes = new SizesModel();
            oModel.oSizes.LanguageID = oModel.oSystemLanguage.ID;
        }
        return PartialView("_AddEditSizes", oModel);
    }

    public ActionResult SaveSize(MWCoreModel oModel)
    {
        SizesCOM oSizesCOM = new SizesCOM();
        oModel.lstSizes = oSizesCOM.SaveSize(oModel.oSizes, oModel.lstSystemLanguages);
        return PartialView("_Sizes", oModel);
    }

    public ActionResult DeleteSize(int SizeID)
    {
        MWCoreModel oModel = new MWCoreModel();
        SizesCOM oSizesCOM = new SizesCOM();
        oModel.lstSizes = oSizesCOM.DeleteSize(SizeID, oModel.oSystemLanguage.ID);
        return PartialView("_Sizes", oModel);
    }

    public ActionResult ChangeStatus(int SizeID)
    {
        MWCoreModel oModel = new MWCoreModel();
        SizesCOM oSizesCOM = new SizesCOM();
        oModel.lstSizes = oSizesCOM.ChangeStatus(SizeID, oModel.oSystemLanguage.ID);
        return PartialView("_Sizes", oModel);
    }
}
}