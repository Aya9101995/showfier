using MWCore.Areas.MWCore.Models.DBClasses.AdditionalServices;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MWCore.Areas.MWCore.Models.DBClasses.Cars
{
    public class MW_CarAdditionalServices
    {
        [Key]
        public long ID { get; set; }
        public int ServiceID { get; set; }
        public int CarID { get; set; }

   

    }
}