using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MWCore.Areas.MWCore.Models.DBClasses.DriverRejectionReasons
{
    public class MW_DriverRejectionReasons
    {
        [Key]
        public int ID { get; set; }
        public bool IsDeleted { get; set; }
        public bool Status { get; set; }
        public virtual ICollection<MW_DriverRejectionReasons_Loc> MW_DriverRejectionReasons_Loc { get; set; }
    }
}