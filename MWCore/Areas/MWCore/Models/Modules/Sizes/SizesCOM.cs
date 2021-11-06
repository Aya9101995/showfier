using MWCore.Areas.MWCore.Models.DBClasses;
using MWCore.Areas.MWCore.Models.DBClasses.Sizes;
using MWCore.Areas.MWCore.Models.Modules.SystemLanguages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MWCore.Areas.MWCore.Models.Modules.Sizes
{
    public class SizesCOM
    {
        #region Method :: GetSizes
        public List<SizesModel> GetSizes(int LanguageID)
        {
            using (MWCoreEntity db = new MWCoreEntity())
            {
                return (from Size in db.MW_Sizes
                        join Size_loc in db.MW_Sizes_Loc on Size.ID equals Size_loc.SizeID
                        where Size_loc.LanguageID == LanguageID && !Size.IsDeleted
                        select new SizesModel()
                        {
                            SizeID = Size.ID,
                            SizeName = Size_loc.SizeName,
                            IsDeleted = Size.IsDeleted,
                            LanguageID = LanguageID,
                            Status = Size.Status,
                        }).ToList();
            }
        }
        #endregion

        #region Method :: GetSizeDetails
        public SizesModel GetSizeDetails(int SizeID, int LanguageID)
        {
            using (MWCoreEntity db = new MWCoreEntity())
            {
                return (from Size in db.MW_Sizes
                        join Size_loc in db.MW_Sizes_Loc on Size.ID equals Size_loc.SizeID
                        where Size_loc.LanguageID == LanguageID && !Size.IsDeleted && Size.ID == SizeID
                        select new SizesModel()
                        {
                            SizeID = Size.ID,
                            SizeName = Size_loc.SizeName,
                            IsDeleted = Size.IsDeleted,
                            LanguageID = LanguageID,
                            Status = Size.Status,
                        }).FirstOrDefault();
            }
        }
        #endregion

        #region Method :: SaveSize
        public List<SizesModel> SaveSize(SizesModel oModel, List<SystemLanguagesModel> lstLanguages)
        {
            using (MWCoreEntity db = new MWCoreEntity())
            {
                MW_Sizes oSize = new MW_Sizes();
                MW_Sizes_Loc oSize_Loc = new MW_Sizes_Loc();
                if (oModel.SizeID > 0)
                {
                    oSize_Loc = db.MW_Sizes_Loc.Single(x => x.SizeID == oModel.SizeID && x.LanguageID == oModel.LanguageID);
                    oSize = db.MW_Sizes.FirstOrDefault(x => x.ID == oSize_Loc.SizeID);
                }
                oSize.IsDeleted = false;
                oSize.Status = oModel.Status;
                oSize_Loc.SizeName = oModel.SizeName;
                oSize_Loc.LanguageID = oModel.LanguageID;
                if (oModel.SizeID == 0)
                {
                    db.MW_Sizes.Add(oSize);
                    db.SaveChanges();
                    oSize_Loc.SizeID = oSize.ID;
                    db.MW_Sizes_Loc.Add(oSize_Loc);
                    int nCount = lstLanguages.Count - 1;
                    for (int nIndex = 0; nIndex <= nCount; nIndex++)
                    {
                        MW_Sizes_Loc oSizeLoc = new MW_Sizes_Loc();
                        oSizeLoc.SizeID = oSize.ID;
                        oSizeLoc.SizeName = oModel.SizeName;
                        oSizeLoc.LanguageID = lstLanguages[nIndex].LanguageID;
                        db.MW_Sizes_Loc.Add(oSizeLoc);
                    }
                }

                db.SaveChanges();
                return GetSizes(oModel.LanguageID);
            }
        }
        #endregion

        #region Method :: DeleteSize
        public List<SizesModel> DeleteSize(int SizeID, int LanguageID)
        {
            using (MWCoreEntity db = new MWCoreEntity())
            {
                MW_Sizes oSize = db.MW_Sizes.Single(x => x.ID == SizeID);
                if (oSize != null)
                {
                    oSize.IsDeleted = true;
                    db.SaveChanges();
                }
                return GetSizes(LanguageID);
            }
        }
        #endregion

        #region Method :: ChangeStatus
        public List<SizesModel> ChangeStatus(int SizeID, int LanguageID)
        {
            using (MWCoreEntity db = new MWCoreEntity())
            {
                MW_Sizes oSize = db.MW_Sizes.Single(x => x.ID == SizeID);
                if (oSize != null)
                {
                    oSize.Status = oSize.Status == true ? false : true;
                    db.SaveChanges();
                }
                return GetSizes(LanguageID);
            }
        }
        #endregion

        #region Method :: GetSizesAPI
        public List<SizesModel> GetSizesAPI(int LanguageID)
        {
            using (MWCoreEntity db = new MWCoreEntity())
            {
                return (from Size in db.MW_Sizes
                        join Size_loc in db.MW_Sizes_Loc on Size.ID equals Size_loc.SizeID
                        where Size_loc.LanguageID == LanguageID && !Size.IsDeleted && Size.Status == true
                        select new SizesModel()
                        {
                            SizeID = Size.ID,
                            SizeName = Size_loc.SizeName,
                            IsDeleted = Size.IsDeleted,
                            LanguageID = LanguageID,
                            Status = Size.Status,
                        }).ToList();
            }
        }
        #endregion

        #region Method :: GetSizesList
        public static List<SelectListItem> GetSizesList(int LanguageID)
        {
            using (MWCoreEntity db = new MWCoreEntity())
            {
                return (from Size in db.MW_Sizes
                        join Size_loc in db.MW_Sizes_Loc on Size.ID equals Size_loc.SizeID
                        where Size_loc.LanguageID == LanguageID && !Size.IsDeleted
                        select new SelectListItem()
                        {
                            Text = Size_loc.SizeName,
                            Value = Size.ID.ToString()
                        }).ToList();
            }
        }
        #endregion
    }
}