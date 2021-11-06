using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MWCore.Areas.MWCore.Models.Modules.Customers.Models
{
    public class CustomersModel
    {
        public int CustomerID { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resources.Validations), ErrorMessageResourceName = "RequirdField")]
        [Remote("PhoneNumberAlreadyExistsAsync", "CustomersControl", AdditionalFields = "CustomerID,PhoneNumber", HttpMethod = "POST", ErrorMessage = "Phone Number Already Exist.")]
        public string PhoneCode { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resources.Validations), ErrorMessageResourceName = "RequirdField")]
        [Remote("PhoneNumberAlreadyExistsAsync", "CustomersControl", AdditionalFields = "CustomerID,PhoneCode", HttpMethod = "POST", ErrorMessage = "Phone Number Already Exist.")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.Validations), ErrorMessageResourceName = "RequirdField")]
        public string FullName { get; set; }
        [EmailAddress(ErrorMessageResourceType = typeof(Resources.Validations), ErrorMessageResourceName = "EmailFormat")]
        [Remote("EmailAlreadyExistsAsync", "CustomersControl", AdditionalFields = "CustomerID", HttpMethod = "POST", ErrorMessage = "Email Address Already Exist.")]
        public string Email { get; set; }
        public int Gender { get; set; }
        public bool IsBlocked { get; set; }

        public string DeviceID { get; set; }
        public string APIToken { get; set; }
        public string DeviceToken { get; set; }
        public int DevicePlatform { get; set; }

        public Nullable<int> CategoryID { get; set; }
        public string CategoryName { get; set; }
        public Nullable<DateTime> DateOfBirth { get; set; }
        public int DefaultLanguageID { get; set; }
        public bool SubscribedToNewsLetter { get; set; }
        public bool ApproveToTermsAndConditions { get; set; }
        public bool IsProfileCompleted { get; set; }
        public CustomersWalletsModel oWallet { get; set; }
        public List<CustomersAddressesModel> lstAddresses { get; set; }
        public CustomersDevicesModel oDevice { get; set; }
        public List<CustomersCarsModel> lstCars { get; set; }
        public CustomersVerificationCodesModel oVerificationCode { get; set; }
    }
}