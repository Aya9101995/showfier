using MWCore.Areas.MWCore.Models.DBClasses;
using MWCore.Areas.MWCore.Models.DBClasses.Globalization;
using MWCore.Areas.MWCore.Models.DBClasses.Settings;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace MWCore.Areas.MWCore.Models.Modules.Areas
{
    public class AreasCOM
    {
        #region Method :: GetAreas
        public List<AreasModel> GetAreas(int LanguageID, int CityID, bool Status = false)
        {
            using (MWCoreEntity db = new MWCoreEntity())
            {
                return (from area in db.MW_Areas
                        join area_loc in db.MW_Areas_Loc on area.ID equals area_loc.AreaID
                        join city in db.MW_Cities on area.CityID equals city.ID
                        join city_loc in db.MW_Cities_Loc on city.ID equals city_loc.CityID
                        join country in db.MW_Countries on city.CountryID equals country.ID
                        join country_loc in db.MW_Countries_Loc on country.ID equals country_loc.CountryID
                        where city_loc.LanguageID == LanguageID && area_loc.LanguageID == LanguageID && country_loc.LanguageID == LanguageID && area.CityID == CityID
                        && !area.IsDeleted && !city.IsDeleted && !country.IsDeleted
                        && (Status == true ? area.Status == true : true)
                        select new AreasModel()
                        {
                            AreaID = area.ID,
                            AreaName = area_loc.AreaName,
                            CityID = area.CityID,
                            CityName = city_loc.CityName,
                            CountryID = country.ID,
                            CountryName = country_loc.CountryName,
                            IsDeleted = area.IsDeleted,
                            LanguageID = LanguageID,
                            Status = area.Status
                        }).ToList();
            }
        }
        #endregion

        #region Method :: GetAreaDetails
        public AreasModel GetAreaDetails(int AreaID, int LanguageID)
        {
            using (MWCoreEntity db = new MWCoreEntity())
            {
                return (from area in db.MW_Areas
                        join area_loc in db.MW_Areas_Loc on area.ID equals area_loc.AreaID
                        join city in db.MW_Cities on area.CityID equals city.ID
                        join city_loc in db.MW_Cities_Loc on city.ID equals city_loc.CityID
                        join country in db.MW_Countries on city.CountryID equals country.ID
                        join country_loc in db.MW_Countries_Loc on country.ID equals country_loc.CountryID
                        where city_loc.LanguageID == LanguageID && area_loc.LanguageID == LanguageID && country_loc.LanguageID == LanguageID && area.ID == AreaID
                        && !area.IsDeleted
                        select new AreasModel()
                        {
                            AreaID = area.ID,
                            AreaName = area_loc.AreaName,
                            CityID = area.CityID,
                            CityName = city_loc.CityName,
                            CountryID = country.ID,
                            CountryName = country_loc.CountryName,
                            IsDeleted = area.IsDeleted,
                            LanguageID = LanguageID,
                            Status = area.Status
                        }).FirstOrDefault();
            }
        }
        #endregion

        #region Method :: SaveArea
        public List<AreasModel> SaveArea(MWCoreModel oModel)
        {
            using (MWCoreEntity db = new MWCoreEntity())
            {
                MW_Areas oArea = new MW_Areas();
                MW_Areas_Loc oArea_Loc = new MW_Areas_Loc();
                if (oModel.oArea.AreaID > 0)
                {
                    oArea_Loc = db.MW_Areas_Loc.Single(x => x.AreaID == oModel.oArea.AreaID && x.LanguageID == oModel.oSystemLanguage.ID);
                    oArea = db.MW_Areas.FirstOrDefault(x => x.ID == oArea_Loc.AreaID);
                }
                oArea_Loc.AreaName = oModel.oArea.AreaName;
                oArea.Status = oModel.oArea.Status;
                oArea.CityID = oModel.oArea.CityID;
                oArea_Loc.LanguageID = oModel.oSystemLanguage.ID;
                if (oModel.oArea.AreaID > 0)
                {

                }
                else
                {
                    db.MW_Areas.Add(oArea);
                    db.MW_Areas_Loc.Add(oArea_Loc);
                    db.SaveChanges();
                    int nCount = oModel.lstSystemLanguages.Count - 1;
                    for (int nIndex = 0; nIndex <= nCount; nIndex++)
                    {
                        MW_Areas_Loc oAreaLoc = new MW_Areas_Loc();
                        oAreaLoc.AreaID = oArea.ID;
                        oAreaLoc.AreaName = oModel.oArea.AreaName;
                        oAreaLoc.LanguageID = oModel.lstSystemLanguages[nIndex].LanguageID;
                        db.MW_Areas_Loc.Add(oAreaLoc);
                    }
                }
                db.SaveChanges();
                return GetAreas(oModel.oSystemLanguage.ID, oModel.oArea.CityID);
            }
        }
        #endregion

        #region Method :: DeleteArea
        public List<AreasModel> DeleteArea(int AreaID, int LanguageID, int CityID)
        {
            using (MWCoreEntity db = new MWCoreEntity())
            {
                MW_Areas oArea = db.MW_Areas.Single(x => x.ID == AreaID);
                if (oArea != null)
                {
                    oArea.IsDeleted = true;
                    db.SaveChanges();
                }
                return GetAreas(LanguageID, CityID);
            }
        }
        #endregion

        #region Method :: ChangeStatus
        public List<AreasModel> ChangeStatus(int AreaID, int LanguageID, int CityID)
        {
            using (MWCoreEntity db = new MWCoreEntity())
            {
                MW_Areas oArea = db.MW_Areas.Single(x => x.ID == AreaID);
                if (oArea != null)
                {
                    oArea.Status = oArea.Status == true ? false : true;
                    db.SaveChanges();
                }
                return GetAreas(LanguageID, CityID);
            }
        }
        #endregion

        #region Method :: GetAreaName
        public static string GetAreaName(int AreaID)
        {
            string AreaName = string.Empty;
            using (MWCoreEntity db = new MWCoreEntity())
            {
                var oArea = db.MW_Areas_Loc.Where(x => x.AreaID == AreaID && x.LanguageID == 1).SingleOrDefault();
                if (oArea != null)
                {
                    AreaName = oArea.AreaName;
                }
            }
            return AreaName;
        }
        #endregion

        #region Method :: GetAreasList
        public static List<SelectListItem> GetAreasList(int LanguageID)
        {

            using (MWCoreEntity db = new MWCoreEntity())
            {
                return db.MW_Areas_Loc.Where(x => x.LanguageID == LanguageID).Select(x => new SelectListItem() { Text = x.AreaName, Value = x.AreaID.ToString() }).ToList();
            }
        }
        #endregion

        #region Method :: GetAreasByCityIDList
        public static List<SelectListItem> GetAreasByCityIDList(int CityID, int LanguageID)
        {

            using (MWCoreEntity db = new MWCoreEntity())
            {
                return db.MW_Areas_Loc.Include(x => x.MW_Areas).Where(x => x.MW_Areas.CityID == CityID && x.LanguageID == LanguageID).Select(x => new SelectListItem() { Text = x.AreaName, Value = x.AreaID.ToString() }).ToList();
            }
        }
        #endregion
        #region Method :: GetAreasList
        public static List<SelectListItem> GetAreasList(int LanguageID, int CityID)
        {

            using (MWCoreEntity db = new MWCoreEntity())
            {
                return db.MW_Areas_Loc.Where(x => x.LanguageID == LanguageID && x.MW_Areas.CityID == CityID && !x.MW_Areas.IsDeleted).Select(x => new SelectListItem() { Text = x.AreaName, Value = x.AreaID.ToString() }).ToList();
            }
        }
        #endregion

        public static int GetAreaIDByName(string AreaName, int LanguageID)
        {
            using (MWCoreEntity db = new MWCoreEntity())
            {
                return (from Area in db.MW_Areas
                        join Area_loc in db.MW_Areas_Loc on Area.ID equals Area_loc.AreaID
                        where Area_loc.LanguageID == LanguageID && Area_loc.AreaName.ToLower() == AreaName.ToLower() || Area_loc.AreaName.ToLower().Contains(AreaName.ToLower())
                        select Area.ID).FirstOrDefault();
            }
        }

        public static AreasModel CreateArea(string AreaName, int CityID, int LanguageID)
        {
            using (MWCoreEntity db = new MWCoreEntity())
            {
                MW_Areas oArea = new MW_Areas();
                MW_Areas_Loc oArea_Loc = new MW_Areas_Loc();
                oArea.CityID = CityID;
                oArea.Status = true;
                oArea.IsDeleted = false;
                db.MW_Areas.Add(oArea);
                db.SaveChanges();
                oArea_Loc.AreaName = AreaName;
                oArea_Loc.AreaID = oArea.ID;
                oArea_Loc.LanguageID = LanguageID;
                db.MW_Areas_Loc.Add(oArea_Loc);
                List<MW_SystemLanguages> lstSystemLanguages = db.MW_SystemLanguages.Where(x => x.ID != LanguageID).ToList();
                int nCount = lstSystemLanguages.Count - 1;
                for (int nIndex = 0; nIndex <= nCount; nIndex++)
                {
                    MW_Areas_Loc oAreaLoc = new MW_Areas_Loc();
                    oAreaLoc.AreaID = oArea.ID;
                    oAreaLoc.AreaName = AreaName;
                    oAreaLoc.LanguageID = lstSystemLanguages[nIndex].ID;
                    db.MW_Areas_Loc.Add(oAreaLoc);
                }
                db.SaveChanges();
                AreasCOM oAreasCOM = new AreasCOM();
                return oAreasCOM.GetAreaDetails(oArea.ID, LanguageID);
            }
        }
    }
}