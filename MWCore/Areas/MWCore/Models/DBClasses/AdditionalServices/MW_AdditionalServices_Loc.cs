using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MWCore.Areas.MWCore.Models.DBClasses.AdditionalServices
{
    public class MW_AdditionalServices_Loc
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int ServiceID { get; set; }
        public int LanguageID { get; set; }

        [ForeignKey("ServiceID")]
        public MW_AdditionalServices MW_AdditionalServices { get; set; }
    }
}