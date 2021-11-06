using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MWCore.Areas.MWCore.Models.DBClasses.Sizes
{
    public class MW_Sizes_Loc
    {
        [Key]
        public int ID { get; set; }
        public int SizeID { get; set; }
        public string SizeName { get; set; }
        public int LanguageID { get; set; }

        [ForeignKey("SizeID")]
        public MW_Sizes MW_Sizes { get; set; }
    }
}