using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MWCore.Areas.MWCore.Models.Modules.CarsModels
{
    public class CarsModelsModel
    {
        public int CarModelID { get; set; }
        public int CarMakeID { get; set; }
        public bool Status { get; set; }
        public bool IsDeleted { get; set; }
        public string MakeName { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resources.Validations), ErrorMessageResourceName = "RequirdField")]
        public string ModelName { get; set; }
        public int LanguageID { get; set; }
    }
}