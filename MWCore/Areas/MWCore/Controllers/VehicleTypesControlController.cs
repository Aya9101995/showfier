using MWCore.Areas.MWCore.Models;
using MWCore.Areas.MWCore.Models.BaseController;
using MWCore.Areas.MWCore.Models.Modules.Taxes;
using MWCore.Areas.MWCore.Models.Modules.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MWCore.Areas.MWCore.Controllers
{
    public class VehicleTypesControlController : MWCoreController
    {
        // GET: MWCore/VehicleTypesControl
       
        public ActionResult Index()
        {
            MWCoreModel oModel = new MWCoreModel();
            VehicleCOM oVehicleCOM = new VehicleCOM();
            oModel.lstVehicleTypes = oVehicleCOM.GetVehicleTypes(oModel.oSystemLanguage.ID);
            return View(oModel);
        }
        public ActionResult AddEditVehicleType(int? VehicleTypeID)
        {
            MWCoreModel oModel = new MWCoreModel();
            if (VehicleTypeID != null && VehicleTypeID > 0)
            {
                VehicleCOM oVehicleCOM = new VehicleCOM();
                oModel.oVehicleType = oVehicleCOM.GetVehicleDetails((int)VehicleTypeID, oModel.oSystemLanguage.ID);
            }
            else
            {
                oModel.oVehicleType = new VehiclesModel();
                oModel.oVehicleType.LanguageID = oModel.oSystemLanguage.ID;
            }
            oModel.lstTaxesItemsList = TaxesCOM.GetTaxesList(oModel.oSystemLanguage.ID);
            return PartialView("_AddEditVehicleType", oModel);
        }

        public ActionResult SaveVehicleType(MWCoreModel oModel)
        {
            VehicleCOM oVehicleCOM = new VehicleCOM();
            oModel.lstVehicleTypes = oVehicleCOM.SaveVehicleType(oModel.oVehicleType, oModel.lstSystemLanguages);
            return PartialView("_VehicleTypes", oModel);
        }

        public ActionResult DeleteVehicleType(int VehicleTypeID)
        {
            MWCoreModel oModel = new MWCoreModel();
            VehicleCOM oVehicleCOM = new VehicleCOM();
            oModel.lstVehicleTypes = oVehicleCOM.DeleteVehicleType(VehicleTypeID, oModel.oSystemLanguage.ID);
            return PartialView("_VehicleTypes", oModel);
        }

        public ActionResult ChangeStatus(int VehicleTypeID)
        {
            MWCoreModel oModel = new MWCoreModel();
            VehicleCOM oVehicleCOM = new VehicleCOM();
            oModel.lstVehicleTypes = oVehicleCOM.ChangeStatus(VehicleTypeID, oModel.oSystemLanguage.ID);
            return PartialView("_VehicleTypes", oModel);
        }

    }
}