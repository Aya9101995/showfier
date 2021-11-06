using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MWCore.Areas.MWCore.Models.DBClasses.Globalization
{
    public class MW_Areas_Loc
    {
        [Key]
        public int ID { get; set; }
        public int AreaID { get; set; }
        public string AreaName { get; set; }
        public int LanguageID { get; set; }
        [ForeignKey("AreaID")]
        public MW_Areas MW_Areas { get; set; }
    }
}