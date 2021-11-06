using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MWCore.Areas.MWCore.Models.DBClasses.StatusManager
{
    public class MW_StatusManager
    {
        [Key]
        public int ID { get; set; }
        /// <summary>
        /// 1 => Leave Requests
        /// 2 => Tasks Management
        /// </summary>
        public int StatusForID { get; set; }
        public int StatusNumber { get; set; }
        public virtual ICollection<MW_StatusManager_Loc> MW_StatusManager_Loc { get; set; }
    }
}