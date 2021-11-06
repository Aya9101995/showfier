using MWCore.Areas.MWCore.Models;
using MWCore.Areas.MWCore.Models.BaseController;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MWCore.Areas.MWCore.Models.Modules.GroupPolicies;

namespace MWCore.Areas.MWCore.Controllers
{
    public class GroupPoliciesController : MWCoreController
    {
        // GET: MWCore/GroupPolicies
        #region ActionResult :: Index
        public ActionResult Index()
        {
            MWCoreModel oModel = new MWCoreModel();
            GroupPoliciesCOM oGroupPolicies = new GroupPoliciesCOM();
            oModel.lstGroupPolicies = oGroupPolicies.GetGroupPolicies();
            return View(oModel);
        }
        #endregion

        #region ActionResult :: AddEditoGroupPolicies
        public ActionResult AddEditoGroupPolicies(int? GroupPoliciesID)
        {
            MWCoreModel oModel = new MWCoreModel();
            GroupPoliciesCOM oGroupPolicies = new GroupPoliciesCOM();
            if (GroupPoliciesID != null && GroupPoliciesID > 0)
            {

                oModel.oGroupPolicies = oGroupPolicies.GetGroupPoliciesDetails((int)GroupPoliciesID);
            }
            else
            {

                oModel.oGroupPolicies = new Models.DBClasses.Users.MW_GroupPolicies();

            }
            return PartialView("_AddEditGroupPolicies", oModel);
        }
        #endregion

        #region ActionResult :: SaveGroupPolicies
        public ActionResult SaveGroupPolicies(MWCoreModel oModel)
        {
            GroupPoliciesCOM oGroupPolicies = new GroupPoliciesCOM();
            oModel.lstGroupPolicies = oGroupPolicies.SaveGroupPolicies(oModel);
            return PartialView("_GroupPolicies", oModel);
        }
        #endregion

        #region ActionResult :: DeleteGroupPolicies
        public ActionResult DeleteGroupPolicies(int GroupPoliciesID)
        {
            MWCoreModel oModel = new MWCoreModel();
            GroupPoliciesCOM oGroupPolicies = new GroupPoliciesCOM();
            oModel.lstGroupPolicies = oGroupPolicies.DeleteGroupPolicies(GroupPoliciesID);
            return PartialView("_GroupPolicies", oModel);
        }
        #endregion
    }
}