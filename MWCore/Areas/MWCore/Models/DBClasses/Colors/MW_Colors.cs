using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MWCore.Areas.MWCore.Models.DBClasses.Colors
{
    public class MW_Colors
    {
        [Key]
        public int ID { get; set; }
        public string ColorCode { get; set; }
        public bool Status { get; set; }
        public bool IsDeleted { get; set; }
        public virtual ICollection<MW_Colors_Loc> MW_Colors_Loc { get; set; }
    }
}