using MWCore.Areas.MWCore.Models.DBClasses;
using MWCore.Areas.MWCore.Models.DBClasses.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MWCore.Areas.MWCore.Models.Modules.Countries
{
    public class CountriesCOM
    {

        #region Method :: GetCountries
        public List<CountriesModel> GetCountries(int LanguageID, bool Status = false)
        {
            using (MWCoreEntity db = new MWCoreEntity())
            {
                return (from country in db.MW_Countries
                        join country_loc in db.MW_Countries_Loc on country.ID equals country_loc.CountryID
                        where country_loc.LanguageID == LanguageID && !country.IsDeleted
                        && (Status == true ? country.Status == true : true)
                        select new CountriesModel()
                        {
                            CountryID = country.ID,
                            CountryName = country_loc.CountryName,
                            Flag = country.Flag,
                            IsDeleted = country.IsDeleted,
                            LanguageID = LanguageID,
                            Prefix = country_loc.Prefix,
                            Status = country.Status,
                            PhoneCode = country.PhoneCode
                        }).ToList();
            }
        }
        #endregion

        #region Method :: GetCountryDetails
        public CountriesModel GetCountryDetails(int CountryID, int LanguageID)
        {
            using (MWCoreEntity db = new MWCoreEntity())
            {
                return (from country in db.MW_Countries
                        join country_loc in db.MW_Countries_Loc on country.ID equals country_loc.CountryID
                        where country_loc.LanguageID == LanguageID && !country.IsDeleted && country.ID == CountryID
                        select new CountriesModel()
                        {
                            CountryID = country.ID,
                            CountryName = country_loc.CountryName,
                            Flag = country.Flag,
                            IsDeleted = country.IsDeleted,
                            LanguageID = LanguageID,
                            Prefix = country_loc.Prefix,
                            Status = country.Status,
                            PhoneCode = country.PhoneCode
                        }).FirstOrDefault();
            }
        }
        #endregion

        #region Method :: SaveCountry
        public List<CountriesModel> SaveCountry(MWCoreModel oModel)
        {
            using (MWCoreEntity db = new MWCoreEntity())
            {
                MW_Countries oCountry = new MW_Countries();
                MW_Countries_Loc oCountry_Loc = new MW_Countries_Loc();
                if (oModel.oCountry.CountryID > 0)
                {
                    oCountry_Loc = db.MW_Countries_Loc.Single(x => x.CountryID == oModel.oCountry.CountryID && x.LanguageID == oModel.oSystemLanguage.ID);
                    oCountry = db.MW_Countries.FirstOrDefault(x => x.ID == oCountry_Loc.CountryID);
                }
                oCountry_Loc.Prefix = oModel.oCountry.Prefix;
                oCountry.Status = oModel.oCountry.Status;
                oCountry.PhoneCode = oModel.oCountry.PhoneCode;
                oCountry_Loc.CountryName = oModel.oCountry.CountryName;
                oCountry_Loc.LanguageID = oModel.oSystemLanguage.ID;
                if (oModel.oCountry.CountryID > 0)
                {
                    if (oModel.oCountry.Flag != null && oModel.oCountry.Flag.Length > 0)
                    {
                        oCountry.Flag = oModel.oCountry.Flag;
                    }
                }
                else
                {
                    oCountry.Flag = oModel.oCountry.Flag;
                    db.MW_Countries.Add(oCountry);
                    db.MW_Countries_Loc.Add(oCountry_Loc);
                    db.SaveChanges();
                    int nCount = oModel.lstSystemLanguages.Count - 1;
                    for (int nIndex = 0; nIndex <= nCount; nIndex++)
                    {
                        MW_Countries_Loc oCountryLoc = new MW_Countries_Loc();
                        oCountryLoc.CountryID = oCountry.ID;
                        oCountryLoc.CountryName = oModel.oCountry.CountryName;
                        oCountryLoc.Prefix = oModel.oCountry.Prefix;
                        oCountryLoc.LanguageID = oModel.lstSystemLanguages[nIndex].LanguageID;
                        db.MW_Countries_Loc.Add(oCountryLoc);
                    }
                }
                db.SaveChanges();
                return GetCountries(oModel.oSystemLanguage.ID);
            }
        }
        #endregion

        #region Method :: DeleteCountry
        public List<CountriesModel> DeleteCountry(int CountryID, int LanguageID)
        {
            using (MWCoreEntity db = new MWCoreEntity())
            {
                MW_Countries oCountry = db.MW_Countries.Single(x => x.ID == CountryID);
                if (oCountry != null)
                {
                    oCountry.IsDeleted = true;
                    db.SaveChanges();
                }
                return GetCountries(LanguageID);
            }
        }
        #endregion

        #region Method :: ChangeStatus
        public List<CountriesModel> ChangeStatus(int CountryID, int LanguageID)
        {
            using (MWCoreEntity db = new MWCoreEntity())
            {
                MW_Countries oCountry = db.MW_Countries.Single(x => x.ID == CountryID);
                if (oCountry != null)
                {
                    oCountry.Status = oCountry.Status == true ? false : true;
                    db.SaveChanges();
                }
                return GetCountries(LanguageID);
            }
        }
        #endregion

        #region Method :: GetCountryName
        public static string GetCountryName(int CountryID)
        {
            string CountryName = string.Empty;
            using (MWCoreEntity db = new MWCoreEntity())
            {
                var oCountry = db.MW_Countries_Loc.Where(x => x.CountryID == CountryID && x.LanguageID == 1).SingleOrDefault();
                if (oCountry != null)
                {
                    CountryName = oCountry.CountryName;
                }
            }
            return CountryName;
        }
        #endregion

        #region Method :: GetCountriesList
        public static List<SelectListItem> GetCountriesList(int LanguageID)
        {

            using (MWCoreEntity db = new MWCoreEntity())
            {
                return db.MW_Countries_Loc.Where(x => x.LanguageID == LanguageID).Select(x => new SelectListItem() { Text = x.CountryName, Value = x.CountryID.ToString() }).ToList();
            }
        }
        #endregion

        public static List<SelectListItem> GetCountiresPhoneCodes()
        {
            using (MWCoreEntity db = new MWCoreEntity())
            {
                return db.MW_Countries.Select(x => new SelectListItem() { Text = x.PhoneCode, Value = x.PhoneCode }).ToList();
            }
        }

        public static int GetCountryIDByName(string CountryName, int LanguageID)
        {
            using (MWCoreEntity db = new MWCoreEntity())
            {
                return (from country in db.MW_Countries
                        join country_loc in db.MW_Countries_Loc on country.ID equals country_loc.CountryID
                        where country_loc.LanguageID == LanguageID && country_loc.CountryName.ToLower() == CountryName.ToLower() || country_loc.CountryName.ToLower().Contains(CountryName.ToLower())
                        select country.ID).FirstOrDefault();
            }
        }
        public static string GetCountryCodeByID(int CountryID)
        {
            using(MWCoreEntity db = new MWCoreEntity())
            {
                MW_Countries oCountry = db.MW_Countries.FirstOrDefault(x => x.ID == CountryID);
                if(oCountry!=null)
                {
                    return oCountry.PhoneCode;
                }
                else
                {
                    return "";
                }
            }
        }
    }
}