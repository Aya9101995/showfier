using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MWCore.Areas.MWCore.Models.Modules.AdditionalServices
{
    public class AdditionalServicesModel
    {
        public int AdditionalServiceID { get; set; }
        public string AdditionalServiceName { get; set; }
        public string AdditionalServiceDescription { get; set; }
        public string AdditionalServiceImage { get; set; }
        public decimal AdditionalServicePrice { get; set; }
        public int AdditionalServiceStock { get; set; }
        public bool IsDeleted { get; set; }
        public bool Status { get; set; }
        public int LanguageID { get; set; }

    }
}