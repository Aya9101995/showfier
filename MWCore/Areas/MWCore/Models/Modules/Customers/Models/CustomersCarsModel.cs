using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MWCore.Areas.MWCore.Models.Modules.Customers.Models
{
    public class CustomersCarsModel
    {
        public int CarID { get; set; }
        public string CarName { get; set; }
        public int CustomerID { get; set; }
        public int CarMakeID { get; set; }
        public string CarMakeName { get; set; }
        public int CarModelID { get; set; }
        public string CarModelName { get; set; }
        public int Year { get; set; }
        public string PlateNumber { get; set; }
        public bool IsDefault { get; set; }
        public int LanguageID { get; set; }
    }
}