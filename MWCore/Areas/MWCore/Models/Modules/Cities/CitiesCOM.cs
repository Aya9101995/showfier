using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using MWCore.Areas.MWCore.Models.DBClasses;
using MWCore.Areas.MWCore.Models;
using MWCore.Areas.MWCore.Models.Modules.Cities;
using MWCore.Areas.MWCore.Models.DBClasses.Globalization;

namespace MWCore.Cities.MWCore.Models.Modules.Cities
{
    public class CitiesCOM
    {
        #region Method :: GetCities
        public List<CitiesModel> GetCities(int LanguageID, int CountryID, bool Status = false)
        {
            using (MWCoreEntity db = new MWCoreEntity())
            {
                return (from city in db.MW_Cities
                        join city_loc in db.MW_Cities_Loc on city.ID equals city_loc.CityID
                        join country in db.MW_Countries on city.CountryID equals country.ID
                        join country_loc in db.MW_Countries_Loc on country.ID equals country_loc.CountryID
                        where !city.IsDeleted && !country.IsDeleted && city_loc.LanguageID == LanguageID && country_loc.LanguageID == LanguageID && city.CountryID == CountryID
                        && (Status == true ? city.Status == true : true)
                        select new CitiesModel()
                        {
                            CityID = city.ID,
                            CityName = city_loc.CityName,
                            CountryID = country.ID,
                            CountryName = country_loc.CountryName,
                            IsDeleted = city.IsDeleted,
                            LanguageID = LanguageID,
                            Status = city.Status,
                            DeliveryCharge = city.DeliveryCharge,
                            MinAmount = city.MinAmount
                        }).ToList();
            }
        }
        #endregion

        #region Method :: GetCityDetails
        public CitiesModel GetCityDetails(int CityID, int LanguageID)
        {
            using (MWCoreEntity db = new MWCoreEntity())
            {
                return (from city in db.MW_Cities
                        join city_loc in db.MW_Cities_Loc on city.ID equals city_loc.CityID
                        join country in db.MW_Countries on city.CountryID equals country.ID
                        join country_loc in db.MW_Countries_Loc on country.ID equals country_loc.CountryID
                        where !city.IsDeleted && !country.IsDeleted && city_loc.LanguageID == LanguageID && country_loc.LanguageID == LanguageID && city.ID == CityID
                        select new CitiesModel()
                        {
                            CityID = city.ID,
                            CityName = city_loc.CityName,
                            CountryID = country.ID,
                            CountryName = country_loc.CountryName,
                            IsDeleted = city.IsDeleted,
                            LanguageID = LanguageID,
                            Status = city.Status,
                            DeliveryCharge = city.DeliveryCharge,
                            MinAmount = city.MinAmount
                        }).FirstOrDefault();
            }
        }
        #endregion

        #region Method :: SaveCity
        public List<CitiesModel> SaveCity(MWCoreModel oModel)
        {
            using (MWCoreEntity db = new MWCoreEntity())
            {
                MW_Cities oCity = new MW_Cities();
                MW_Cities_Loc oCity_Loc = new MW_Cities_Loc();
                if (oModel.oCity.CityID > 0)
                {
                    oCity_Loc = db.MW_Cities_Loc.Single(x => x.CityID == oModel.oCity.CityID && x.LanguageID == oModel.oSystemLanguage.ID);
                    oCity = db.MW_Cities.FirstOrDefault(x => x.ID == oCity_Loc.CityID);
                }
                oCity_Loc.CityName = oModel.oCity.CityName;
                oCity.Status = oModel.oCity.Status;
                oCity.MinAmount = oModel.oCity.MinAmount;

                oCity.CountryID = oModel.oCity.CountryID;
                oCity.DeliveryCharge = oModel.oCity.DeliveryCharge;
                oCity_Loc.LanguageID = oModel.oSystemLanguage.ID;
                if (oModel.oCity.CityID > 0)
                {

                }
                else
                {
                    db.MW_Cities.Add(oCity);
                    db.MW_Cities_Loc.Add(oCity_Loc);
                    db.SaveChanges();
                    int nCount = oModel.lstSystemLanguages.Count - 1;
                    for (int nIndex = 0; nIndex <= nCount; nIndex++)
                    {
                        MW_Cities_Loc oCityLoc = new MW_Cities_Loc();
                        oCityLoc.CityID = oCity.ID;
                        oCityLoc.CityName = oModel.oCity.CityName;
                        oCityLoc.LanguageID = oModel.lstSystemLanguages[nIndex].LanguageID;
                        db.MW_Cities_Loc.Add(oCityLoc);
                    }
                }
                db.SaveChanges();
                return GetCities(oModel.oSystemLanguage.ID, oCity.CountryID);
            }
        }
        #endregion

        #region Method :: DeleteCity
        public List<CitiesModel> DeleteCity(int CityID, int LanguageID, int CountryID)
        {
            using (MWCoreEntity db = new MWCoreEntity())
            {
                MW_Cities oCity = db.MW_Cities.Single(x => x.ID == CityID);
                if (oCity != null)
                {
                    oCity.IsDeleted = true;
                    db.SaveChanges();
                }
                return GetCities(LanguageID, CountryID);
            }
        }
        #endregion

        #region Method :: ChangeStatus
        public List<CitiesModel> ChangeStatus(int CityID, int LanguageID, int CountryID)
        {
            using (MWCoreEntity db = new MWCoreEntity())
            {
                MW_Cities oCity = db.MW_Cities.Single(x => x.ID == CityID);
                if (oCity != null)
                {
                    oCity.Status = oCity.Status == true ? false : true;
                    db.SaveChanges();
                }
                return GetCities(LanguageID, CountryID);
            }
        }
        #endregion

        #region Method :: GetCityName
        public static string GetCityName(int CityID)
        {
            string CityName = string.Empty;
            using (MWCoreEntity db = new MWCoreEntity())
            {
                var oCity = db.MW_Cities_Loc.Where(x => x.CityID == CityID && x.LanguageID == 1).SingleOrDefault();
                if (oCity != null)
                {
                    CityName = oCity.CityName;
                }
            }
            return CityName;
        }
        #endregion

        #region Method :: GetCitiesList
        public static List<SelectListItem> GetCitiesList(int LanguageID)
        {

            using (MWCoreEntity db = new MWCoreEntity())
            {
                return db.MW_Cities_Loc.Where(x => x.LanguageID == LanguageID).Select(x => new SelectListItem() { Text = x.CityName, Value = x.CityID.ToString() }).ToList();
            }
        }
        #endregion

        #region Method :: GetCitiesList
        public static List<SelectListItem> GetCitiesList(int LanguageID, int CountryID)
        {

            using (MWCoreEntity db = new MWCoreEntity())
            {
                return db.MW_Cities_Loc.Where(x => x.LanguageID == LanguageID && x.MW_Cities.CountryID == CountryID).Select(x => new SelectListItem() { Text = x.CityName, Value = x.CityID.ToString() }).ToList();
            }
        }
        #endregion

        public static int GetCityIDByName(string CityName, int LanguageID)
        {
            using (MWCoreEntity db = new MWCoreEntity())
            {
                return (from City in db.MW_Cities
                        join City_loc in db.MW_Cities_Loc on City.ID equals City_loc.CityID
                        where City_loc.LanguageID == LanguageID && City_loc.CityName.ToLower() == CityName.ToLower() || City_loc.CityName.ToLower().Contains(CityName.ToLower())
                        select City.ID).FirstOrDefault();
            }
        }
    }
}