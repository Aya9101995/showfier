using MWCore.Areas.MWCore.Models.DBClasses.Customers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MWCore.Areas.MWCore.Models.DBClasses.Cars
{
    public class MW_CarsModels
    {
        [Key]
        public int ID { get; set; }
        public int CarMakeID { get; set; }
        public bool Status { get; set; }
        public bool IsDeleted { get; set; }

        [ForeignKey("CarMakeID")]
        public MW_CarsMakes MW_CarsMakes { get; set; }
        public virtual ICollection<MW_CarsModels_Loc> MW_CarsModels_Loc { get; set; }
        public virtual ICollection<MW_CarsModelsYears> MW_CarsModelsYears { get; set; }
    
    }
}