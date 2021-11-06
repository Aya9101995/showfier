using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MWCore.Areas.MWCore.Models.Modules.PaymentMethods
{
    public class PaymentMethodsModel
    {
        public int PaymentMethodID { get; set; }
        public int PaymentMethodType { get; set; }
        public string Name { get; set; }
        public int LanguageID { get; set; }
        public string Image { get; set; }
        public bool Status { get; set; }
        public bool IsDeleted { get; set; }
    }
}