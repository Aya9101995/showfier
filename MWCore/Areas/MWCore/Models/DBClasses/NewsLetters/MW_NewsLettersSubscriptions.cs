using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MWCore.Areas.MWCore.Models.DBClasses.NewsLetters
{
    public class MW_NewsLettersSubscriptions
    {
        public long ID { get; set; }
        public string Email { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}