using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MWCore.Areas.MWCore.Models.DBClasses.Customers
{
    public class MW_CustomersAddresses
    {
        [Key]
        public int ID { get; set; }
        public int CustomerID { get; set; }
        public int CountryID { get; set; }
        public int CityID { get; set; }
        public int AreaID { get; set; }
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
        public bool IsDeleted { get; set; }

        [ForeignKey("CustomerID")]
        public MW_Customers MW_Customers { get; set; }
    }
}