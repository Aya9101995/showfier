using MWCore.Areas.MWCore.Models.DBClasses.Cars;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MWCore.Areas.MWCore.Models.DBClasses.Drivers
{
    public class MW_Drivers
    {
        [Key]
        public int ID { get; set; }
        public string PhoneCode { get; set; }
        public string PhoneNumber { get; set; }
        public string FullName { get; set; }

        public int Gender { get; set; }
        public Nullable<DateTime> DateOfBirth { get; set; }
        public string Password { get; set; }
        public string Picture { get; set; }

        public long CivilID { get; set; }
        public long EmployeeID { get; set; }

        public int DefaultCarID { get; set; }
        public int? TodaysCarID { get; set; }

        public bool IsDeleted { get; set; }
        public bool IsAvailable { get; set; }
        public bool CanAcceptRejectTrips { get; set; }
        public int DefaultLanguageID { get; set; }

        [ForeignKey("DefaultCarID")]
        public MW_Cars MW_Cars { get; set; }

    }
}