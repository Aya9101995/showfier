using System;

namespace MWCore.Areas.MWCore.Models.Modules.Emails.EmailsTemplates
{
    public class WelcomeEmail
    {
        public string Username { get; set; }
        public string CodeValue { get; set; }
        public string PromoCode { get; set; }
        public DateTime EndDate { get; set; }
    }
}