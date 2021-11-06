using MWCore.Areas.MWCore.Models;
using MWCore.Areas.MWCore.Models.BaseController;
using MWCore.Areas.MWCore.Models.Modules.CarsMakes;
using MWCore.Areas.MWCore.Models.Modules.CarsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MWCore.Areas.MWCore.Controllers
{
    public class CarModelsControlController : MWCoreController
    {
        // GET: MWCore/CarModelsControl
        public ActionResult Index()
        {
            MWCoreModel oModel = new MWCoreModel();
            CarsModelsCOM oCarModelsCOM = new CarsModelsCOM();
            oModel.lstCarModels = oCarModelsCOM.GetCarModels(oModel.oSystemLanguage.ID);
            return View(oModel);
        }
        public ActionResult AddEditCarModel(int? CarModelID)
        {
            MWCoreModel oModel = new MWCoreModel();
            if (CarModelID != null && CarModelID > 0)
            {
                CarsModelsCOM oCarModelsCOM = new CarsModelsCOM();
                oModel.oCarModels = oCarModelsCOM.GetCarModelDetails((int)CarModelID, oModel.oSystemLanguage.ID);
            }
            else
            {
                oModel.oCarModels = new CarsModelsModel();
                oModel.oCarModels.LanguageID = oModel.oSystemLanguage.ID;
            }
            oModel.lstCarMakesItemsList = CarsMakesCOM.GetCarMakesList(oModel.oSystemLanguage.ID);
            return PartialView("_AddEditCarMakeModels", oModel);
        }

        public ActionResult SaveCarModel(MWCoreModel oModel)
        {
            CarsModelsCOM oCarModelsCOM = new CarsModelsCOM();
            oModel.lstCarModels = oCarModelsCOM.SaveCarModel(oModel.oCarModels, oModel.lstSystemLanguages);
            return PartialView("_CarMakeModels", oModel);
        }

        public ActionResult DeleteCarModel(int CarModelID)
        {
            MWCoreModel oModel = new MWCoreModel();
            CarsModelsCOM oCarModelsCOM = new CarsModelsCOM();
            oModel.lstCarModels = oCarModelsCOM.DeleteCarModel(CarModelID, oModel.oSystemLanguage.ID);
            return PartialView("_CarMakeModels", oModel);
        }

        public ActionResult ChangeStatus(int CarModelID)
        {
            MWCoreModel oModel = new MWCoreModel();
            CarsModelsCOM oCarModelsCOM = new CarsModelsCOM();
            oModel.lstCarModels = oCarModelsCOM.ChangeStatus(CarModelID, oModel.oSystemLanguage.ID);
            return PartialView("_CarMakeModels", oModel);
        }
    }
}