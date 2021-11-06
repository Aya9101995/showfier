using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MWCore.Areas.MWCore.Models.DBClasses.Pages
{
    public class MW_Pages
    {
        [Key]
        public int ID { get; set; }
        public bool IsPage { get; set; }
        public bool IsPreDefinedPage { get; set; }
        public string PageBanner { get; set; }
        public int ParentID { get; set; }
        public bool ShowInMenu { get; set; }
        public bool ShowInFooter { get; set; }
        public bool Status { get; set; }
        public bool IsDeleted { get; set; }
        public virtual ICollection<MW_Pages_Loc> MW_Pages_Loc { get; set; }
        public virtual ICollection<MW_PagesKeys> MW_PagesKeys { get; set; }
    }
}