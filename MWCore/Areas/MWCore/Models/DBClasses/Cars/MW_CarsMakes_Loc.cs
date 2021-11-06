using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MWCore.Areas.MWCore.Models.DBClasses.Cars
{
    public class MW_CarsMakes_Loc
    {
        [Key]
        public int ID { get; set; }
        public int CarMakeID { get; set; }
        public string CarMakeName { get; set; }
        public int LanguageID { get; set; }
        [ForeignKey("CarMakeID")]
        public MW_CarsMakes MW_CarsMakes { get; set; }
    }
}