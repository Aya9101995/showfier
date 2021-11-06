using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MWCore.Areas.MWCore.Models.DBClasses.Globalization
{
    public class MW_Countries_Loc
    {
        public int ID { get; set; }
        public int CountryID { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resources.Validations), ErrorMessageResourceName = "RequirdField")]
        public string CountryName { get; set; }
        public string Prefix { get; set; }
        public int LanguageID { get; set; }
        [ForeignKey("CountryID")]
        public MW_Countries MW_Countries { get; set; }
    }
}