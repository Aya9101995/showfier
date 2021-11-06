/*****************************************************************************/
/* File Name     : AccountCOM.cs                                            */
/* Created By    : Abdulla Hawwash                                         */
/* Creation Date : 19/12/2017                                             */
/* Comment       : Account                                               */
/************************************************************************/

using MWCore.Areas.MWCore.Models.DBClasses;
using MWCore.Areas.MWCore.Models.DBClasses.Banners;
using System.Collections.Generic;
using System.Linq;

namespace MWCore.Areas.MWCore.Models.Modules.Banners
{
    public class BannersCOM
    {
        public List<BannersModel> GetBanners(bool Status = false)
        {
            using (MWCoreEntity db = new MWCoreEntity())
            {
                List<BannersModel> lstBanners = (from banner in db.MW_Banners
                                                 where !banner.IsDeleted
                                                 && (Status == true ? banner.Status == true : true)
                                                 select new BannersModel()
                                                 {
                                                     BannerID = banner.ID,
                                                     ImagePath = banner.ImagePath,
                                                     Status = banner.Status
                                                 }).ToList();

                return lstBanners;
            }
        }

        public BannersModel GetBannerDetails(int BannerID)
        {
            using (MWCoreEntity db = new MWCoreEntity())
            {
                return (from banner in db.MW_Banners
                        where banner.ID == BannerID && !banner.IsDeleted
                        select new BannersModel()
                        {
                            BannerID = banner.ID,
                            ImagePath = banner.ImagePath,
                            Status = banner.Status
                        }).FirstOrDefault();
            }
        }

        public List<BannersModel> SaveBanner(BannersModel oModel)
        {
            using (MWCoreEntity db = new MWCoreEntity())
            {
                MW_Banners oBanner = new MW_Banners();
                if (oModel.BannerID > 0)
                {
                    oBanner = db.MW_Banners.FirstOrDefault(x => x.ID == oModel.BannerID);
                }
                oBanner.ImagePath = oModel.ImagePath;
                oBanner.Status = oModel.Status;
                if (oModel.BannerID == 0)
                {
                    db.MW_Banners.Add(oBanner);
                }
                db.SaveChanges();
                return GetBanners();
            }
        }

        public List<BannersModel> ChangeStatus(int BannerID)
        {
            using (MWCoreEntity db = new MWCoreEntity())
            {
                MW_Banners oBanner = db.MW_Banners.FirstOrDefault(x => x.ID == BannerID);
                oBanner.Status = oBanner.Status == true ? false : true;
                db.SaveChanges();
                return GetBanners();
            }
        }

        public List<BannersModel> DeleteBanner(int BannerID)
        {
            using (MWCoreEntity db = new MWCoreEntity())
            {
                MW_Banners oBanner = db.MW_Banners.FirstOrDefault(x => x.ID == BannerID);
                oBanner.IsDeleted = true;
                db.SaveChanges();
                return GetBanners();
            }
        }


    }
}