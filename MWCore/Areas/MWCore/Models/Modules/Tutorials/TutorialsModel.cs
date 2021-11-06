using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MWCore.Areas.MWCore.Models.Modules.Tutorials
{
    public class TutorialsModel
    {
        public int TutorialID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public int LanguageID { get; set; }
        public bool Status { get; set; }
        public bool IsDeleted { get; set; }
        public int SortOrder { get; set; }
    }
}