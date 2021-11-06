using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using MWCore.Areas.MWCore.Models.DBClasses;
using System.Web.Mvc;
using MWCore.Areas.MWCore.Models.Modules.Account;
using System.Threading.Tasks;
using MWCore.Areas.MWCore.Models.DBClasses.Users;

namespace MWCore.Areas.MWCore.Models.Modules.Users
{
    public class UsersCOM
    {
        #region Method :: GetUsers
        public List<MW_Users> GetUsers()
        {
            using (MWCoreEntity db = new MWCoreEntity())
            {
                return db.MW_Users.Include(x => x.MW_GroupPolicies).Where(x => x.ID != 1 && !x.IsDeleted).ToList();
            }
        }
        #endregion

        #region Method :: GetUserDetails
        public MW_Users GetUserDetails(int UserID)
        {
            using (MWCoreEntity db = new MWCoreEntity())
            {
                return db.MW_Users.Include(x => x.MW_GroupPolicies).Where(x => x.ID == UserID).SingleOrDefault();
            }
        }
        #endregion

        #region Method :: SaveUser
        public List<MW_Users> SaveUser(MWCoreModel oModel)
        {
            using (MWCoreEntity db = new MWCoreEntity())
            {
                MW_Users oUser = new MW_Users();
                if (oModel.oUser.ID > 0)
                {
                    oUser = db.MW_Users.Single(x => x.ID == oModel.oUser.ID);
                }
                oUser.FullName = oModel.oUser.FullName;
                oUser.Email = oModel.oUser.Email;
                oUser.Mobile = oModel.oUser.Mobile;
                oUser.Username = oModel.oUser.Username;
                oUser.UserImage = oModel.oUser.UserImage;
                oUser.PolicyGroupID = oModel.oUser.PolicyGroupID;
                oUser.Status = oModel.oUser.Status;
                oUser.CanPublish = oModel.oUser.CanPublish;
                oUser.IsDeleted = false;
                if (oModel.oUser.ID > 0)
                {

                }
                else
                {
                    AccountCOM _AccountCOM = new AccountCOM();
                    string sPassword = _AccountCOM.GetMd5Hash(oModel.oUser.Password);
                    oUser.Password = sPassword;
                    db.MW_Users.Add(oUser);
                }
                db.SaveChanges();
                return db.MW_Users.Include(x => x.MW_GroupPolicies).Where(x => x.ID != 1 && !x.IsDeleted).ToList();
            }
        }
        #endregion

        #region Method :: DeleteUser
        public List<MW_Users> DeleteUser(int UserID)
        {
            using (MWCoreEntity db = new MWCoreEntity())
            {
                MW_Users oUser = db.MW_Users.Single(x => x.ID == UserID);
                if (oUser != null)
                {
                    oUser.IsDeleted = true;
                    db.SaveChanges();
                }
                return db.MW_Users.Include(x => x.MW_GroupPolicies).Where(x => x.ID != 1 && !x.IsDeleted).ToList();
            }
        }
        #endregion

        #region Method :: ChangeStatus
        public List<MW_Users> ChangeStatus(int UserID)
        {
            using (MWCoreEntity db = new MWCoreEntity())
            {
                MW_Users oUser = db.MW_Users.Single(x => x.ID == UserID);
                if (oUser != null)
                {
                    oUser.Status = oUser.Status == true ? false : true;
                    db.SaveChanges();
                }
                return db.MW_Users.Include(x => x.MW_GroupPolicies).Where(x => x.ID != 1 && !x.IsDeleted).ToList();
            }
        }
        #endregion

        #region Method :: Update User Profile
        public MW_Users UpdateUserProfile(MWCoreModel oModel)
        {
            using (MWCoreEntity db = new MWCoreEntity())
            {
                MW_Users oUser = new MW_Users();
                if (oModel.oUser.ID > 0)
                {
                    oUser = db.MW_Users.Single(x => x.ID == oModel.oUser.ID);
                    if (oUser != null)
                    {
                        oUser.FullName = oModel.oUser.FullName;
                        oUser.Email = oModel.oUser.Email;
                        oUser.Mobile = oModel.oUser.Mobile;
                        oUser.Username = oUser.Username;
                        oUser.UserImage = oModel.oUser.UserImage;
                        oUser.PolicyGroupID = oUser.PolicyGroupID;
                        oUser.Status = oUser.Status;
                        db.SaveChanges();
                    }

                }

                return oUser;
            }
        }
        #endregion

        #region Method :: GetGroupPoliciesList
        public List<SelectListItem> GetGroupPoliciesList()
        {
            using (MWCoreEntity db = new MWCoreEntity())
            {
                List<SelectListItem> lstGroupPoliciesList = new List<SelectListItem>();
                List<MW_GroupPolicies> lstGroupPolicies = db.MW_GroupPolicies.ToList();
                int nCount = lstGroupPolicies.Count - 1;
                for (int nIndex = 0; nIndex <= nCount; nIndex++)
                {
                    lstGroupPoliciesList.Add(new SelectListItem() { Text = lstGroupPolicies[nIndex].GroupName, Value = lstGroupPolicies[nIndex].ID.ToString() });
                }
                return lstGroupPoliciesList;
            }
        }
        #endregion

        public bool CheckUsername(MW_Users oUser)
        {
            using (MWCoreEntity db = new MWCoreEntity())
            {
                if (oUser.ID == 0)
                {
                    return !db.MW_Users.Any(x => x.Username == oUser.Username);
                }
                else
                {
                    return !db.MW_Users.Any(x => x.Username == oUser.Username && x.ID != oUser.ID);
                }
            }
        }
        public bool CheckEmail(MW_Users oUser)
        {
            using (MWCoreEntity db = new MWCoreEntity())
            {
                if (oUser.ID == 0)
                {
                    return !db.MW_Users.Any(x => x.Email == oUser.Email);
                }
                else
                {
                    return !db.MW_Users.Any(x => x.Email == oUser.Email && x.ID != oUser.ID);
                }
            }
        }
    }
}