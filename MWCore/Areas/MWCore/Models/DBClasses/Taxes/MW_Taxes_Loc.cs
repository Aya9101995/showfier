using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MWCore.Areas.MWCore.Models.DBClasses.Taxes
{
    public class MW_Taxes_Loc
    {
        [Key]
        public int ID { get; set; }
        public int TaxID { get; set; }
        public string TaxName { get; set; }
        public int LanguageID { get; set; }

        [ForeignKey("TaxID")]
        public MW_Taxes MW_Taxes { get; set; }

    }
}