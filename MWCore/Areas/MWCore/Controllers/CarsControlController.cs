using MWCore.Areas.MWCore.Models;
using MWCore.Areas.MWCore.Models.Modules.Cars;
using MWCore.Areas.MWCore.Models.Modules.CarsMakes;
using MWCore.Areas.MWCore.Models.Modules.CarsModels;
using MWCore.Areas.MWCore.Models.Modules.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MWCore.Areas.MWCore.Controllers
{
    public class CarsControlController : Controller
    {
        // GET: MWCore/CarsControl
        public ActionResult Index()
        {
            MWCoreModel oModel = new MWCoreModel();
            CarsCOM oCarCOM = new CarsCOM();
            oModel.lstCars = oCarCOM.GetCars(oModel.oSystemLanguage.ID);
            return View(oModel);
        }
        public ActionResult AddEditCar(int? CarID)
        {
            MWCoreModel oModel = new MWCoreModel();
            if (CarID != null && CarID > 0)
            {
                CarsCOM oCarCOM = new CarsCOM();
                oModel.oCar = oCarCOM.GetCarDetails((int)CarID, oModel.oSystemLanguage.ID);
            }
            else
            {
                oModel.oCar = new CarsModel();
                oModel.oCar.LanguageID = oModel.oSystemLanguage.ID;
            }
            oModel.lstCarMakesItemsList = CarsMakesCOM.GetCarMakesList(oModel.oSystemLanguage.ID);
            oModel.VehicleTypesItemsList = VehicleCOM.GetVehicleTypesList(oModel.oSystemLanguage.ID);
            //oModel.lstCarModelsItemsList = CarsModelsCOM.GetCarModelsList(oModel.oSystemLanguage.ID);
            return PartialView("_AddEditCar", oModel);
        }

        [HttpPost]
        public ActionResult UpdateCarModel(int CarMakeID)
        {
            MWCoreModel oModel = new MWCoreModel();
            oModel.lstCarModelsItemsList = CarsModelsCOM.GetCarModelsList(oModel.oSystemLanguage.ID, CarMakeID);
            return Json(oModel.lstCarModelsItemsList, JsonRequestBehavior.AllowGet);
        }
        public ActionResult SaveCar(MWCoreModel oModel)
        {
            CarsCOM oCarCOM = new CarsCOM();
            oModel.lstCars = oCarCOM.SaveCar(oModel.oCar, oModel.lstSystemLanguages);
            return PartialView("_Cars", oModel);
        }

        public ActionResult DeleteCar(int CarID)
        {
            MWCoreModel oModel = new MWCoreModel();
            CarsCOM oCarCOM = new CarsCOM();
            oModel.lstCars = oCarCOM.DeleteCar(CarID, oModel.oSystemLanguage.ID);
            return PartialView("_Cars", oModel);
        }

        public ActionResult ChangeStatus(int CarID)
        {
            MWCoreModel oModel = new MWCoreModel();
            CarsCOM oCarCOM = new CarsCOM();
            oModel.lstCars = oCarCOM.ChangeStatus(CarID, oModel.oSystemLanguage.ID);
            return PartialView("_Cars", oModel);
        }

    }
}