using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MWCore.Models
{
    public class CareersFormModel
    {
        public int CareerID { get; set; }
        public string CareerTitle { get; set; }
        [Required(ErrorMessage ="*")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "*")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "*")]
        public string Email { get; set; }
        [Required(ErrorMessage = "*")]
        public string PhoneNumber { get; set; }
        public string Resume { get; set; }
    }
}