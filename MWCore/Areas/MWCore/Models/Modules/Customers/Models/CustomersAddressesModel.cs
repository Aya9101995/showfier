using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MWCore.Areas.MWCore.Models.Modules.Customers.Models
{
    public class CustomersAddressesModel
    {
        public long AddressID { get; set; }
        public long CustomerID { get; set; }
        public int CountryID { get; set; }
        public string CountryName { get; set; }
        public int CityID { get; set; }
        public string CityName { get; set; }
        public int AreaID { get; set; }
        public string AreaName { get; set; }
        public string AddressTitle { get; set; }
        public string BlockName { get; set; }
        public string StreetName { get; set; }
        public string BuildingName { get; set; }
        public string FloorName { get; set; }
        public string OfficeName { get; set; }
        public string AvenueName { get; set; }
        public string OtherNotes { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public bool IsDefault { get; set; }
        public int LanguageID { get; set; }
    }
}