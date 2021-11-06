using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MWCore.Areas.MWCore.Models.Modules.Sizes
{
    public class SizesModel
    {
        public int SizeID { get; set; }
        public string SizeName { get; set; }
        public int LanguageID { get; set; }
        public bool Status { get; set; }
        public bool IsDeleted { get; set; }
    }
}