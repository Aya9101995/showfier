using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MWCore.Areas.MWCore.Models.DBClasses.AdditionalServices
{
    public class MW_AdditionalServices
    {
        [Key]
        public int ID { get; set; }
        public bool IsDeleted { get; set; }
        public bool Status { get; set; }
        public decimal Price { get; set; }
        public int? Stock { get; set; }
        public string Image { get; set; }
        public virtual ICollection<MW_AdditionalServices_Loc> MW_AdditionalServices_Loc { get; set; }

    }
}