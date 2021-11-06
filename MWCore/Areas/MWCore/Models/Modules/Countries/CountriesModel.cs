using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MWCore.Areas.MWCore.Models.Modules.Countries
{
    public class CountriesModel
    {
        public int CountryID { get; set; }
        public string Flag { get; set; }
        public int DefaultCurrencyID { get; set; }
        public bool Status { get; set; }
        public bool IsDeleted { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resources.Validations), ErrorMessageResourceName = "RequirdField")]
        public string CountryName { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resources.Validations), ErrorMessageResourceName = "RequirdField")]
        public string Prefix { get; set; }
        public int LanguageID { get; set; }
        public string PhoneCode { get; set; }
    }
}