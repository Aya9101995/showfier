using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MWCore.Areas.MWCore.Models.DBClasses.UserRejectionReasons
{
    public class MW_UserRejectionReasons
    {
        [Key]
        public int ID { get; set; }
        public bool IsDeleted { get; set; }
        public bool Status { get; set; }
        public virtual ICollection<MW_UserRejectionReasons_Loc> MW_UserRejectionReasons_Loc { get; set; }
    }
}