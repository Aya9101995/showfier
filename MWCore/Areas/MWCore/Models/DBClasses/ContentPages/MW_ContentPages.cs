/*****************************************************************************/
/* File Name     : MW_ContentPages.cs                                       */
/* Created By    : Abdulla Hawwash                                         */
/* Creation Date : 19/12/2017                                             */
/* Comment       : MW_ContentPages Database Table                        */
/************************************************************************/

using System;
using System.ComponentModel.DataAnnotations;

namespace MWCore.Areas.MWCore.Models.DBClasses.ContentPages
{
    public class MW_ContentPages
    {
        [Key]
        public int ID { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}