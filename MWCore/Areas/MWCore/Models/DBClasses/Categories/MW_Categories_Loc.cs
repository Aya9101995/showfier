using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MWCore.Areas.MWCore.Models.DBClasses.Categories
{
    public class MW_Categories_Loc
    {
        [Key]
        public int ID { get; set; }
        public int CategoryID { get; set; }
        public string Title { get; set; }
        public int LanguageID { get; set; }

        [ForeignKey("CategoryID")]
        public MW_Categories MW_Categories { get; set; }
    }
}