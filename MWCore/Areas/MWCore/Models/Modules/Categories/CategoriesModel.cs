using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MWCore.Areas.MWCore.Models.Modules.Categories
{
    public class CategoriesModel
    {
        public int CategoryID { get; set; }
        public string Title { get; set; }
        public int ColorID { get; set; }
        public string ColorName { get; set; }
        public int LanguageID { get; set; }
        public bool Status { get; set; }
        public bool IsDeleted { get; set; }
    }
}