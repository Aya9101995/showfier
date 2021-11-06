using MWCore.Areas.MWCore.Models;
using MWCore.Areas.MWCore.Models.BaseController;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MWCore.Areas.MWCore.Models.Modules.GroupPoliciesPermissions;

namespace MWCore.Areas.MWCore.Controllers
{
    public class GroupPoliciesPermissionsController : MWCoreController
    {
        // GET: MWCore/GroupPoliciesPermissions
        #region ActionResult :: Index
        public ActionResult Index(int GroupPolicyID)
        {
            MWCoreModel oModel = new MWCoreModel();
            GroupPoliciesPermissionsCOM oGroupPoliciesPermissionsCOM = new GroupPoliciesPermissionsCOM();
            oModel.lstGroupPoliciesPermessionClass = oGroupPoliciesPermissionsCOM.GetGroupPoliciesPermissions(GroupPolicyID);
            oModel.oGroupPolicies = new Models.DBClasses.Users.MW_GroupPolicies();
            oModel.oGroupPolicies.ID = GroupPolicyID;
            return View(oModel);
        }
        #endregion


        #region ActionResult :: SaveGroupPoliciesPermissions
        public ActionResult SaveGroupPoliciesPermissions(MWCoreModel oModel, FormCollection oForm)
        {
            GroupPoliciesPermissionsCOM oGroupPoliciesPermissionsCOM = new GroupPoliciesPermissionsCOM();
            oModel.SelectedPages = oForm.AllKeys.Where(x => x.ToLower().Contains("selectedpages_")).ToList().Select(x => x.Split('_')[1]).ToList();
            oModel.lstGroupPoliciesPermessionClass = oGroupPoliciesPermissionsCOM.SaveGroupPoliciesPermissions(oModel);
            return PartialView("_GroupPoliciesPermissions", oModel);
        }
        #endregion

        public JsonResult SavePermission(bool Checked, int PageID, int GroupPolicyID)
        {
            GroupPoliciesPermissionsCOM oGroupPoliciesPermissionsCOM = new GroupPoliciesPermissionsCOM();
            oGroupPoliciesPermissionsCOM.SavePermission(Checked, PageID, GroupPolicyID);
            return Json("Done", JsonRequestBehavior.AllowGet);
        }
    }
}