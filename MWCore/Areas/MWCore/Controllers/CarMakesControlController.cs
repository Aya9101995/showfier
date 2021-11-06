using MWCore.Areas.MWCore.Models;
using MWCore.Areas.MWCore.Models.BaseController;
using MWCore.Areas.MWCore.Models.Modules.CarsMakes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MWCore.Areas.MWCore.Controllers
{
    public class CarMakesControlController : MWCoreController
    {
        // GET: MWCore/CarMakesControl
        public ActionResult Index()
        {
            MWCoreModel oModel = new MWCoreModel();
            CarsMakesCOM oCarMakesCOM = new CarsMakesCOM();
            oModel.lstCarMakes = oCarMakesCOM.GetCarMakes(oModel.oSystemLanguage.ID);
            return View(oModel);
        }
        public ActionResult AddEditCarMake(int? CarMakeID)
        {
            MWCoreModel oModel = new MWCoreModel();
            if (CarMakeID != null && CarMakeID > 0)
            {
                CarsMakesCOM oCarMakesCOM = new CarsMakesCOM();
                oModel.oCarMakes = oCarMakesCOM.GetCarMakeDetails((int)CarMakeID, oModel.oSystemLanguage.ID);
            }
            else
            {
                oModel.oCarMakes = new CarsMakesModel();
                oModel.oCarMakes.LanguageID = oModel.oSystemLanguage.ID;
            }
            return PartialView("_AddEditCarMake", oModel);
        }

        public ActionResult SaveCarMake(MWCoreModel oModel)
        {
            CarsMakesCOM oCarMakesCOM = new CarsMakesCOM();
            oModel.lstCarMakes = oCarMakesCOM.SaveCarMake(oModel.oCarMakes, oModel.lstSystemLanguages);
            return PartialView("_CarsMakes", oModel);
        }

        public ActionResult DeleteCarMake(int CarMakeID)
        {
            MWCoreModel oModel = new MWCoreModel();
            CarsMakesCOM oCarMakesCOM = new CarsMakesCOM();
            oModel.lstCarMakes = oCarMakesCOM.DeleteCarMake(CarMakeID, oModel.oSystemLanguage.ID);
            return PartialView("_CarsMakes", oModel);
        }

        public ActionResult ChangeStatus(int CarMakeID)
        {
            MWCoreModel oModel = new MWCoreModel();
            CarsMakesCOM oCarMakesCOM = new CarsMakesCOM();
            oModel.lstCarMakes = oCarMakesCOM.ChangeStatus(CarMakeID, oModel.oSystemLanguage.ID);
            return PartialView("_CarsMakes", oModel);
        }
    }
}