using MWCore.Areas.MWCore.Models.DBClasses.Colors;
using MWCore.Areas.MWCore.Models.DBClasses.Customers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MWCore.Areas.MWCore.Models.DBClasses.Categories
{
    public class MW_Categories
    {
        [Key]
        public int ID { get; set; }
        public bool Status { get; set; }
        public bool IsDeleted { get; set; }
        public int ColorID { get; set; }

        [ForeignKey("ColorID")]
        public MW_Colors MW_Colors { get; set; }
        public virtual ICollection<MW_Categories_Loc> MW_Categories_Loc { get; set; }
    }
}