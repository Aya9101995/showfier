using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MWCore.Areas.MWCore.Models.Modules.FAQ
{
    public class FAQModel
    {
        public Nullable<int> FAQID { get; set; }
        public string FAQQuetion { get; set; }
        public string FAQAnswer { get; set; }
        public Nullable<int> LanguageID { get; set; }
        public Nullable<int> SortOrder { get; set; }
        public bool Status { get; set; }
    }
}