
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MWCore.Areas.MWCore.Models.DBClasses.Cars
{
    public class MW_Cars
    {
        [Key]
        public int ID { get; set; }

        //public int MakeID { get; set; }
        public int ModelID { get; set; }
        public string PlateNumber { get; set; }
     
        public int VehicleTypeID { get; set; }
        public bool Status { get; set; }
        public bool IsDeleted { get; set; }

        //[ForeignKey("MakeID")]
        //public MW_CarsMakes MW_CarsMakes { get; set; }

        [ForeignKey("ModelID")]
        public MW_CarsModels MW_CarsModels { get; set; }

        [ForeignKey("VehicleTypeID")]
        public MW_VehicleTypes MW_VehicleTypes { get; set; }

        public virtual ICollection<MW_Cars_Loc> MW_Cars_Loc { get; set; }

    }
}