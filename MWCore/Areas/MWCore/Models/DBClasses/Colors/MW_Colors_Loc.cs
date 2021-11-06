using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MWCore.Areas.MWCore.Models.DBClasses.Colors
{
    public class MW_Colors_Loc
    {
        [Key]
        public int ID { get; set; }
        public int ColorID { get; set; }
        public string ColorName { get; set; }
        public int LanguageID { get; set; }

        [ForeignKey("ColorID")]
        public MW_Colors MW_Colors { get; set; }
    }
}