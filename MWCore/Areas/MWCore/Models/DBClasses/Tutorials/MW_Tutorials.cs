using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MWCore.Areas.MWCore.Models.DBClasses.Tutorials
{
    public class MW_Tutorials
    {
        [Key]
        public int ID { get; set; }
        public bool Status { get; set; }
        public bool IsDeleted { get; set; }
        public int SortOrder { get; set; }
        public virtual ICollection<MW_Tutorials_Loc> MW_Tutorials_Loc { get; set; }
    }
}