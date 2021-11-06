using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MWCore.Areas.MWCore.Models.Common
{
    public class ContactUsModel
    {
        [EmailAddress(ErrorMessage = "Not valid email address")]
        [Required(ErrorMessage = "*")]
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "*")]
        public string Name { get; set; }
        [Required(ErrorMessage = "*")]
        public string Subject { get; set; }
        [Required(ErrorMessage = "*")]
        public string Message { get; set; }
    }
}