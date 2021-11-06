using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MWCore.Areas.MWCore.Models.DBClasses.PaymentMethods
{
    public class MW_PaymentMethods
    {
        [Key]
        public int ID { get; set; }
        public int PaymentMethodType { get; set; }
        public string Image { get; set; }
        public bool IsDeleted { get; set; }
        public bool Status { get; set; }
        public virtual ICollection<MW_PaymentMethods_Loc> MW_PaymentMethods_Loc { get; set; }
    }
}