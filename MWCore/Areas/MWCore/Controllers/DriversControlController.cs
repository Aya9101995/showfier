using MWCore.Areas.MWCore.Models;
using MWCore.Areas.MWCore.Models.BaseController;
using MWCore.Areas.MWCore.Models.Modules.Cars;
using MWCore.Areas.MWCore.Models.Modules.Countries;
using MWCore.Areas.MWCore.Models.Modules.Drivers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MWCore.Areas.MWCore.Controllers
{
    public class DriversControlController : MWCoreController
    {
        // GET: MWCore/DriversControl

        public ActionResult Index()
        {
            MWCoreModel oModel = new MWCoreModel();
            DriversCOM oDriversCOM = new DriversCOM();
            oModel.lstDrivers = oDriversCOM.GetDrivers(oModel.oSystemLanguage.ID);
            oModel.lstGenderList = new List<SelectListItem>()
            {
                new SelectListItem()
                {
                    Text="Male",
                    Value="1"
                }, new SelectListItem()
                {
                    Text="Female",
                    Value="2"
                }
            };
            return View(oModel);
        }



        public ActionResult AddEditDriver(int? DriverID)
        {
            MWCoreModel oModel = new MWCoreModel();
            DriversCOM oDriversCOM = new DriversCOM();
            if (DriverID > 0)
            {
                oModel.oDriver = oDriversCOM.GetDriverDetails((int)DriverID, oModel.oSystemLanguage.ID);
            }
            else
            {
                oModel.oDriver = new DriversModel();
            }
            oModel.lstCountriesPhoneCodesList = CountriesCOM.GetCountiresPhoneCodes();
            oModel.CarsItemsList = CarsCOM.GetCarsList(oModel.oSystemLanguage.ID);
            oModel.lstGenderList = new List<SelectListItem>()
            {
                new SelectListItem()
                {
                    Text="Male",
                    Value="1"
                }, new SelectListItem()
                {
                    Text="Female",
                    Value="2"
                }
            };
            return PartialView("_AddEditDrivers", oModel);
        }

        public ActionResult SaveDriver(MWCoreModel oModel)
        {
            DriversCOM oDriversCOM = new DriversCOM();
            oModel.lstDrivers = oDriversCOM.SaveDriver(oModel.oDriver);

            return PartialView("_Drivers", oModel);
        }



        [HttpPost]
        public JsonResult PhoneNumberAlreadyExistsAsync(FormCollection parm)
        {
            DriversModel oModel = new DriversModel();
            oModel.DriverID = Convert.ToInt32(parm["oDriver.DriverID"]);
            oModel.PhoneCode = parm["oDriver.PhoneCode"];
            oModel.PhoneNumber = parm["oDriver.PhoneNumber"];
            DriversCOM oDriverCOM = new DriversCOM();
            var result = oDriverCOM.CheckPhoneNumber(oModel);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult DeleteDriver(int DriverID)
        {
            MWCoreModel oModel = new MWCoreModel();
            DriversCOM oDriversCOM = new DriversCOM();
            oModel.lstDrivers = oDriversCOM.DeleteDriver(DriverID, oModel.oSystemLanguage.ID);
            return PartialView("_Drivers", oModel);
        }
    }
}