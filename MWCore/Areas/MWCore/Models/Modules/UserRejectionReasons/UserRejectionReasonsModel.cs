using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MWCore.Areas.MWCore.Models.Modules.UserRejectionReasons
{
    public class UserRejectionReasonsModel
    {
        public int RejectionID { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.Validations), ErrorMessageResourceName = "RequirdField")]
        public string RejectionName { get; set; }
        public int LanguageID { get; set; }
        public bool IsDeleted { get; set; }
        public bool Status { get; set; }
    }
}