using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MWCore.Areas.MWCore.Models.Modules.NewsLettersSubscriptions
{
    public class NewsLettersSubscriptionsModel
    {
        public long SubscriptionID { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resources.Validations), ErrorMessageResourceName = "RequirdField")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessageResourceType = typeof(Resources.Validations), ErrorMessageResourceName = "EmailFormat")]
        public string Email { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}