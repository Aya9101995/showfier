using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MWCore.Areas.MWCore.Models.Modules.Colors
{
    public class ColorsModel
    {
        public int ColorID { get; set; }
        public string ColorCode { get; set; }
        public string ColorName { get; set; }
        public int LanguageID { get; set; }
        public bool Status { get; set; }
        public bool IsDeleted { get; set; }
    }
}