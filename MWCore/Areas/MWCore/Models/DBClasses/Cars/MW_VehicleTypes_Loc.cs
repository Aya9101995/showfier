using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MWCore.Areas.MWCore.Models.DBClasses.Cars
{
    public class MW_VehicleTypes_Loc
    {
        [Key]
        public int ID { get; set; }
        public int VehicleTypeID { get; set; }
        public string VehicleName { get; set; }
        public int LanguageID { get; set; }

        [ForeignKey("VehicleTypeID")]
        public MW_VehicleTypes MW_VehicleTypes { get; set; }
    }
}