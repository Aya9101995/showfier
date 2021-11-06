using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MWCore.Areas.MWCore.Models.Modules.Pages
{
    public class PagesKeysModel
    {
        public int KeyID { get; set; }
        public int PageID { get; set; }
        public string KeyName { get; set; }
        public string KeyType { get; set; }
        public int KeySourceID { get; set; }
        [AllowHtml]
        public string KeyValue { get; set; }
        public int LanguageID { get; set; }
        
    }
}