using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MWCore.Areas.MWCore.Models.DBClasses.Globalization
{
    public class MW_Areas
    {
        [Key]
        public int ID { get; set; }
        public int CityID { get; set; }
        public int AccumulationFactor { get; set; }
        public bool Status { get; set; }
        public bool IsDeleted { get; set; }
        [ForeignKey("CityID")]
        public MW_Cities MW_Cities { get; set; }
        public virtual ICollection<MW_Areas_Loc> MW_Areas_Loc { get; set; }
    }
}