using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MWCore.Areas.MWCore.Models.DBClasses.Pages
{
    public class MW_Pages_Loc
    {
        [Key]
        public int ID { get; set; }
        public int PageID { get; set; }
        public string PageTitle { get; set; }
        public string PageName { get; set; }
        public string PageTags { get; set; }
        public string PageURL { get; set; }
        public string PageDetails { get; set; }
        public int LanguageID { get; set; }
        [ForeignKey("PageID")]
        public MW_Pages MW_Pages { get; set; }
    }
}