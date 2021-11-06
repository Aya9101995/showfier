using MWCore.Areas.MWCore.Models.DBClasses;
using MWCore.Areas.MWCore.Models.DBClasses.UserRejectionReasons;
using MWCore.Areas.MWCore.Models.Modules.SystemLanguages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MWCore.Areas.MWCore.Models.Modules.UserRejectionReasons
{
    public class UserRejectionReasonsCOM
    {
        #region GetRejectionReasons
        public List<UserRejectionReasonsModel> GetRejectionReasons(int languageID)
        {
            using (MWCoreEntity db = new MWCoreEntity())
            {
                return (from rejection in db.MW_UserRejectionReasons
                        join rejection_loc in db.MW_UserRejectionReasons_Loc on rejection.ID equals rejection_loc.RejectionReasonID
                        where rejection_loc.LanguageID == languageID && !rejection.IsDeleted
                        select new UserRejectionReasonsModel()
                        {
                            RejectionID = rejection.ID,
                            RejectionName = rejection_loc.RejectionName,
                            Status = rejection.Status,
                            LanguageID = languageID
                        }).ToList();
            }
        }
        #endregion

        #region DeleteRejectionReason
        public List<UserRejectionReasonsModel> DeleteRejectionReason(int RejectionID, int LanguageID)
        {
            using (MWCoreEntity db = new MWCoreEntity())
            {
                MW_UserRejectionReasons rejection = db.MW_UserRejectionReasons.Where(x => x.ID == RejectionID).FirstOrDefault();
                if (rejection != null)
                {
                    rejection.IsDeleted = true;
                    db.SaveChanges();
                }
                return GetRejectionReasons(LanguageID);
            }
        }
        #endregion

        #region ChangeStatus
        public List<UserRejectionReasonsModel> ChangeStatus(int RejectionID, int LanguageID)
        {
            using (MWCoreEntity db = new MWCoreEntity())
            {
                MW_UserRejectionReasons rejection = db.MW_UserRejectionReasons.Where(x => x.ID == RejectionID).FirstOrDefault();
                if (rejection != null)
                {
                    rejection.Status = rejection.Status == true ? false : true;
                    db.SaveChanges();
                }
                return GetRejectionReasons(LanguageID);
            }
        }
        #endregion

        #region Method :: GetRejectionReasonDetails
        public UserRejectionReasonsModel GetRejectionReasonDetails(int RejectionID, int LanguageID)
        {
            using (MWCoreEntity db = new MWCoreEntity())
            {
                return (from rejection in db.MW_UserRejectionReasons
                        join rejection_loc in db.MW_UserRejectionReasons_Loc on rejection.ID equals rejection_loc.RejectionReasonID
                        where rejection_loc.LanguageID == LanguageID && !rejection.IsDeleted && rejection.ID == RejectionID
                        select new UserRejectionReasonsModel()
                        {
                            RejectionID = rejection.ID,
                            RejectionName = rejection_loc.RejectionName,
                            Status = rejection.Status,
                            LanguageID = LanguageID
                        }).FirstOrDefault();
            }
        }
        #endregion

        #region Method :: SaveRejectionReason
        public List<UserRejectionReasonsModel> SaveRejectionReason(UserRejectionReasonsModel oModel, List<SystemLanguagesModel> lstLanguages)
        {
            using (MWCoreEntity db = new MWCoreEntity())
            {
                MW_UserRejectionReasons oRejectionReasons = new MW_UserRejectionReasons();
                MW_UserRejectionReasons_Loc oRejectionReasons_Loc = new MW_UserRejectionReasons_Loc();
                if (oModel.RejectionID > 0)
                {
                    oRejectionReasons_Loc = db.MW_UserRejectionReasons_Loc.Single(x => x.RejectionReasonID == oModel.RejectionID && x.LanguageID == oModel.LanguageID);
                    oRejectionReasons = db.MW_UserRejectionReasons.FirstOrDefault(x => x.ID == oRejectionReasons_Loc.RejectionReasonID);
                }

                oRejectionReasons.IsDeleted = false;
                oRejectionReasons.Status = oModel.Status;
                oRejectionReasons_Loc.RejectionName = oModel.RejectionName;
                oRejectionReasons_Loc.LanguageID = oModel.LanguageID;

                if (oModel.RejectionID == 0)
                {
                    db.MW_UserRejectionReasons.Add(oRejectionReasons);
                    db.SaveChanges();
                    oRejectionReasons_Loc.RejectionReasonID = oRejectionReasons.ID;
                    db.MW_UserRejectionReasons_Loc.Add(oRejectionReasons_Loc);
                    int nCount = lstLanguages.Count - 1;
                    for (int nIndex = 0; nIndex <= nCount; nIndex++)
                    {
                        MW_UserRejectionReasons_Loc oRejectionReasonLoc = new MW_UserRejectionReasons_Loc();
                        oRejectionReasonLoc.RejectionReasonID = oRejectionReasons.ID;
                        oRejectionReasonLoc.RejectionName = oModel.RejectionName;
                        oRejectionReasonLoc.LanguageID = lstLanguages[nIndex].LanguageID;
                        db.MW_UserRejectionReasons_Loc.Add(oRejectionReasonLoc);
                    }
                }
                db.SaveChanges();
                return GetRejectionReasons(oModel.LanguageID);
            }
        }
        #endregion

        #region Method :: GetRejectionReasonsAPI
        public List<UserRejectionReasonsModel> GetRejectionReasonsAPI(int LanguageID)
        {
            using (MWCoreEntity db = new MWCoreEntity())
            {
                return (from rejection in db.MW_UserRejectionReasons
                        join rejection_loc in db.MW_UserRejectionReasons_Loc on rejection.ID equals rejection_loc.RejectionReasonID
                        where rejection_loc.LanguageID == LanguageID && !rejection.IsDeleted && rejection.Status == true
                        select new UserRejectionReasonsModel()
                        {
                            RejectionID = rejection.ID,
                            Status = rejection.Status,
                            RejectionName = rejection_loc.RejectionName,
                            LanguageID = LanguageID
                        }).ToList();
            }
        }
        #endregion

        #region Method :: GetRejectionReasonsList
        public static List<SelectListItem> GetRejectionReasonsList(int LanguageID)
        {
            using (MWCoreEntity db = new MWCoreEntity())
            {
                return (from rejection in db.MW_UserRejectionReasons
                        join rejection_loc in db.MW_UserRejectionReasons_Loc on rejection.ID equals rejection_loc.RejectionReasonID
                        where rejection_loc.LanguageID == LanguageID && !rejection.IsDeleted
                        select new SelectListItem()
                        {
                            Text = rejection_loc.RejectionName,
                            Value = rejection_loc.RejectionReasonID.ToString()
                        }).ToList();
            }
        }
        #endregion
    }
}