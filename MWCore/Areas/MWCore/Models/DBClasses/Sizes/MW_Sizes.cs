using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MWCore.Areas.MWCore.Models.DBClasses.Sizes
{
    public class MW_Sizes
    {
        [Key]
        public int ID { get; set; }
        public bool Status { get; set; }
        public bool IsDeleted { get; set; }
        public virtual ICollection<MW_Sizes_Loc> MW_Sizes_Loc { get; set; }
    }
}