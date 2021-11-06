using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MWCore.Areas.MWCore.Models.DBClasses.Customers
{
    public class MW_CustomersDevices
    {
        [Key]
        public int ID { get; set; }
        public int CustomerID { get; set; }
        public string ApiToken { get; set; }
        public string DeviceID { get; set; }
        public string DeviceToken { get; set; }
        /// <summary>
        /// 0 => Android
        /// 1 => IOS
        /// </summary>
        public int DevicePlatform { get; set; }
        [ForeignKey("CustomerID")]
        public MW_Customers MW_Customers { get; set; }
    }
}