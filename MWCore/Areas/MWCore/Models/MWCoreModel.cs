/*****************************************************************************/
/* File Name     : MWCoreModel.cs                                           */
/* Created By    : Abdulla Hawwash                                         */
/* Creation Date : 19/12/2017                                             */
/* Comment       : MWCore Main View Model                                */
/************************************************************************/

using MWCore.Areas.MWCore.Models.Common;
using MWCore.Areas.MWCore.Models.DBClasses;
using MWCore.Areas.MWCore.Models.DBClasses.ContentPages;
using MWCore.Areas.MWCore.Models.DBClasses.Settings;
using MWCore.Areas.MWCore.Models.DBClasses.SocialMedia;
using MWCore.Areas.MWCore.Models.DBClasses.Users;
using MWCore.Areas.MWCore.Models.Modules.Account;
using MWCore.Areas.MWCore.Models.Modules.AdditionalServices;
using MWCore.Areas.MWCore.Models.Modules.Areas;
using MWCore.Areas.MWCore.Models.Modules.Banners;
using MWCore.Areas.MWCore.Models.Modules.Cars;
using MWCore.Areas.MWCore.Models.Modules.CarsMakes;
using MWCore.Areas.MWCore.Models.Modules.CarsModels;
using MWCore.Areas.MWCore.Models.Modules.Categories;
using MWCore.Areas.MWCore.Models.Modules.Cities;
using MWCore.Areas.MWCore.Models.Modules.Colors;
using MWCore.Areas.MWCore.Models.Modules.Countries;
using MWCore.Areas.MWCore.Models.Modules.Customers.Models;
using MWCore.Areas.MWCore.Models.Modules.Dashboard;
using MWCore.Areas.MWCore.Models.Modules.DriverRejectionReasons;
using MWCore.Areas.MWCore.Models.Modules.Drivers;
using MWCore.Areas.MWCore.Models.Modules.FAQ;
using MWCore.Areas.MWCore.Models.Modules.GalleryAlbums;
using MWCore.Areas.MWCore.Models.Modules.GroupPoliciesPermissions;
using MWCore.Areas.MWCore.Models.Modules.NewsLettersSubscriptions;
using MWCore.Areas.MWCore.Models.Modules.Pages;
using MWCore.Areas.MWCore.Models.Modules.PaymentMethods;
using MWCore.Areas.MWCore.Models.Modules.Sizes;
using MWCore.Areas.MWCore.Models.Modules.SystemLanguages;
using MWCore.Areas.MWCore.Models.Modules.SystemSettings;
using MWCore.Areas.MWCore.Models.Modules.Taxes;
using MWCore.Areas.MWCore.Models.Modules.Tutorials;
using MWCore.Areas.MWCore.Models.Modules.UserRejectionReasons;
using MWCore.Areas.MWCore.Models.Modules.Vehicles;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MWCore.Areas.MWCore.Models
{
    public class MWCoreModel
    {
        public MW_Users oUserInfo { get; set; }
        public ChangePasswordClass oChangePassword { get; set; }
        public MW_SystemLanguages oSystemLanguage { get; set; }
        //public List<MW_SystemLanguages> lstSystemLanguages { get; set; }
        public List<SystemLanguagesModel> lstSystemLanguages { get; set; }
        public List<BannersModel> lstBanners { get; set; }
        public BannersModel oBanner { get; set; }
        public FileUploader oFileUploader { get; set; }
        public List<SelectListItem> lstStatus { get; set; }

        public MW_ContentPages oContentPage { get; set; }
        public MW_ContentPages_Loc oContentPage_Loc { get; set; }
        public List<MW_ContentPages_Loc> lstContentPages { get; set; }
        public MW_EmailSettings oEmailSettings { get; set; }
        public FAQModel oFAQ { get; set; }
        public List<FAQModel> lstFAQ { get; set; }
        public List<PagesKeysModel> lstPagesKeys { get; set; }
        public PagesKeysModel oPageKey { get; set; }
        public List<SelectListItem> lstKeysTypes { get; set; }
        public MW_SocialMedia oSocialMedia { get; set; }
        public List<MW_SocialMedia> lstSocialMedia { get; set; }
        public SystemSettingsModel oSystemSettings { get; set; }
        public MW_GroupPolicies oGroupPolicies { get; set; }
        public List<MW_GroupPolicies> lstGroupPolicies { get; set; }
        public List<SelectListItem> lstGroupPoliciesList { get; set; }
        public List<GroupPoliciesPermessionClass> lstGroupPoliciesPermessionClass { get; set; }
        public List<GroupPoliciesPermessionClass> lstGroupPoliciesPermessionForCurrentUser { get; set; }
        public List<string> SelectedPages { get; set; }
        public CountriesModel oCountry { get; set; }
        public List<CountriesModel> lstCountries { get; set; }
        public List<SelectListItem> lstCountriesPhoneCodesList { get; set; }
        public List<SelectListItem> lstGenderList { get; set; }
        public CitiesModel oCity { get; set; }
        public List<CitiesModel> lstCities { get; set; }
        public List<SelectListItem> lstCitiesList { get; set; }
        public AreasModel oArea { get; set; }
        public List<AreasModel> lstAreas { get; set; }
        public List<SelectListItem> lstAreasList { get; set; }
        public List<SelectListItem> lstCurrenciesList { get; set; }
        public MW_Users oUser { get; set; }
        public List<MW_Users> lstUsers { get; set; }
        public List<int> lstSortOrder { get; set; }

        public string RedirectToUrl { get; set; }
        public List<SelectListItem> lstCommissionTypes { get; set; }

        public DashboardModel oDashboardModel { get; set; }
        public List<GalleryAlbumsModel> lstGalleryAlbums { get; set; }
        public GalleryAlbumsModel oGalleryAlbum { get; set; }
        public List<GalleryModel> lstGalleries { get; set; }
        public GalleryModel oGallery { get; set; }
        public NewsLettersModel oNewsLetter { get; set; }
        public List<PagesModel> lstPages { get; set; }
        public PagesModel oPage { get; set; }
        public CustomersModel oCustomer { get; set; }
        public List<CustomersModel> lstCustomers { get; set; }

        public ColorsModel oColor { get; set; }
        public List<ColorsModel> lstColors { get; set; }

        public List<SelectListItem> lstColorsItemsList { get; set; }
        public CategoriesModel oCategories { get; set; }
        public List<CategoriesModel> lstCategories { get; set; }

        public List<SelectListItem> lstCategoriesItemsList { get; set; }

        public PaymentMethodsModel oPaymentMethods { get; set; }
        public List<PaymentMethodsModel> lstPaymentMethods { get; set; }

        public List<SelectListItem> lstPaymentMethodsItemsList { get; set; }
        public List<SelectListItem> lstPaymentsMethodsTypes { get; set; }

        public CarsMakesModel oCarMakes { get; set; }
        public List<CarsMakesModel> lstCarMakes { get; set; }

        public List<SelectListItem> lstCarMakesItemsList { get; set; }
        public CarsModelsModel oCarModels { get; set; }
        public List<CarsModelsModel> lstCarModels { get; set; }

        public List<SelectListItem> lstCarModelsItemsList { get; set; }


        public SizesModel oSizes { get; set; }
        public List<SizesModel> lstSizes { get; set; }
        public List<SelectListItem> lstSizesItemsList { get; set; }

        public TutorialsModel oTutorial { get; set; }
        public List<TutorialsModel> lstTutorials { get; set; }




        public TaxesModel oTaxes { get; set; }
        public List<TaxesModel> lstTaxes { get; set; }
        public List<SelectListItem> lstTaxesItemsList { get; set; }

        public DriverRejectionReasonsModel oDriverRejectionReasons { get; set; }
        public List<DriverRejectionReasonsModel> lstDriverRejectionReasons { get; set; }
        public List<SelectListItem> lstDriverRejectionReasonsItemsList { get; set; }

        public UserRejectionReasonsModel oUserRejectionReasons { get; set; }
        public List<UserRejectionReasonsModel> lstUserRejectionReasons { get; set; }
        public List<SelectListItem> UserRejectionReasonsModelItemsList { get; set; }


        public VehiclesModel oVehicleType { get; set; }
        public List<VehiclesModel> lstVehicleTypes { get; set; }
        public List<SelectListItem> VehicleTypesItemsList { get; set; }

        public CarsModel oCar { get; set; }
        public List<CarsModel> lstCars { get; set; }
        public List<SelectListItem> CarsItemsList { get; set; }

        public AdditionalServicesModel oAdditionalService { get; set; }
        public List<AdditionalServicesModel> lstAdditionalService { get; set; }
        public List<SelectListItem> AdditionalServiceItemsList { get; set; }
        public List<CarAdditionalServicesModel> lstCarAdditionalServices { get; set; }

        public DriversModel oDriver { get; set; }
        public List<DriversModel> lstDrivers { get; set; }

        public MWCoreModel()
        {

            oUserInfo = new MW_Users();
            if (HttpContext.Current != null && HttpContext.Current.Session["UserInfo"] != null)
            {
                oUserInfo = (MW_Users)HttpContext.Current.Session["UserInfo"];
            }
            if (oUserInfo != null)
            {
                if (oUserInfo != null)
                {
                    GroupPoliciesPermissionsCOM oGroupPoliciesPermissionsCOM = new GroupPoliciesPermissionsCOM();
                    lstGroupPoliciesPermessionForCurrentUser = oGroupPoliciesPermissionsCOM.GetGroupPoliciesPermissions(oUserInfo.PolicyGroupID);
                }
                oFileUploader = new FileUploader();
                if (HttpContext.Current != null && HttpContext.Current.Session["SystemLangugage"] != null)
                {
                    oSystemLanguage = (MW_SystemLanguages)HttpContext.Current.Session["SystemLangugage"];
                }
                else
                {
                    oSystemLanguage = new MW_SystemLanguages();
                    oSystemLanguage.ID = 1;
                    oSystemLanguage.LanguageName = "English";
                    oSystemLanguage.LanguageCode = "en-US";
                }
                using (MWCoreEntity db = new MWCoreEntity())
                {
                    lstSystemLanguages = db.MW_SystemLanguages.Where(x => x.ID != oSystemLanguage.ID).Select(x => new SystemLanguagesModel()
                    {
                        LanguageCode = x.LanguageCode,
                        LanguageID = x.ID,
                        LanguageName = x.LanguageName
                    }).ToList();
                }
                oSystemSettings = SystemSettingsCOM.GetSystemSettingsDetails();

                lstStatus = new List<SelectListItem>();
                lstStatus.Add(new SelectListItem() { Text = Resources.Admin.Active, Value = "True" });
                lstStatus.Add(new SelectListItem() { Text = Resources.Admin.InActive, Value = "False" });
                lstKeysTypes = new List<SelectListItem>();
                lstKeysTypes.Add(new SelectListItem() { Text = Resources.Admin.Text, Value = "Text" });
                lstKeysTypes.Add(new SelectListItem() { Text = Resources.Admin.Image, Value = "Image" });
                lstKeysTypes.Add(new SelectListItem() { Text = Resources.Admin.Editor, Value = "Editor" });
            }
        }
    }
}