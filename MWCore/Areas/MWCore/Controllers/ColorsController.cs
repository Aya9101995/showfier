using MWCore.Areas.MWCore.Models;
using MWCore.Areas.MWCore.Models.BaseController;
using MWCore.Areas.MWCore.Models.Modules.Colors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MWCore.Areas.MWCore.Controllers
{
    public class ColorsController : MWCoreController
    {
        // GET: MWCore/Colors
        public ActionResult Index()
        {
            MWCoreModel oModel = new MWCoreModel();
            ColorsCOM oColorsCOM = new ColorsCOM();
            oModel.lstColors = oColorsCOM.GetColors(oModel.oSystemLanguage.ID);
            return View(oModel);
        }
        public ActionResult AddEditColors(int? ColorID)
        {
            MWCoreModel oModel = new MWCoreModel();
            if (ColorID != null && ColorID > 0)
            {
                ColorsCOM oColorsCOM = new ColorsCOM();
                oModel.oColor = oColorsCOM.GetColorDetails((int)ColorID, oModel.oSystemLanguage.ID);
            }
            else
            {
                oModel.oColor = new ColorsModel();
                oModel.oColor.LanguageID = oModel.oSystemLanguage.ID;
            }
            return PartialView("_AddEditColors", oModel);
        }

        public ActionResult SaveColor(MWCoreModel oModel)
        {
            ColorsCOM oColorsCOM = new ColorsCOM();
            oModel.lstColors = oColorsCOM.SaveColor(oModel.oColor, oModel.lstSystemLanguages);
            return PartialView("_Colors", oModel);
        }

        public ActionResult DeleteColor(int ColorID)
        {
            MWCoreModel oModel = new MWCoreModel();
            ColorsCOM oColorsCOM = new ColorsCOM();
            oModel.lstColors = oColorsCOM.DeleteColor(ColorID, oModel.oSystemLanguage.ID);
            return PartialView("_Colors", oModel);
        }

        public ActionResult ChangeStatus(int ColorID)
        {
            MWCoreModel oModel = new MWCoreModel();
            ColorsCOM oColorsCOM = new ColorsCOM();
            oModel.lstColors = oColorsCOM.ChangeStatus(ColorID, oModel.oSystemLanguage.ID);
            return PartialView("_Colors", oModel);
        }
    }
}