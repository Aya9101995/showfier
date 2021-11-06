using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MWCore.Areas.MWCore.Models.Modules.Pages
{
    public class PagesModel
    {
        public int PageID { get; set; }
        public bool IsPage { get; set; }
        public bool IsPreDefinedPage { get; set; }
        public int ParentID { get; set; }
        public string PageBanner { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resources.Validations), ErrorMessageResourceName = "RequirdField")]
        public string PageTitle { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resources.Validations), ErrorMessageResourceName = "RequirdField")]
        public string PageName { get; set; }
        public string PageTags { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resources.Validations), ErrorMessageResourceName = "RequirdField")]
        [Remote("URLAlreadyExistsAsync", "PagesControl", AdditionalFields = "PageID,LanguageID", HttpMethod = "POST", ErrorMessage = "URL Already Exist.")]
        public string PageURL { get; set; }
        public string SecondURL { get; set; }
        [AllowHtml]
        public string PageDetails { get; set; }
        public int LanguageID { get; set; }
        public bool ShowInMenu { get; set; }
        public bool ShowInFooter { get; set; }
        public bool Status { get; set; }
    }
}