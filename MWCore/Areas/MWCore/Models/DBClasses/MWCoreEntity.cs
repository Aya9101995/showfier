/*****************************************************************************/
/* File Name     : MWCoreEntity.cs                                          */
/* Created By    : Abdulla Hawwash                                         */
/* Creation Date : 19/12/2017                                             */
/* Comment       : MWCoreEntity Database Context                         */
/************************************************************************/

using MWCore.Areas.MWCore.Models.DBClasses.AdditionalServices;
using MWCore.Areas.MWCore.Models.DBClasses.Banners;
using MWCore.Areas.MWCore.Models.DBClasses.Cars;
using MWCore.Areas.MWCore.Models.DBClasses.Categories;
using MWCore.Areas.MWCore.Models.DBClasses.Colors;
using MWCore.Areas.MWCore.Models.DBClasses.ContentPages;
using MWCore.Areas.MWCore.Models.DBClasses.Customers;
using MWCore.Areas.MWCore.Models.DBClasses.DriverRejectionReasons;
using MWCore.Areas.MWCore.Models.DBClasses.Drivers;
using MWCore.Areas.MWCore.Models.DBClasses.FAQs;
using MWCore.Areas.MWCore.Models.DBClasses.Gallery;
using MWCore.Areas.MWCore.Models.DBClasses.Globalization;
using MWCore.Areas.MWCore.Models.DBClasses.NewsLetters;
using MWCore.Areas.MWCore.Models.DBClasses.Pages;
using MWCore.Areas.MWCore.Models.DBClasses.PaymentMethods;
using MWCore.Areas.MWCore.Models.DBClasses.Settings;
using MWCore.Areas.MWCore.Models.DBClasses.Sizes;
using MWCore.Areas.MWCore.Models.DBClasses.SocialMedia;
using MWCore.Areas.MWCore.Models.DBClasses.StatusManager;
using MWCore.Areas.MWCore.Models.DBClasses.Taxes;
using MWCore.Areas.MWCore.Models.DBClasses.Tutorials;
using MWCore.Areas.MWCore.Models.DBClasses.UserRejectionReasons;
using MWCore.Areas.MWCore.Models.DBClasses.Users;

using System.Data.Entity;

namespace MWCore.Areas.MWCore.Models.DBClasses
{
    public class MWCoreEntity : DbContext
    {
        public MWCoreEntity() : base("MWCoreDB")
        {

        }

        public DbSet<MW_Banners> MW_Banners { get; set; }
        public DbSet<MW_SystemLanguages> MW_SystemLanguages { get; set; }
        public DbSet<MW_Users> MW_Users { get; set; }
        public DbSet<MW_ContentPages> MW_ContentPages { get; set; }
        public DbSet<MW_ContentPages_Loc> MW_ContentPages_Loc { get; set; }
        public DbSet<MW_EmailSettings> MW_EmailSettings { get; set; }
        public DbSet<MW_FAQ> MW_FAQ { get; set; }
        public DbSet<MW_FAQ_Loc> MW_FAQ_Loc { get; set; }
        public DbSet<MW_SocialMedia> MW_SocialMedia { get; set; }
        public DbSet<MW_SystemSettings> MW_SystemSettings { get; set; }
        public DbSet<MW_GroupPlociesPages> MW_GroupPlociesPages { get; set; }
        public DbSet<MW_GroupPolicies> MW_GroupPolicies { get; set; }
        public DbSet<MW_GroupPoliciesPermissions> MW_GroupPoliciesPermissions { get; set; }
        public DbSet<MW_Countries> MW_Countries { get; set; }
        public DbSet<MW_Countries_Loc> MW_Countries_Loc { get; set; }
        public DbSet<MW_CustomersVerificationCodes> MW_CustomersVerificationCodes { get; set; }
        public DbSet<MW_Cities> MW_Cities { get; set; }
        public DbSet<MW_Cities_Loc> MW_Cities_Loc { get; set; }
        public DbSet<MW_Areas> MW_Areas { get; set; }
        public DbSet<MW_Areas_Loc> MW_Areas_Loc { get; set; }
        public DbSet<MW_StatusManager> MW_StatusManager { get; set; }
        public DbSet<MW_StatusManager_Loc> MW_StatusManager_Loc { get; set; }

        public DbSet<MW_NewsLettersSubscriptions> MW_NewsLettersSubscriptions { get; set; }
        public DbSet<MW_GalleryAlbums> MW_GalleryAlbums { get; set; }
        public DbSet<MW_GalleryAlbums_Loc> MW_GalleryAlbums_Loc { get; set; }
        public DbSet<MW_Gallery> MW_Gallery { get; set; }
        public DbSet<MW_Pages> MW_Pages { get; set; }
        public DbSet<MW_Pages_Loc> MW_Pages_Loc { get; set; }
        public DbSet<MW_PagesKeys> MW_PagesKeys { get; set; }
        public DbSet<MW_PagesKeys_Loc> MW_PagesKeys_Loc { get; set; }
        public DbSet<MW_Customers> MW_Customers { get; set; }
        public DbSet<MW_CustomersAddresses> MW_CustomersAddresses { get; set; }

        public DbSet<MW_CustomersDevices> MW_CustomersDevices { get; set; }
        public DbSet<MW_CustomersWallets> MW_CustomersWallets { get; set; }
        public DbSet<MW_CustomersWalletsTransactions> MW_CustomersWalletsTransactions { get; set; }
        public DbSet<MW_CarsMakes> MW_CarsMakes { get; set; }
        public DbSet<MW_CarsMakes_Loc> MW_CarsMakes_Loc { get; set; }
        public DbSet<MW_CarsModels> MW_CarsModels { get; set; }
        public DbSet<MW_CarsModels_Loc> MW_CarsModels_Loc { get; set; }
        public DbSet<MW_CarsModelsYears> MW_CarsModelsYears { get; set; }
        public DbSet<MW_Colors> MW_Colors { get; set; }
        public DbSet<MW_Colors_Loc> MW_Colors_Loc { get; set; }
        public DbSet<MW_Categories> MW_Categories { get; set; }
        public DbSet<MW_Categories_Loc> MW_Categories_Loc { get; set; }
        public DbSet<MW_PaymentMethods> MW_PaymentMethods { get; set; }
        public DbSet<MW_PaymentMethods_Loc> MW_PaymentMethods_Loc { get; set; }



        public DbSet<MW_Tutorials> MW_Tutorials { get; set; }
        public DbSet<MW_Tutorials_Loc> MW_Tutorials_Loc { get; set; }
        public DbSet<MW_Sizes> MW_Sizes { get; set; }
        public DbSet<MW_Sizes_Loc> MW_Sizes_Loc { get; set; }



        public DbSet<MW_DriverRejectionReasons> MW_DriverRejectionReasons { get; set; }
        public DbSet<MW_DriverRejectionReasons_Loc> MW_DriverRejectionReasons_Loc { get; set; }
        public DbSet<MW_UserRejectionReasons> MW_UserRejectionReasons { get; set; }
        public DbSet<MW_UserRejectionReasons_Loc> MW_UserRejectionReasons_Loc { get; set; }

        public DbSet<MW_Taxes> MW_Taxes { get; set; }
        public DbSet<MW_Taxes_Loc> MW_Taxes_Loc { get; set; }

        public DbSet<MW_Cars> MW_Cars { get; set; }
        public DbSet<MW_Cars_Loc> MW_Cars_Loc { get; set; }

        public DbSet<MW_VehicleTypes> MW_VehicleTypes { get; set; }
        public DbSet<MW_VehicleTypes_Loc> MW_VehicleTypes_Loc { get; set; }

        public DbSet<MW_AdditionalServices> MW_AdditionalServices { get; set; }
        public DbSet<MW_AdditionalServices_Loc> MW_AdditionalServices_Loc { get; set; }
        public DbSet<MW_CarAdditionalServices> MW_CarAdditionalServices { get; set; }

        public DbSet<MW_Drivers> MW_Drivers { get; set; }

    }
}