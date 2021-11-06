using MWCore.Areas.MWCore.Models.Modules.Areas;
using MWCore.Areas.MWCore.Models.Modules.Cars;
using MWCore.Areas.MWCore.Models.Modules.CarsMakes;
using MWCore.Areas.MWCore.Models.Modules.CarsModels;
using MWCore.Areas.MWCore.Models.Modules.Cities;
using MWCore.Areas.MWCore.Models.Modules.Countries;
using MWCore.Areas.MWCore.Models.Modules.FAQ;
using MWCore.Areas.MWCore.Models.Modules.Tutorials;
using MWCore.Cities.MWCore.Models.Modules.Cities;
using MWCoreAPI.Models.APIBaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MWCoreAPI.Models.APIs.GlopalizationAPI
{
    public class GlobalizationAPI
    {
        public TutorialsAPIResponse GetTutorials(GlobalizationAPIRequest oGlobalizationAPIRequest)
        {
            TutorialsCOM oTutorialsCOM = new TutorialsCOM();
            TutorialsAPIResponse oTutorialsAPIResponse = new TutorialsAPIResponse();
            oTutorialsAPIResponse.lstTutorials = oTutorialsCOM.GetTutorials(oGlobalizationAPIRequest.LanguageID);
            oTutorialsAPIResponse.APIStatus = 1;
            oTutorialsAPIResponse.APIMessage = "Success";
            return oTutorialsAPIResponse;
        }
        public CountriesAPIResponse GetCountries(GlobalizationAPIRequest oGlobalizationAPIRequest)
        {
            CountriesCOM oCountriesCOM = new CountriesCOM();
            CountriesAPIResponse oCountriesAPIResponse = new CountriesAPIResponse();

            oCountriesAPIResponse.lstCountries = oCountriesCOM.GetCountries(oGlobalizationAPIRequest.LanguageID, true);
            oCountriesAPIResponse.APIStatus = 1;
            oCountriesAPIResponse.APIMessage = "Success";
            return oCountriesAPIResponse;
        }
        public CitiesAPIResponse GetCities(GlobalizationAPIRequest oGlobalizationAPIRequest)
        {
            CitiesCOM oCitiesCOM = new CitiesCOM();
            CitiesAPIResponse oCitiesAPIResponse = new CitiesAPIResponse();

            oCitiesAPIResponse.lstCities = oCitiesCOM.GetCities(oGlobalizationAPIRequest.LanguageID, oGlobalizationAPIRequest.CountryID, true);
            oCitiesAPIResponse.APIStatus = 1;
            oCitiesAPIResponse.APIMessage = "Success";
            return oCitiesAPIResponse;
        }
        public AreasAPIResponse GetAreas(GlobalizationAPIRequest oGlobalizationAPIRequest)
        {
            AreasCOM oAreasCOM = new AreasCOM();
            AreasAPIResponse oAreasAPIResponse = new AreasAPIResponse();

            oAreasAPIResponse.lstAreas = oAreasCOM.GetAreas(oGlobalizationAPIRequest.LanguageID, oGlobalizationAPIRequest.CityID, true);
            oAreasAPIResponse.APIStatus = 1;
            oAreasAPIResponse.APIMessage = "Success";
            return oAreasAPIResponse;
        }
        public CarMakesAPIResponse GetCarMakes(GlobalizationAPIRequest oGlobalizationAPIRequest)
        {
            CarsMakesCOM oCarsMakesCOM = new CarsMakesCOM();
            CarMakesAPIResponse oCarMakesAPIResponse = new CarMakesAPIResponse();

            oCarMakesAPIResponse.lstCarsMakes = oCarsMakesCOM.GetCarMakesAPI(oGlobalizationAPIRequest.LanguageID);
            oCarMakesAPIResponse.APIStatus = 1;
            oCarMakesAPIResponse.APIMessage = "Success";

            return oCarMakesAPIResponse;
        }
        public CarModelsAPIResponse GetCarModels(GlobalizationAPIRequest oGlobalizationAPIRequest)
        {
            CarsModelsCOM oCarsModelsCOM = new CarsModelsCOM();
            CarModelsAPIResponse oCarModelsAPIResponse = new CarModelsAPIResponse();

            oCarModelsAPIResponse.lstCarsModels = oCarsModelsCOM.GetCarModelsAPI(oGlobalizationAPIRequest.LanguageID, oGlobalizationAPIRequest.CarMakeID);
            oCarModelsAPIResponse.APIStatus = 1;
            oCarModelsAPIResponse.APIMessage = "Success";
            return oCarModelsAPIResponse;
        }
        public FAQAPIResponse GetFAQ(GlobalizationAPIRequest oGlobalizationAPIRequest)
        {
            FAQCOM oFAQCOM = new FAQCOM();
            FAQAPIResponse oFAQAPIResponse = new FAQAPIResponse();
            oFAQAPIResponse.lstFAQs = oFAQCOM.GetFAQ(oGlobalizationAPIRequest.LanguageID, true);
            oFAQAPIResponse.APIStatus = 1;
            oFAQAPIResponse.APIMessage = "Success";
            return oFAQAPIResponse;
        }
    }
    public class GlobalizationAPIRequest : APIModel
    {
        public int CountryID { get; set; }
        public int CityID { get; set; }
        public int CarMakeID { get; set; }
    }
    public class CountriesAPIResponse : APIModel
    {
        public List<CountriesModel> lstCountries { get; set; }
    }
    public class CitiesAPIResponse : APIModel
    {
        public List<CitiesModel> lstCities { get; set; }
    }
    public class AreasAPIResponse : APIModel
    {
        public List<AreasModel> lstAreas { get; set; }
    }
    public class CarMakesAPIResponse : APIModel
    {
        public List<CarsMakesModel> lstCarsMakes { get; set; }
    }
    public class CarModelsAPIResponse : APIModel
    {
        public List<CarsModelsModel> lstCarsModels { get; set; }
    }
    public class TutorialsAPIResponse : APIModel
    {
        public List<TutorialsModel> lstTutorials { get; set; }
    }
    public class FAQAPIResponse : APIModel
    {
        public List<FAQModel> lstFAQs { get; set; }
    }

}