/*****************************************************************************/
/* File Name     : MW_GroupPoliciesPermissions.cs                           */
/* Created By    : Sara Jouma                                              */
/* Creation Date : 9/01/2018                                              */
/* Comment       : MW_GroupPoliciesPermissions Database Table            */
/************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace MWCore.Areas.MWCore.Models.DBClasses.Users
{
    public class MW_GroupPoliciesPermissions
    {
        [Key]
        public int ID { get; set; }
        public int GroupID { get; set; }
        public int PageID { get; set; }
    }
}