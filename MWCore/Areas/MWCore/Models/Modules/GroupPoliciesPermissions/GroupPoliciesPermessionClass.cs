/*****************************************************************************/
/* File Name     : GroupPoliciesPermessionClass.cs                          */
/* Created By    : Sara Jouma                                              */
/* Creation Date : 9/01/2018                                              */
/* Comment       : GroupPoliciesPermessionClass Custom Class             */
/************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MWCore.Areas.MWCore.Models.Modules.GroupPoliciesPermissions
{
    public class GroupPoliciesPermessionClass
    {
        public int GroupId { get; set; }
        public string GroupName { get; set; }
        public int PageId { get; set; }
        public string PageName { get; set; }
        public string PageTitle { get; set; }
        public int ParentID { get; set; }
        public bool isChecked { get; set; }
    }
}