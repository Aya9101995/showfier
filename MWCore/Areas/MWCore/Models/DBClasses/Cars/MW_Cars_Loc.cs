using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MWCore.Areas.MWCore.Models.DBClasses.Cars
{
    public class MW_Cars_Loc
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int CarID { get; set; }
        public int languageID { get; set; }

        [ForeignKey("CarID")]
        public MW_Cars MW_Cars { get; set; }
    }
}