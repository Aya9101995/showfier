using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MWCore.Areas.MWCore.Models.DBClasses.StatusManager
{
    public class MW_StatusManager_Loc
    {
        [Key]
        public int ID { get; set; }
        public int StatusManagerID { get; set; }
        public string StatusTitle { get; set; }
        public int LanguageID { get; set; }
        [ForeignKey("StatusManagerID")]
        public MW_StatusManager MW_StatusManager { get; set; }
    }
}