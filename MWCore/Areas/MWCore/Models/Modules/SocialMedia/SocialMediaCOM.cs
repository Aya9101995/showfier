/*****************************************************************************/
/* File Name     : SocialMediaCOM.cs                                        */
/* Created By    : Abdulla Hawwash                                         */
/* Creation Date : 19/12/2017                                             */
/* Comment       : Social Media                                          */
/************************************************************************/

using MWCore.Areas.MWCore.Models.DBClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using MWCore.Areas.MWCore.Models.DBClasses.SocialMedia;

namespace MWCore.Areas.MWCore.Models.Modules.SocialMedia
{
    public class SocialMediaCOM
    {
        #region Method :: GetSocialMedia
        public List<MW_SocialMedia> GetSocialMedia()
        {
            using (MWCoreEntity db = new MWCoreEntity())
            {
                return db.MW_SocialMedia.OrderBy(x => x.SortOrder).ToList();
            }
        }



        public List<MW_SocialMedia> GetSocialMediaFrontEnd()
        {
            using (MWCoreEntity db = new MWCoreEntity())
            {
                return db.MW_SocialMedia.Where(a => a.Status == true).OrderBy(x => x.SortOrder).ToList();
            }
        }

        public List<SocialMediaModel> GetSocialMediaMobile()
        {
            using (MWCoreEntity db = new MWCoreEntity())
            {
                return (from sm in db.MW_SocialMedia.Where(a => a.Status == true).OrderBy(x => x.SortOrder)
                        select new SocialMediaModel
                        {
                            SocialMediaIcon = sm.SocialMediaIcon,
                            SocialMediaLink = sm.SocialMediaLink,
                            SocialMediaType = sm.SocialMediaType
                        }
                        ).ToList();
            }
        }

        #endregion

        #region Method :: GetSocialMediaDetails
        public MW_SocialMedia GetSocialMediaDetails(int SocialMediaID)
        {
            using (MWCoreEntity db = new MWCoreEntity())
            {
                return db.MW_SocialMedia.Where(x => x.ID == SocialMediaID).SingleOrDefault();
            }
        }
        #endregion

        #region Method :: SaveSocialMedia
        public List<MW_SocialMedia> SaveSocialMedia(MWCoreModel oModel)
        {
            using (MWCoreEntity db = new MWCoreEntity())
            {
                MW_SocialMedia oSocialMedia = new MW_SocialMedia();
                if (oModel.oSocialMedia.ID > 0)
                {
                    oSocialMedia = db.MW_SocialMedia.Single(x => x.ID == oModel.oSocialMedia.ID);
                }
                oSocialMedia.Status = false;
                oSocialMedia.SortOrder = oModel.oSocialMedia.SortOrder;
                oSocialMedia.SocialMediaType = oModel.oSocialMedia.SocialMediaType;
                oSocialMedia.SocialMediaLink = oModel.oSocialMedia.SocialMediaLink;
                oSocialMedia.SocialMediaIcon = oModel.oSocialMedia.SocialMediaIcon;
                if (oModel.oSocialMedia.ID > 0)
                {
                    oSocialMedia.UpdatedBy = oModel.oUserInfo.ID;
                    oSocialMedia.UpdatedDate = DateTime.Today;
                }
                else
                {
                    oSocialMedia.CreatedBy = oModel.oUserInfo.ID;
                    oSocialMedia.CreatedDate = DateTime.Today;
                    db.MW_SocialMedia.Add(oSocialMedia);
                }
                db.SaveChanges();
                return db.MW_SocialMedia.OrderBy(x => x.SortOrder).ToList();
            }
        }
        #endregion

        #region Method :: DeleteSocialMedia
        public List<MW_SocialMedia> DeleteSocialMedia(int SocialMediaID)
        {
            using (MWCoreEntity db = new MWCoreEntity())
            {
                MW_SocialMedia oSocialMedia = db.MW_SocialMedia.Single(x => x.ID == SocialMediaID);
                if (oSocialMedia != null)
                {
                    db.MW_SocialMedia.Remove(oSocialMedia);
                    db.SaveChanges();
                }
                return db.MW_SocialMedia.OrderBy(x => x.SortOrder).ToList();
            }
        }
        #endregion

        #region Method :: ChangeStatus
        public List<MW_SocialMedia> ChangeStatus(int SocialMediaID)
        {
            using (MWCoreEntity db = new MWCoreEntity())
            {
                MW_SocialMedia oSocialMedia = db.MW_SocialMedia.Single(x => x.ID == SocialMediaID);
                if (oSocialMedia != null)
                {
                    oSocialMedia.Status = oSocialMedia.Status == true ? false : true;
                    db.SaveChanges();
                }
                return db.MW_SocialMedia.OrderBy(x => x.SortOrder).ToList();
            }
        } 
        #endregion

        public static List<SocialMediaModel> GetSocialMediaForWeb()
        {
            using (MWCoreEntity db = new MWCoreEntity())
            {
                return (from sm in db.MW_SocialMedia.Where(a => a.Status == true).OrderBy(x => x.SortOrder)
                        select new SocialMediaModel
                        {
                            SocialMediaIcon = sm.SocialMediaIcon,
                            SocialMediaLink = sm.SocialMediaLink,
                            SocialMediaType = sm.SocialMediaType
                        }
                        ).ToList();
            }
        }
    }
}