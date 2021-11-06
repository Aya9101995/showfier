using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MWCore.Areas.MWCore.Models.Modules.Cities
{
    public class CitiesModel
    {
        public int CityID { get; set; }
        public int CountryID { get; set; }
        public decimal DeliveryCharge { get; set; }
        public decimal MinAmount { get; set; }
        public string CountryName { get; set; }
        public bool Status { get; set; }
        public bool IsDeleted { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resources.Validations), ErrorMessageResourceName = "RequirdField")]
        public string CityName { get; set; }
        public int LanguageID { get; set; }
    }
}