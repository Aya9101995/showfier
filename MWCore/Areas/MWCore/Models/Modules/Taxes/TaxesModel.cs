using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MWCore.Areas.MWCore.Models.Modules.Taxes
{
    public class TaxesModel
    {
        public int taxID { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resources.Validations), ErrorMessageResourceName = "RequirdField")]
        public string TaxName { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resources.Validations), ErrorMessageResourceName = "RequirdField")]
        public decimal TaxValue { get; set; }
        public int LanguageID { get; set; }
        public bool IsDeleted { get; set; }
        public bool Status { get; set; }
    }
}