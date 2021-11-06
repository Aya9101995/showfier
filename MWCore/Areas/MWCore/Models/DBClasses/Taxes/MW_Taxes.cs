using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MWCore.Areas.MWCore.Models.DBClasses.Taxes
{
    public class MW_Taxes
    {
        [Key]
        public int ID { get; set; }
        public bool IsDeleted { get; set; }
        public bool Status { get; set; }
        public decimal TaxValue { get; set; }
        public virtual ICollection<MW_Taxes_Loc> MW_Taxes_Loc { get; set; }
    }
}