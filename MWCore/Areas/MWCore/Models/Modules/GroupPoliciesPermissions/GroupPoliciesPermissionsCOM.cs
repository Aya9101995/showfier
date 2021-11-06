/*****************************************************************************/
/* File Name     : GroupPoliciesPermissionsCOM.cs                           */
/* Created By    : Sara Jouma                                              */
/* Creation Date : 9/01/2018                                              */
/* Comment       : GroupPoliciesPermissionsCOM Module Class              */
/************************************************************************/
using MWCore.Areas.MWCore.Models.DBClasses;
using MWCore.Areas.MWCore.Models.DBClasses.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace MWCore.Areas.MWCore.Models.Modules.GroupPoliciesPermissions
{
    public class GroupPoliciesPermissionsCOM
    {
        #region Method :: GetGroupPoliciesPermissions
        public List<GroupPoliciesPermessionClass> GetGroupPoliciesPermissions(int GroupPolicyID)
        {
            using (MWCoreEntity db = new MWCoreEntity())
            {
                //List<GroupPoliciesPermessionClass> lstGroupPoliciesPermessionClass = (from page in db.MW_GroupPlociesPages
                //                                                                      join permission in db.MW_GroupPoliciesPermissions on page.ID equals permission.PageID into Permissions
                //                                                                      from permission in Permissions.DefaultIfEmpty()
                //                                                                      let p = permission
                //                                                                      from groups in db.MW_GroupPolicies
                //                                                                      where groups.ID == GroupPolicyID
                //                                                                      select new GroupPoliciesPermessionClass()
                //                                                                      {
                //                                                                          isChecked = p != null ? true : false,
                //                                                                          PageId = page.ID,
                //                                                                          PageName = page.PageName,
                //                                                                          ParentID = page.ParentID
                //                                                                      }).ToList();

                List<GroupPoliciesPermessionClass> lstGroupPoliciesPermessionClass = new List<GroupPoliciesPermessionClass>();
                var lstGroupPoliciesPermission = db.MW_GroupPoliciesPermissions.Where(x => x.GroupID == GroupPolicyID).ToList();
                var lstGroupPoliciesPages = GetGroupPoliciesPages();
                if (lstGroupPoliciesPages != null && lstGroupPoliciesPages.Count > 0)
                {
                    foreach (var item in lstGroupPoliciesPages)
                    {
                        GroupPoliciesPermessionClass oGroupPoliciesPermessionClass = new GroupPoliciesPermessionClass();
                        oGroupPoliciesPermessionClass.GroupId = GroupPolicyID;
                        oGroupPoliciesPermessionClass.PageId = item.ID;
                        oGroupPoliciesPermessionClass.ParentID = item.ParentID;
                        oGroupPoliciesPermessionClass.PageName = item.PageName;
                        oGroupPoliciesPermessionClass.PageTitle = item.PageTitle;
                        if (lstGroupPoliciesPermission.Any(x => x.PageID == item.ID && x.GroupID == GroupPolicyID))
                        {
                            oGroupPoliciesPermessionClass.isChecked = true;
                        }
                        else
                        {
                            oGroupPoliciesPermessionClass.isChecked = false;
                        }
                        lstGroupPoliciesPermessionClass.Add(oGroupPoliciesPermessionClass);
                    }

                }
                return lstGroupPoliciesPermessionClass;
            }
        }
        #endregion

        #region Method :: SaveGroupPoliciesPermissions
        public List<GroupPoliciesPermessionClass> SaveGroupPoliciesPermissions(MWCoreModel oModel)
        {
            using (MWCoreEntity db = new MWCoreEntity())
            {

                int GroupID = oModel.oGroupPolicies.ID;
                if (oModel.SelectedPages != null && oModel.SelectedPages.Count > 0)
                {
                    DeleteGroupPolicies(GroupID);

                    foreach (var item in oModel.SelectedPages)
                    {

                        MW_GroupPoliciesPermissions oGroupPoliciesPermissions = new MW_GroupPoliciesPermissions();
                        oGroupPoliciesPermissions.GroupID = GroupID;
                        oGroupPoliciesPermissions.PageID = Convert.ToInt32(item);
                        db.MW_GroupPoliciesPermissions.Add(oGroupPoliciesPermissions);
                        db.SaveChanges();



                    }

                }

                return GetGroupPoliciesPermissions(oModel.oGroupPolicies.ID);
                //List<GroupPoliciesPermessionClass> lstGroupPoliciesPermessionClass = new List<GroupPoliciesPermessionClass>();
                //var lstGroupPoliciesPermission = db.MW_GroupPoliciesPermissions.Where(x => x.GroupID == GroupID).ToList();
                //var lstGroupPoliciesPages = GetGroupPoliciesPages();
                //if (lstGroupPoliciesPages != null && lstGroupPoliciesPages.Count > 0)
                //{
                //    foreach (var item in lstGroupPoliciesPages)
                //    {
                //        GroupPoliciesPermessionClass oGroupPoliciesPermessionClass = new GroupPoliciesPermessionClass();
                //        oGroupPoliciesPermessionClass.GroupId = GroupID;
                //        oGroupPoliciesPermessionClass.PageId = item.ID;
                //        if (lstGroupPoliciesPermission.Any(x => x.PageID == item.ID && x.GroupID == GroupID))
                //        {
                //            oGroupPoliciesPermessionClass.isChecked = true;
                //        }
                //        else
                //        {
                //            oGroupPoliciesPermessionClass.isChecked = false;
                //        }
                //        lstGroupPoliciesPermessionClass.Add(oGroupPoliciesPermessionClass);
                //    }

                //}
                //return lstGroupPoliciesPermessionClass;
            }
        }
        #endregion
        public void SavePermission(bool Checked, int PageID, int GroupPolicyID)
        {
            using (MWCoreEntity db = new MWCoreEntity())
            {
                if(Checked)
                {
                    MW_GroupPoliciesPermissions oGroupPoliciesPermissions = db.MW_GroupPoliciesPermissions.FirstOrDefault(x => x.PageID == PageID && x.GroupID == GroupPolicyID);
                    if(oGroupPoliciesPermissions == null)
                    {
                        oGroupPoliciesPermissions = new MW_GroupPoliciesPermissions();
                        oGroupPoliciesPermissions.GroupID = GroupPolicyID;
                        oGroupPoliciesPermissions.PageID = PageID;
                        db.MW_GroupPoliciesPermissions.Add(oGroupPoliciesPermissions);
                        db.SaveChanges();
                    }
                }
                else
                {
                    MW_GroupPoliciesPermissions oGroupPoliciesPermissions = db.MW_GroupPoliciesPermissions.FirstOrDefault(x => x.PageID == PageID && x.GroupID == GroupPolicyID);
                    if(oGroupPoliciesPermissions!=null)
                    {
                        db.MW_GroupPoliciesPermissions.Remove(oGroupPoliciesPermissions);
                        db.SaveChanges();
                    }
                }
            }
        }
        #region Method :: DeleteGroupPoliciesPermission
        public static void DeleteGroupPolicies(int GroupPoliciesID)
        {
            using (MWCoreEntity db = new MWCoreEntity())
            {
                List<MW_GroupPoliciesPermissions> GroupPoliciesPermissionsLst = db.MW_GroupPoliciesPermissions.Where(x => x.GroupID == GroupPoliciesID).ToList();
                if (GroupPoliciesPermissionsLst != null && GroupPoliciesPermissionsLst.Count > 0)
                {
                    db.MW_GroupPoliciesPermissions.RemoveRange(GroupPoliciesPermissionsLst);
                    db.SaveChanges();
                }
            }
        }
        #endregion


        #region Method :: GetGroupPoliciesPages
        public static List<MW_GroupPlociesPages> GetGroupPoliciesPages()
        {
            using (MWCoreEntity db = new MWCoreEntity())
            {
                return db.MW_GroupPlociesPages.ToList();
            }
        }
        #endregion

        #region Method :: GetGroupPoliciesPageName
        public static string GetGroupPoliciesPageName(int GroupPoliciesPageId)
        {
            string PageName = string.Empty;
            using (MWCoreEntity db = new MWCoreEntity())
            {
                var oPage = db.MW_GroupPlociesPages.Where(x => x.ID == GroupPoliciesPageId).FirstOrDefault();
                if (oPage != null)
                {
                    PageName = oPage.PageTitle;

                }
            }
            return PageName;
        }
        #endregion
    }
}