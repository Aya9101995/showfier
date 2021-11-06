using MWCore.Areas.MWCore.Models.DBClasses.Categories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MWCore.Areas.MWCore.Models.DBClasses.Customers
{
    public class MW_Customers
    {
        [Key]
        public int ID { get; set; }
        public string PhoneCode { get; set; }
        public string PhoneNumber { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public int Gender { get; set; }
        public Nullable<DateTime> DateOfBirth { get; set; }
        public int DefaultLanguageID { get; set; }
        public bool SubscribedToNewsLetter { get; set; }
        public bool ApproveToTermsAndConditions { get; set; }
        public bool IsProfileCompleted { get; set; }
        public bool IsBlocked { get; set; }
        public int CategoryID { get; set; }


        public virtual ICollection<MW_CustomersAddresses> MW_CustomersAddresses { get; set; }
        public virtual ICollection<MW_CustomersDevices> MW_CustomersDevices { get; set; }
    }
}