using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MWCore.Areas.MWCore.Models.DBClasses.UserRejectionReasons
{
    public class MW_UserRejectionReasons_Loc
    {
        [Key]
        public int ID { get; set; }
        public int RejectionReasonID { get; set; }
        public string RejectionName { get; set; }
        public int LanguageID { get; set; }

        [ForeignKey("RejectionReasonID")]
        public MW_UserRejectionReasons MW_UserRejectionReasons { get; set; }
    }
}