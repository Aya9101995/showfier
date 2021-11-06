using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MWCore.Areas.MWCore.Models.Modules.Emails.EmailsTemplates
{
    public class OrderStatusModel
    {
        public string FullName { get; set; }
        public long OrderID { get; set; }
        public string Status { get; set; }
        public string LocationName { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}