using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MWCore.Areas.MWCore.Models.Modules.Emails.EmailsTemplates
{
    public class ResetPasswordEmailTemplate
    {
        public string FullName { get; set; }
        public string NewPassword { get; set; }
    }
}