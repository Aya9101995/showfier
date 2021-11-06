using MWCore.Areas.MWCore.Models;
using MWCore.Areas.MWCore.Models.BaseController;
using MWCore.Areas.MWCore.Models.Modules.Areas;
using MWCore.Areas.MWCore.Models.Modules.Cities;
using MWCore.Areas.MWCore.Models.Modules.Countries;
using MWCore.Cities.MWCore.Models.Modules.Cities;
using System.Web.Mvc;

namespace MWCore.Areas.MWCore.Controllers
{
    public class GlobalizationControlController : MWCoreController
    {
        // GET: MWCore/GlobalizationControl
        #region Countries
        #region ActionResult :: Index
        public ActionResult Index()
        {
            MWCoreModel oModel = new MWCoreModel();
            CountriesCOM oCountry = new CountriesCOM();
            oModel.lstCountries = oCountry.GetCountries(oModel.oSystemLanguage.ID);
            return View(oModel);
        }
        #endregion

        #region ActionResult :: AddEditCountries
        public ActionResult AddEditCountries(int? CountryID)
        {
            MWCoreModel oModel = new MWCoreModel();
            if (CountryID != null && CountryID > 0)
            {
                CountriesCOM oCountry = new CountriesCOM();
                oModel.oCountry = oCountry.GetCountryDetails((int)CountryID, oModel.oSystemLanguage.ID);
            }
            else
            {

                oModel.oCountry = new CountriesModel();

            }
            return PartialView("_AddEditCountries", oModel);
        }
        #endregion

        #region ActionResult :: SaveCountry
        public ActionResult SaveCountry(MWCoreModel oModel)
        {
            CountriesCOM oCountry = new CountriesCOM();
            oModel.lstCountries = oCountry.SaveCountry(oModel);
            return PartialView("_Countries", oModel);
        }
        #endregion

        #region ActionResult :: DeleteCountry
        public ActionResult DeleteCountry(int CountryID)
        {
            MWCoreModel oModel = new MWCoreModel();
            CountriesCOM oCountry = new CountriesCOM();
            oModel.lstCountries = oCountry.DeleteCountry(CountryID, oModel.oSystemLanguage.ID);
            return PartialView("_Countries", oModel);
        }
        #endregion

        #region ActionResult :: ChangeStatus
        public ActionResult ChangeStatus(int CountryID)
        {
            MWCoreModel oModel = new MWCoreModel();
            CountriesCOM oCountry = new CountriesCOM();
            oModel.lstCountries = oCountry.ChangeStatus(CountryID, oModel.oSystemLanguage.ID);
            return PartialView("_Countries", oModel);
        }
        #endregion
        #endregion

        #region Cities
        #region ActionResult :: Cities
        public ActionResult Cities(int CountryID = -99)
        {
            if (CountryID != -99)
            {
                MWCoreModel oModel = new MWCoreModel();
                CitiesCOM oCity = new CitiesCOM();
                CountriesCOM oCountry = new CountriesCOM();
                oModel.lstCities = oCity.GetCities(oModel.oSystemLanguage.ID, CountryID);
                oModel.oCountry = new CountriesModel();
                oModel.oCountry = oCountry.GetCountryDetails(CountryID, oModel.oSystemLanguage.ID);
                oModel.oCity = new CitiesModel();
                oModel.oCity.CountryID = CountryID;
                return View(oModel);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        #endregion

        #region ActionResult :: AddEditCities
        public ActionResult AddEditCities(int? CityID, int CountryID)
        {
            MWCoreModel oModel = new MWCoreModel();
            if (CityID != null && CityID > 0)
            {
                CitiesCOM oCity = new CitiesCOM();
                oModel.oCity = oCity.GetCityDetails((int)CityID, oModel.oSystemLanguage.ID);
            }
            else
            {

                oModel.oCity = new CitiesModel();
                oModel.oCity.CountryID = CountryID;
            }
            return PartialView("_AddEditCities", oModel);
        }
        #endregion

        #region ActionResult :: SaveCity
        public ActionResult SaveCity(MWCoreModel oModel)
        {
            CitiesCOM oCity = new CitiesCOM();
            CountriesCOM oCountry = new CountriesCOM();
            oModel.lstCities = oCity.SaveCity(oModel);
            oModel.oCountry = new CountriesModel();
            oModel.oCountry = oCountry.GetCountryDetails(oModel.oCity.CountryID, oModel.oSystemLanguage.ID);
            oModel.oCity.CountryID = oModel.oCity.CountryID;
            return PartialView("_Cities", oModel);
        }
        #endregion

        #region ActionResult :: DeleteCity
        public ActionResult DeleteCity(int CityID, int CountryID)
        {
            MWCoreModel oModel = new MWCoreModel();
            CitiesCOM oCity = new CitiesCOM();
            oModel.lstCities = oCity.DeleteCity(CityID, oModel.oSystemLanguage.ID, CountryID);
            CountriesCOM oCountry = new CountriesCOM();
            oModel.oCountry = new CountriesModel();
            oModel.oCountry = oCountry.GetCountryDetails(CountryID, oModel.oSystemLanguage.ID);
            oModel.oCity = new CitiesModel();
            oModel.oCity.CountryID = CountryID;
            return PartialView("_Cities", oModel);
        }
        #endregion

        #region ActionResult :: ChangeStatus
        public ActionResult ChangeStatusForCity(int CityID, int CountryID)
        {
            MWCoreModel oModel = new MWCoreModel();
            CitiesCOM oCity = new CitiesCOM();
            oModel.lstCities = oCity.ChangeStatus(CityID, oModel.oSystemLanguage.ID, CountryID);
            CountriesCOM oCountry = new CountriesCOM();
            oModel.oCountry = new CountriesModel();
            oModel.oCountry = oCountry.GetCountryDetails(CountryID, oModel.oSystemLanguage.ID);
            oModel.oCity = new CitiesModel();
            oModel.oCity.CountryID = CountryID;
            return PartialView("_Cities", oModel);
        }
        #endregion

        #region ActionResult :: GetCitiesList
        public JsonResult GetCitiesList(int CountryID)
        {
            MWCoreModel oModel = new MWCoreModel();
            oModel.lstCitiesList = CitiesCOM.GetCitiesList(CountryID, oModel.oSystemLanguage.ID);
            return Json(oModel.lstCitiesList, JsonRequestBehavior.AllowGet);
        }
        #endregion
        #endregion

        #region Areas
        #region ActionResult :: Areas
        public ActionResult Areas(int CityID = -99)
        {
            if (CityID != -99)
            {
                MWCoreModel oModel = new MWCoreModel();
                AreasCOM oArea = new AreasCOM();
                CitiesCOM oCity = new CitiesCOM();
                oModel.lstAreas = oArea.GetAreas(oModel.oSystemLanguage.ID, CityID);
                oModel.oCity = new CitiesModel();
                oModel.oCity = oCity.GetCityDetails(CityID, oModel.oSystemLanguage.ID);
                oModel.oArea = new AreasModel();
                oModel.oArea.CityID = CityID;
                return View(oModel);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        #endregion

        #region ActionResult :: AddEditAreas
        public ActionResult AddEditAreas(int? AreaID, int CityID)
        {
            MWCoreModel oModel = new MWCoreModel();
            if (AreaID != null && AreaID > 0)
            {
                AreasCOM oArea = new AreasCOM();
                oModel.oArea = oArea.GetAreaDetails((int)AreaID, oModel.oSystemLanguage.ID);
            }
            else
            {

                oModel.oArea = new AreasModel();
                oModel.oArea.CityID = CityID;
            }
            return PartialView("_AddEditAreas", oModel);
        }
        #endregion

        #region ActionResult :: SaveArea
        public ActionResult SaveArea(MWCoreModel oModel)
        {
            AreasCOM oArea = new AreasCOM();
            CountriesCOM oCountry = new CountriesCOM();
            oModel.lstAreas = oArea.SaveArea(oModel);
            CitiesCOM oCity = new CitiesCOM();
            oModel.oCity = new CitiesModel();
            oModel.oCity = oCity.GetCityDetails(oModel.oArea.CityID, oModel.oSystemLanguage.ID);
            oModel.oArea.CityID = oModel.oArea.CityID;
            return PartialView("_Areas", oModel);
        }
        #endregion

        #region ActionResult :: DeleteArea
        public ActionResult DeleteArea(int AreaID, int CityID)
        {
            MWCoreModel oModel = new MWCoreModel();
            AreasCOM oArea = new AreasCOM();
            oModel.lstAreas = oArea.DeleteArea(AreaID, oModel.oSystemLanguage.ID, CityID);
            CitiesCOM oCity = new CitiesCOM();
            oModel.oCity = new CitiesModel();
            oModel.oCity = oCity.GetCityDetails(CityID, oModel.oSystemLanguage.ID);
            oModel.oArea = new AreasModel();
            oModel.oArea.CityID = CityID;
            return PartialView("_Areas", oModel);
        }
        #endregion

        #region ActionResult :: ChangeStatus
        public ActionResult ChangeStatusForArea(int AreaID, int CityID)
        {
            MWCoreModel oModel = new MWCoreModel();
            AreasCOM oArea = new AreasCOM();
            oModel.lstAreas = oArea.ChangeStatus(AreaID, oModel.oSystemLanguage.ID, CityID);
            CitiesCOM oCity = new CitiesCOM();
            oModel.oCity = new CitiesModel();
            oModel.oCity = oCity.GetCityDetails(CityID, oModel.oSystemLanguage.ID);
            oModel.oArea = new AreasModel();
            oModel.oArea.CityID = CityID;
            return PartialView("_Areas", oModel);
        }
        #endregion

        #region ActionResult :: GetAreasList
        public JsonResult GetAreasList(int CityID)
        {
            MWCoreModel oModel = new MWCoreModel();
            oModel.lstAreasList = AreasCOM.GetAreasList(CityID, oModel.oSystemLanguage.ID);
            return Json(oModel.lstAreasList, JsonRequestBehavior.AllowGet);
        }
        #endregion
        #endregion
    }
}