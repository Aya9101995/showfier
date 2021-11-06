using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MWCore.Areas.MWCore.Models.DBClasses.Customers
{
    public class MW_CustomersVerificationCodes
    {
        [Key]
        public int ID { get; set; }
        public int CustomerID { get; set; }
        public string VerificationCode { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}