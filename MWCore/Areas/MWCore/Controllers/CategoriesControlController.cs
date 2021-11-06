using MWCore.Areas.MWCore.Models;
using MWCore.Areas.MWCore.Models.BaseController;
using MWCore.Areas.MWCore.Models.Modules.Categories;
using MWCore.Areas.MWCore.Models.Modules.Colors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MWCore.Areas.MWCore.Controllers
{
    public class CategoriesControlController : MWCoreController
    {
        // GET: MWCore/CategoriesControl
        public ActionResult Index()
        {
            MWCoreModel oModel = new MWCoreModel();
            CategoriesCOM oCategoriesCOM = new CategoriesCOM();
            oModel.lstCategories = oCategoriesCOM.GetCategories(oModel.oSystemLanguage.ID);
            return View(oModel);
        }

        public ActionResult AddEditCategories(int? CategoryID)
        {
            MWCoreModel oModel = new MWCoreModel();
            oModel.lstColorsItemsList = ColorsCOM.GetColorsList(oModel.oSystemLanguage.ID);
            if (CategoryID != null && CategoryID > 0)
            {
                CategoriesCOM oCategoriesCOM = new CategoriesCOM();
                oModel.oCategories = oCategoriesCOM.GetCategoryDetails((int)CategoryID, oModel.oSystemLanguage.ID);
            }
            else
            {
                oModel.oCategories = new CategoriesModel();
                oModel.oCategories.LanguageID = oModel.oSystemLanguage.ID;
            }
            return PartialView("_AddEditCategories", oModel);
        }

        public ActionResult SaveCategory(MWCoreModel oModel)
        {
            CategoriesCOM oCategoriesCOM = new CategoriesCOM();
            oModel.lstCategories = oCategoriesCOM.SaveCategory(oModel);
            return PartialView("_Categories", oModel);
        }

        public ActionResult DeleteCategory(int CategoryID)
        {
            MWCoreModel oModel = new MWCoreModel();
            CategoriesCOM oCategoriesCOM = new CategoriesCOM();
            oModel.lstCategories = oCategoriesCOM.DeleteCategory(CategoryID, oModel.oSystemLanguage.ID);
            return PartialView("_Categories", oModel);
        }

        public ActionResult ChangeStatus(int CategoryID)
        {
            MWCoreModel oModel = new MWCoreModel();
            CategoriesCOM oCategoriesCOM = new CategoriesCOM();
            oModel.lstCategories = oCategoriesCOM.ChangeStatus(CategoryID, oModel.oSystemLanguage.ID);
            return PartialView("_Categories", oModel);
        }

    }
}