using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MWCore.Areas.MWCore.Models.DBClasses.PaymentMethods
{
    public class MW_PaymentMethods_Loc
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public int LanguageID { get; set; }
        public int PaymentMethodID { get; set; }

        [ForeignKey("PaymentMethodID")]
        public MW_PaymentMethods MW_PaymentMethods { get; set; }

    }
}