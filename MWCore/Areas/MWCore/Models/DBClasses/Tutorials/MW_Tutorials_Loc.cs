using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MWCore.Areas.MWCore.Models.DBClasses.Tutorials
{
    public class MW_Tutorials_Loc
    {
        [Key]
        public int ID { get; set; }
        public int TutorialID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public int LanguageID { get; set; }

        [ForeignKey("TutorialID")]
        public MW_Tutorials MW_Tutorials { get; set; }
    }
}