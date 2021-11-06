using MWCore.Areas.MWCore.Models;
using MWCore.Areas.MWCore.Models.BaseController;
using MWCore.Areas.MWCore.Models.DBClasses;
using MWCore.Areas.MWCore.Models.DBClasses.Tutorials;
using MWCore.Areas.MWCore.Models.Modules.Tutorials;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MWCore.Areas.MWCore.Controllers
{
    public class TutorialsControlController : MWCoreController
    {
        // GET: MWCore/TutorialsControl
        public ActionResult Index()
        {
            MWCoreModel oModel = new MWCoreModel();
            TutorialsCOM oTutorialsCOM = new TutorialsCOM();
            oModel.lstTutorials = oTutorialsCOM.GetTutorials(oModel.oSystemLanguage.ID);
            return View(oModel);
        }
        public ActionResult AddEditTutorials(int? TutorialID)
        {
            MWCoreModel oModel = new MWCoreModel();
            if (TutorialID != null && TutorialID > 0)
            {
                TutorialsCOM oTutorialsCOM = new TutorialsCOM();
                oModel.oTutorial = oTutorialsCOM.GetTutorialDetails((int)TutorialID, oModel.oSystemLanguage.ID);
            }
            else
            {
                oModel.oTutorial = new TutorialsModel();
                oModel.oTutorial.LanguageID = oModel.oSystemLanguage.ID;
            }
            using (MWCoreEntity db = new MWCoreEntity())
            {
                List<MW_Tutorials> lstTutorials = db.MW_Tutorials.OrderBy(x => x.SortOrder).ToList();
                List<int> lstsortOrder = new List<int>();
                foreach (var item in lstTutorials)
                {
                    if (item.SortOrder != oModel.oTutorial.SortOrder)
                    {
                        lstsortOrder.Add(Convert.ToInt32(item.SortOrder));

                    }
                }
                oModel.lstSortOrder = lstsortOrder;
            }
            return PartialView("_AddEditTutorials", oModel);
        }

        public ActionResult SaveTutorial(MWCoreModel oModel)
        {
            TutorialsCOM oTutorialsCOM = new TutorialsCOM();
            oModel.lstTutorials = oTutorialsCOM.SaveTutorial(oModel.oTutorial, oModel.lstSystemLanguages);
            return PartialView("_Tutorials", oModel);
        }

        public ActionResult DeleteTutorial(int TutorialID)
        {
            MWCoreModel oModel = new MWCoreModel();
            TutorialsCOM oTutorialsCOM = new TutorialsCOM();
            oModel.lstTutorials = oTutorialsCOM.DeleteTutorial(TutorialID, oModel.oSystemLanguage.ID);
            return PartialView("_Tutorials", oModel);
        }

        public ActionResult ChangeStatus(int TutorialID)
        {
            MWCoreModel oModel = new MWCoreModel();
            TutorialsCOM oTutorialsCOM = new TutorialsCOM();
            oModel.lstTutorials = oTutorialsCOM.ChangeStatus(TutorialID, oModel.oSystemLanguage.ID);
            return PartialView("_Tutorials", oModel);
        }
    }
}