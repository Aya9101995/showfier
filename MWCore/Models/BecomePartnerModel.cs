using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MWCore.Models
{
    public class BecomePartnerModel
    {
        [Required(ErrorMessage ="*")]
        public string BusinessType { get; set; }
        [Required(ErrorMessage = "*")]
        public string BusinessName { get; set; }
        [Required(ErrorMessage = "*")]
        public string Country { get; set; }
        [Required(ErrorMessage = "*")]
        public string ContactPerson { get; set; }
        [Required(ErrorMessage = "*")]
        public string Email { get; set; }
        [Required(ErrorMessage = "*")]
        public string PhoneNumber { get; set; }
        public string Message { get; set; }
        public bool Sent { get; set; }
    }
}