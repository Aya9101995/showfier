using MWCore.Areas.MWCore.Models;
using MWCore.Areas.MWCore.Models.BaseController;
using MWCore.Areas.MWCore.Models.Modules.Taxes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MWCore.Areas.MWCore.Controllers
{
    public class TaxesControlController : MWCoreController
    {
        // GET: MWCore/TaxesControl
        public ActionResult Index()
        {
            MWCoreModel oModel = new MWCoreModel();
            TaxesCOM oTaxesCOM = new TaxesCOM();
            oModel.lstTaxes = oTaxesCOM.GetTaxes(oModel.oSystemLanguage.ID);
            return View(oModel);
        }
        public ActionResult AddEditTax(int? TaxID)
        {
            MWCoreModel oModel = new MWCoreModel();
            if (TaxID != null && TaxID > 0)
            {
                TaxesCOM oTaxesCOM = new TaxesCOM();
                oModel.oTaxes = oTaxesCOM.GetTaxDetails((int)TaxID, oModel.oSystemLanguage.ID);
            }
            else
            {
                oModel.oTaxes = new TaxesModel();
                oModel.oTaxes.LanguageID = oModel.oSystemLanguage.ID;
            }
            return PartialView("_AddEditTax", oModel);
        }
        public ActionResult SaveTax(MWCoreModel oModel)
        {
            TaxesCOM oTaxesCOM = new TaxesCOM();
            oModel.lstTaxes = oTaxesCOM.SaveTax(oModel.oTaxes, oModel.lstSystemLanguages);
            return PartialView("_Taxes", oModel);
        }
        public ActionResult DeleteTax(int TaxID)
        {
            MWCoreModel oModel = new MWCoreModel();
            TaxesCOM oTaxesCOM = new TaxesCOM();
            oModel.lstTaxes = oTaxesCOM.DeleteTax(TaxID, oModel.oSystemLanguage.ID);
            return PartialView("_Taxes", oModel);
        }
        public ActionResult ChangeStatus(int TaxID)
        {
            MWCoreModel oModel = new MWCoreModel();
            TaxesCOM oTaxesCOM = new TaxesCOM();
            oModel.lstTaxes = oTaxesCOM.ChangeStatus(TaxID, oModel.oSystemLanguage.ID);
            return PartialView("_Taxes", oModel);
        }
    }
}