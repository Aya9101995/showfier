using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MWCore.Areas.MWCore.Models.Modules.CarsMakes
{
    public class CarsMakesModel
    {
        public int CarMakeID { get; set; }
        public bool Status { get; set; }
        public bool IsDeleted { get; set; }
        public string Logo { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.Validations), ErrorMessageResourceName = "RequirdField")]
        public string Name { get; set; }
        public int LanguageID { get; set; }

    }
}