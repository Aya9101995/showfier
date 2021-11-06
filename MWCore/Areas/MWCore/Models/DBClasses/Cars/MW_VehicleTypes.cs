using MWCore.Areas.MWCore.Models.DBClasses.Taxes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MWCore.Areas.MWCore.Models.DBClasses.Cars
{
    public class MW_VehicleTypes
    {
        [Key]
        public int ID { get; set; }
        public string Logo { get; set; }
        public bool Status { get; set; }
        public bool IsDeleted { get; set; }

        public decimal BaseFare { get; set; }
        public decimal MinimumFare { get; set; }
        public decimal CostPerMinute { get; set; }
        public decimal CostPerKM { get; set; }
        public decimal CostPerDelayedMinute { get; set; }
        public int TaxID { get; set; }

        [ForeignKey("TaxID")]
        public MW_Taxes MW_Taxes { get; set; }
        public virtual ICollection<MW_VehicleTypes_Loc> MW_VehicleTypes_Loc { get; set; }
    }
}