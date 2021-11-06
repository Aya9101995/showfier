using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MWCore.Areas.MWCore.Models.DBClasses.Globalization
{
    public class MW_Cities_Loc
    {
        [Key]
        public int ID { get; set; }
        public int CityID { get; set; }
        public string CityName { get; set; }
        public int LanguageID { get; set; }
        [ForeignKey("CityID")]
        public MW_Cities MW_Cities { get; set; }
    }
}