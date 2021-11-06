using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MWCore.Areas.MWCore.Models.Modules.Drivers
{
    public class DriversModel
    {
        public int DriverID { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.Validations), ErrorMessageResourceName = "RequirdField")]
        [Remote("PhoneNumberAlreadyExistsAsync", "DriversControl", AdditionalFields = "DriverID,PhoneNumber", HttpMethod = "POST", ErrorMessage = "Phone Number Already Exist.")]
        public string PhoneCode { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resources.Validations), ErrorMessageResourceName = "RequirdField")]
        [Remote("PhoneNumberAlreadyExistsAsync", "DriversControl", AdditionalFields = "DriverID,PhoneCode", HttpMethod = "POST", ErrorMessage = "Phone Number Already Exist.")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.Validations), ErrorMessageResourceName = "RequirdField")]
        public string FullName { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.Validations), ErrorMessageResourceName = "RequirdField")]
        public string Password { get; set; }

        public int Gender { get; set; }
        public Nullable<DateTime> DateOfBirth { get; set; }

        public string Picture { get; set; }

        public long CivilID { get; set; }
        public long EmployeeID { get; set; }

        public int DefaultCarID { get; set; }
        public int? TodaysCarID { get; set; }

        public bool IsDeleted { get; set; }
        public bool IsAvailable { get; set; }
        public bool CanAcceptRejectTrips { get; set; }
        public int LanguageID { get; set; }
    }
}