/*****************************************************************************/
/* File Name     : MW_GroupPolicies.cs                                      */
/* Created By    : Sara Jouma                                              */
/* Creation Date : 9/01/2018                                              */
/* Comment       : MW_GroupPolicies Database Table                       */
/************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MWCore.Areas.MWCore.Models.DBClasses.Users
{
    public class MW_GroupPolicies
    {
        [Key]
        public int ID { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resources.Validations), ErrorMessageResourceName = "RequirdField")]
        public string GroupName { get; set; }
        public bool IsDeleted { get; set; }
    }
}