using MWCore.Areas.MWCore.Models;
using MWCore.Areas.MWCore.Models.BaseController;
using MWCore.Areas.MWCore.Models.Modules.UserRejectionReasons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MWCore.Areas.MWCore.Controllers
{
    public class UserRejectionReasonsControlController : MWCoreController
    {
        // GET: MWCore/UserRejectionReasonsControl

        public ActionResult Index()
        {
            MWCoreModel oModel = new MWCoreModel();
            UserRejectionReasonsCOM oRejectionReasonsCOM = new UserRejectionReasonsCOM();
            oModel.lstUserRejectionReasons = oRejectionReasonsCOM.GetRejectionReasons(oModel.oSystemLanguage.ID);
            return View(oModel);
        }
        public ActionResult AddEditRejectionReason(int? RejectionID)
        {
            MWCoreModel oModel = new MWCoreModel();
            if (RejectionID != null && RejectionID > 0)
            {
                UserRejectionReasonsCOM oRejectionReasonsCOM = new UserRejectionReasonsCOM();
                oModel.oUserRejectionReasons = oRejectionReasonsCOM.GetRejectionReasonDetails((int)RejectionID, oModel.oSystemLanguage.ID);
            }
            else
            {
                oModel.oUserRejectionReasons = new UserRejectionReasonsModel();
                oModel.oUserRejectionReasons.LanguageID = oModel.oSystemLanguage.ID;
            }
            return PartialView("_AddEditRejectionReason", oModel);
        }

        public ActionResult SaveRejectionReason(MWCoreModel oModel)
        {
            UserRejectionReasonsCOM oRejectionReasonsCOM = new UserRejectionReasonsCOM();
            oModel.lstUserRejectionReasons = oRejectionReasonsCOM.SaveRejectionReason(oModel.oUserRejectionReasons, oModel.lstSystemLanguages);
            return PartialView("_RejectionReasons", oModel);
        }

        public ActionResult DeleteRejectionReason(int RejectionID)
        {
            MWCoreModel oModel = new MWCoreModel();
            UserRejectionReasonsCOM oRejectionReasonsCOM = new UserRejectionReasonsCOM();
            oModel.lstUserRejectionReasons = oRejectionReasonsCOM.DeleteRejectionReason(RejectionID, oModel.oSystemLanguage.ID);
            return PartialView("_RejectionReasons", oModel);
        }

        public ActionResult ChangeStatus(int RejectionID)
        {
            MWCoreModel oModel = new MWCoreModel();
            UserRejectionReasonsCOM oRejectionReasonsCOM = new UserRejectionReasonsCOM();
            oModel.lstUserRejectionReasons = oRejectionReasonsCOM.ChangeStatus(RejectionID, oModel.oSystemLanguage.ID);
            return PartialView("_RejectionReasons", oModel);
        }
    }
}