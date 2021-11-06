using MWCore.Areas.MWCore.Models.DBClasses.Customers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MWCore.Areas.MWCore.Models.DBClasses.Cars
{
    public class MW_CarsMakes
    {
        [Key]
        public int ID { get; set; }
        public string Logo { get; set; }
        public bool Status { get; set; }
        public bool IsDeleted { get; set; }
        public virtual ICollection<MW_CarsMakes_Loc> MW_CarsMakes_Loc { get; set; }
        public virtual ICollection<MW_CarsModels> MW_CarsModels { get; set; }
    }
}