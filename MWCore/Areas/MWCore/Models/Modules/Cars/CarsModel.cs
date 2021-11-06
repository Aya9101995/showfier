using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MWCore.Areas.MWCore.Models.Modules.Cars
{
    public class CarsModel
    {
        public int CarID { get; set; }
        public int CarMakeID { get; set; }
        public int CarModelID { get; set; }
        public int CarTypeID { get; set; }

        public string CarName { get; set; }
        public string CarMakeName { get; set; }
        public string CarModelName { get; set; }
        public string CarTypeName { get; set; }

        public string PlatNo { get; set; }

        public bool IsDeleted { get; set; }
        public bool Status { get; set; }
        public int LanguageID { get; set; }
        public List<CarAdditionalServicesModel> lstCarAdditionalServices { get; set; }
    }
    public class CarAdditionalServicesModel
    {
        public long CarServiceID { get; set; }
        public int ServiceID { get; set; }
        public int CarID { get; set; }
        public string ServiceName { get; set; }
        public bool IsChecked { get; set; }
    }
}