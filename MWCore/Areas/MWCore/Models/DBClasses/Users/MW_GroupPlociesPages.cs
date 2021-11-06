/*****************************************************************************/
/* File Name     : MW_GroupPlociesPages.cs                                  */
/* Created By    : Sara Jouma                                              */
/* Creation Date : 9/01/2018                                              */
/* Comment       : MW_GroupPlociesPages Database Table                   */
/************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MWCore.Areas.MWCore.Models.DBClasses.Users
{
    public class MW_GroupPlociesPages
    {
        [Key]
        public int ID { get; set; }
        public string PageName { get; set; }
        public string PageTitle { get; set; }
        public int ParentID { get; set; }
    }
}