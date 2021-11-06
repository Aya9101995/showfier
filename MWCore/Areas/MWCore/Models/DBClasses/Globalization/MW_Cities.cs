using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MWCore.Areas.MWCore.Models.DBClasses.Globalization
{
    public class MW_Cities
    {
        [Key]
        public int ID { get; set; }
        public int CountryID { get; set; }
        public decimal DeliveryCharge { get; set; }
        public decimal MinAmount { get; set; }
        public bool Status { get; set; }
        public bool IsDeleted { get; set; }
        [ForeignKey("CountryID")]
        public MW_Countries MW_Countries { get; set; }
        public virtual ICollection<MW_Cities_Loc> MW_Cities_Loc { get; set; }
    }
}