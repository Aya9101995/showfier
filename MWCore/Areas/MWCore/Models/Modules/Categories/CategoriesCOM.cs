using MWCore.Areas.MWCore.Models.DBClasses;
using MWCore.Areas.MWCore.Models.DBClasses.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MWCore.Areas.MWCore.Models.Modules.Categories
{
    public class CategoriesCOM
    {
        #region Method :: GetCategories
        public List<CategoriesModel> GetCategories(int LanguageID)
        {
            using (MWCoreEntity db = new MWCoreEntity())
            {
                return (from category in db.MW_Categories
                        join category_loc in db.MW_Categories_Loc on category.ID equals category_loc.CategoryID
                        join color in db.MW_Colors on category.ColorID equals color.ID
                        join color_loc in db.MW_Colors_Loc on color.ID equals color_loc.ColorID
                        where category_loc.LanguageID == LanguageID && !category.IsDeleted
                        && color_loc.LanguageID == LanguageID

                        select new CategoriesModel()
                        {
                            Status = category.Status,
                            LanguageID = category_loc.LanguageID,
                            CategoryID = category.ID,
                            Title = category_loc.Title,
                            ColorID = category.ColorID,
                            ColorName = color_loc.ColorName

                        }).ToList();
            }
        }
        #endregion

        #region Method :: GetCategoryDetails
        public CategoriesModel GetCategoryDetails(int CategoryID, int LanguageID)
        {
            using (MWCoreEntity db = new MWCoreEntity())
            {
                return (from category in db.MW_Categories
                        join category_loc in db.MW_Categories_Loc on category.ID equals category_loc.CategoryID
                        join color in db.MW_Colors on category.ColorID equals color.ID
                        join color_loc in db.MW_Colors_Loc on color.ID equals color_loc.ColorID
                        where category.ID == CategoryID && category_loc.LanguageID == LanguageID && !category.IsDeleted
                          && color_loc.LanguageID == LanguageID
                        select new CategoriesModel()
                        {
                            Status = category.Status,
                            LanguageID = category_loc.LanguageID,
                            CategoryID = category.ID,
                            Title = category_loc.Title,
                            ColorID = category.ColorID,
                            ColorName = color_loc.ColorName
                        }).FirstOrDefault();
            }
        }
        #endregion

        #region Method :: SaveCategory
        public List<CategoriesModel> SaveCategory(MWCoreModel oModel)
        {
            using (MWCoreEntity db = new MWCoreEntity())
            {
                MW_Categories oCategory = new MW_Categories();
                MW_Categories_Loc oCategory_Loc = new MW_Categories_Loc();
                if (oModel.oCategories.CategoryID > 0)
                {
                    oCategory = db.MW_Categories.Single(x => x.ID == oModel.oCategories.CategoryID);
                    oCategory_Loc = db.MW_Categories_Loc.Single(x => x.CategoryID == oCategory.ID && x.LanguageID == oModel.oSystemLanguage.ID);
                }
                oCategory.Status = oModel.oCategories.Status;
                oCategory.ColorID = oModel.oCategories.ColorID;
                oCategory_Loc.Title = oModel.oCategories.Title;
                oCategory_Loc.LanguageID = oModel.oSystemLanguage.ID;
                if (oModel.oCategories.CategoryID == 0)
                {
                    oCategory_Loc.CategoryID = oCategory.ID;
                    db.MW_Categories.Add(oCategory);
                    db.MW_Categories_Loc.Add(oCategory_Loc);
                    db.SaveChanges();
                    int nCount = oModel.lstSystemLanguages.Count - 1;
                    for (int nIndex = 0; nIndex <= nCount; nIndex++)
                    {
                        MW_Categories_Loc oCategoryLoc = new MW_Categories_Loc();
                        oCategoryLoc.CategoryID = oCategory.ID;
                        oCategoryLoc.Title = oModel.oCategories.Title;
                        oCategoryLoc.LanguageID = oModel.lstSystemLanguages[nIndex].LanguageID;
                        db.MW_Categories_Loc.Add(oCategoryLoc);
                    }
                }

                db.SaveChanges();
                return GetCategories(oModel.oSystemLanguage.ID);
            }
        }
        #endregion

        #region Method :: DeleteCategory
        public List<CategoriesModel> DeleteCategory(int CategoryID, int LanguageID)
        {
            using (MWCoreEntity db = new MWCoreEntity())
            {
                MW_Categories oCategory = db.MW_Categories.Single(x => x.ID == CategoryID);
                if (oCategory != null)
                {
                    oCategory.IsDeleted = true;
                    db.SaveChanges();
                }
                return GetCategories(LanguageID);
            }
        }
        #endregion

        #region Method :: ChangeStatus
        public List<CategoriesModel> ChangeStatus(int CategoryID, int LanguageID)
        {
            using (MWCoreEntity db = new MWCoreEntity())
            {
                MW_Categories oCategory = db.MW_Categories.Single(x => x.ID == CategoryID);
                if (oCategory != null)
                {
                    oCategory.Status = oCategory.Status == true ? false : true;
                    db.SaveChanges();
                }
                return GetCategories(LanguageID);
            }
        }
        #endregion
        public static List<SelectListItem> GetCategoriesList(int LanguageID)
        {
            using (MWCoreEntity db = new MWCoreEntity())
            {
                return db.MW_Categories_Loc.Where(x => x.LanguageID == LanguageID && !x.MW_Categories.IsDeleted && x.MW_Categories.Status == true).Select(x => new SelectListItem() { Text = x.Title, Value = x.CategoryID.ToString() }).ToList();
            }
        }
    }
}