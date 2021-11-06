/*****************************************************************************/
/* File Name     : GroupPoliciesCOM.cs                                      */
/* Created By    : Sara Jouma                                              */
/* Creation Date : 9/01/2018                                              */
/* Comment       : GroupPoliciesCOM Module Class                         */
/************************************************************************/

using MWCore.Areas.MWCore.Models.DBClasses;
using MWCore.Areas.MWCore.Models.DBClasses.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace MWCore.Areas.MWCore.Models.Modules.GroupPolicies
{
    public class GroupPoliciesCOM
    {
        #region Method :: GetGroupPolicies
        public List<MW_GroupPolicies> GetGroupPolicies()
        {
            using (MWCoreEntity db = new MWCoreEntity())
            {
                return db.MW_GroupPolicies.Where(x => !x.IsDeleted).ToList();
            }
        }
        #endregion

        #region Method :: GetGroupPoliciesDetails
        public MW_GroupPolicies GetGroupPoliciesDetails(int GroupPoliciesID)
        {
            using (MWCoreEntity db = new MWCoreEntity())
            {
                return db.MW_GroupPolicies.Where(x => x.ID == GroupPoliciesID && !x.IsDeleted).SingleOrDefault();
            }
        }
        #endregion

        #region Method :: SaveGroupPoliciesID
        public List<MW_GroupPolicies> SaveGroupPolicies(MWCoreModel oModel)
        {
            using (MWCoreEntity db = new MWCoreEntity())
            {
                MW_GroupPolicies oGroupPolicies = new MW_GroupPolicies();
                if (oModel.oGroupPolicies.ID > 0)
                {
                    oGroupPolicies = db.MW_GroupPolicies.Single(x => x.ID == oModel.oGroupPolicies.ID);
                }
                oGroupPolicies.GroupName = oModel.oGroupPolicies.GroupName;

                if (oModel.oGroupPolicies.ID > 0)
                {

                }
                else
                {
                    db.MW_GroupPolicies.Add(oGroupPolicies);
                }
                db.SaveChanges();
                return db.MW_GroupPolicies.Where(x => !x.IsDeleted).ToList();
            }
        }
        #endregion

        #region Method :: DeleteGroupPolicies
        public List<MW_GroupPolicies> DeleteGroupPolicies(int GroupPoliciesID)
        {
            using (MWCoreEntity db = new MWCoreEntity())
            {
                MW_GroupPolicies oGroupPolicies = db.MW_GroupPolicies.Single(x => x.ID == GroupPoliciesID);
                if (oGroupPolicies != null)
                {
                    oGroupPolicies.IsDeleted = true;
                    db.SaveChanges();
                }
                return db.MW_GroupPolicies.ToList();
            }
        }
        #endregion

        #region Method :: GetGroupPoliciesName
        public static string GetGroupPoliciesName(int GroupPoliciesID)
        {
            string GroupName = string.Empty;
            using (MWCoreEntity db = new MWCoreEntity())
            {
                var oGroupPolicy = db.MW_GroupPolicies.Where(x => x.ID == GroupPoliciesID && !x.IsDeleted).SingleOrDefault();
                if (oGroupPolicy != null)
                {
                    GroupName = oGroupPolicy.GroupName;
                }
            }
            return GroupName;
        }
        #endregion
    }
}