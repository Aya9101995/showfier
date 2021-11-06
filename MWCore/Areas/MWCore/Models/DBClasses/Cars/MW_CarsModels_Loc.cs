using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MWCore.Areas.MWCore.Models.DBClasses.Cars
{
    public class MW_CarsModels_Loc
    {
        [Key]
        public int ID { get; set; }
        public int CarModelID { get; set; }
        public string CarModelName { get; set; }
        public int LanguageID { get; set; }
        [ForeignKey("CarModelID")]
        public MW_CarsModels MW_CarsModels { get; set; }
    }
}