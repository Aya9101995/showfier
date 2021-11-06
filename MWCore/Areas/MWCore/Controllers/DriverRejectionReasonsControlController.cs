using MWCore.Areas.MWCore.Models;
using MWCore.Areas.MWCore.Models.BaseController;
using MWCore.Areas.MWCore.Models.Modules.DriverRejectionReasons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MWCore.Areas.MWCore.Controllers
{
    public class DriverRejectionReasonsControlController : MWCoreController
    {
        // GET: MWCore/DriverRejectionReasonsControl
        public ActionResult Index()
        {
            MWCoreModel oModel = new MWCoreModel();
            DriverRejectionReasonsCOM oRejectionReasonsCOM = new DriverRejectionReasonsCOM();
            oModel.lstDriverRejectionReasons = oRejectionReasonsCOM.GetRejectionReasons(oModel.oSystemLanguage.ID);
            return View(oModel);
        }
        public ActionResult AddEditRejectionReason(int? RejectionID)
        {
            MWCoreModel oModel = new MWCoreModel();
            if (RejectionID != null && RejectionID > 0)
            {
                DriverRejectionReasonsCOM oRejectionReasonsCOM = new DriverRejectionReasonsCOM();
                oModel.oDriverRejectionReasons = oRejectionReasonsCOM.GetRejectionReasonDetails((int)RejectionID, oModel.oSystemLanguage.ID);
            }
            else
            {
                oModel.oDriverRejectionReasons = new DriverRejectionReasonsModel();
                oModel.oDriverRejectionReasons.LanguageID = oModel.oSystemLanguage.ID;
            }
            return PartialView("_AddEditRejectionReason", oModel);
        }

        public ActionResult SaveRejectionReason(MWCoreModel oModel)
        {
            DriverRejectionReasonsCOM oRejectionReasonsCOM = new DriverRejectionReasonsCOM();
            oModel.lstDriverRejectionReasons = oRejectionReasonsCOM.SaveRejectionReason(oModel.oDriverRejectionReasons, oModel.lstSystemLanguages);
            return PartialView("_RejectionReasons", oModel);
        }

        public ActionResult DeleteRejectionReason(int RejectionID)
        {
            MWCoreModel oModel = new MWCoreModel();
            DriverRejectionReasonsCOM oRejectionReasonsCOM = new DriverRejectionReasonsCOM();
            oModel.lstDriverRejectionReasons = oRejectionReasonsCOM.DeleteRejectionReason(RejectionID, oModel.oSystemLanguage.ID);
            return PartialView("_RejectionReasons", oModel);
        }

        public ActionResult ChangeStatus(int RejectionID)
        {
            MWCoreModel oModel = new MWCoreModel();
            DriverRejectionReasonsCOM oRejectionReasonsCOM = new DriverRejectionReasonsCOM();
            oModel.lstDriverRejectionReasons = oRejectionReasonsCOM.ChangeStatus(RejectionID, oModel.oSystemLanguage.ID);
            return PartialView("_RejectionReasons", oModel);
        }
    }
}