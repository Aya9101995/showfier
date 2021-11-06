/*****************************************************************************/
/* File Name     : MW_Countries.cs                                          */
/* Created By    : Sara Jouma                                              */
/* Creation Date : 9/01/2018                                              */
/* Comment       : MW_Countries Database Table                           */
/************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MWCore.Areas.MWCore.Models.DBClasses.Globalization
{
    public class MW_Countries
    {
        [Key]
        public int ID { get; set; }
        public string Flag { get; set; }
        public string PhoneCode { get; set; }
        public bool Status { get; set; }
        public bool IsDeleted { get; set; }
        public virtual ICollection<MW_Countries_Loc> MW_Countries_Loc { get; set; }
        public virtual ICollection<MW_Cities> MW_Cities { get; set; }
    }
}