using MWCore.Areas.MWCore.Models.DBClasses;
using MWCore.Areas.MWCore.Models.DBClasses.Colors;
using MWCore.Areas.MWCore.Models.DBClasses.Settings;
using MWCore.Areas.MWCore.Models.Modules.SystemLanguages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MWCore.Areas.MWCore.Models.Modules.Colors
{
    public class ColorsCOM
    {
        #region GetColors
        public List<ColorsModel> GetColors(int languageID)
        {
            using (MWCoreEntity db = new MWCoreEntity())
            {
                return (from color in db.MW_Colors
                        join color_loc in db.MW_Colors_Loc on color.ID equals color_loc.ColorID
                        where color_loc.LanguageID == languageID && !color.IsDeleted
                        select new ColorsModel()
                        {
                            ColorID = color.ID,
                            ColorCode = color.ColorCode,
                            ColorName = color_loc.ColorName,
                            Status = color.Status
                        }).ToList();
            }
        }
        #endregion

        #region DeleteColor
        public List<ColorsModel> DeleteColor(int colorID, int LanguageID)
        {
            using (MWCoreEntity db = new MWCoreEntity())
            {
                MW_Colors color = db.MW_Colors.Where(x => x.ID == colorID).FirstOrDefault();
                if (color != null)
                {
                    color.IsDeleted = true;
                    db.SaveChanges();
                }
                return GetColors(LanguageID);
            }
        }
        #endregion

        #region ChangeStatus
        public List<ColorsModel> ChangeStatus(int colorID, int LanguageID)
        {
            using (MWCoreEntity db = new MWCoreEntity())
            {
                MW_Colors color = db.MW_Colors.Where(x => x.ID == colorID).FirstOrDefault();
                if (color != null)
                {
                    color.Status = color.Status == true ? false : true;
                    db.SaveChanges();
                }
                return GetColors(LanguageID);
            }
        }
        #endregion

        #region Method :: GetColorDetails
        public ColorsModel GetColorDetails(int ColorID, int LanguageID)
        {
            using (MWCoreEntity db = new MWCoreEntity())
            {
                return (from Color in db.MW_Colors
                        join Color_loc in db.MW_Colors_Loc on Color.ID equals Color_loc.ColorID
                        where Color_loc.LanguageID == LanguageID && !Color.IsDeleted && Color.ID == ColorID
                        select new ColorsModel()
                        {
                            ColorID = Color.ID,
                            ColorName = Color_loc.ColorName,
                            IsDeleted = Color.IsDeleted,
                            LanguageID = LanguageID,
                            Status = Color.Status,
                            ColorCode = Color.ColorCode
                        }).FirstOrDefault();
            }
        }
        #endregion

        #region Method :: SaveColor
        public List<ColorsModel> SaveColor(ColorsModel oModel, List<SystemLanguagesModel> lstLanguages)
        {
            using (MWCoreEntity db = new MWCoreEntity())
            {
                MW_Colors oColor = new MW_Colors();
                MW_Colors_Loc oColor_Loc = new MW_Colors_Loc();
                if (oModel.ColorID > 0)
                {
                    oColor_Loc = db.MW_Colors_Loc.Single(x => x.ColorID == oModel.ColorID && x.LanguageID == oModel.LanguageID);
                    oColor = db.MW_Colors.FirstOrDefault(x => x.ID == oColor_Loc.ColorID);
                }
                oColor.ColorCode = oModel.ColorCode;
                oColor.IsDeleted = false;
                oColor.Status = oModel.Status;
                oColor_Loc.ColorName = oModel.ColorName;
                oColor_Loc.LanguageID = oModel.LanguageID;
                if (oModel.ColorID == 0)
                {
                    db.MW_Colors.Add(oColor);
                    db.SaveChanges();
                    oColor_Loc.ColorID = oColor.ID;
                    db.MW_Colors_Loc.Add(oColor_Loc);
                    int nCount = lstLanguages.Count - 1;
                    for (int nIndex = 0; nIndex <= nCount; nIndex++)
                    {
                        MW_Colors_Loc oColorLoc = new MW_Colors_Loc();
                        oColorLoc.ColorID = oColor.ID;
                        oColorLoc.ColorName = oModel.ColorName;
                        oColorLoc.LanguageID = lstLanguages[nIndex].LanguageID;
                        db.MW_Colors_Loc.Add(oColorLoc);
                    }
                }

                db.SaveChanges();
                return GetColors(oModel.LanguageID);
            }
        }
        #endregion

        #region Method :: GetColorsAPI
        public List<ColorsModel> GetColorsAPI(int LanguageID)
        {
            using (MWCoreEntity db = new MWCoreEntity())
            {
                return (from Color in db.MW_Colors
                        join Color_loc in db.MW_Colors_Loc on Color.ID equals Color_loc.ColorID
                        where Color_loc.LanguageID == LanguageID && !Color.IsDeleted && Color.Status == true
                        select new ColorsModel()
                        {
                            ColorID = Color.ID,
                            ColorName = Color_loc.ColorName,
                            IsDeleted = Color.IsDeleted,
                            LanguageID = LanguageID,
                            Status = Color.Status,
                            ColorCode = Color.ColorCode
                        }).ToList();
            }
        }
        #endregion

        #region Method :: GetColorsList
        public static List<SelectListItem> GetColorsList(int LanguageID)
        {
            using (MWCoreEntity db = new MWCoreEntity())
            {
                return (from Color in db.MW_Colors
                        join Color_loc in db.MW_Colors_Loc on Color.ID equals Color_loc.ColorID
                        where Color_loc.LanguageID == LanguageID && !Color.IsDeleted
                        select new SelectListItem()
                        {
                            Text = Color_loc.ColorName,
                            Value = Color.ID.ToString()
                        }).ToList();
            }
        }
        #endregion
    }
}