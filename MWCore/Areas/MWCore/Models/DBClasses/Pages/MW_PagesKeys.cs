/*****************************************************************************/
/* File Name     : MW_PagesKeys.cs                                          */
/* Created By    : Abdulla Hawwash                                         */
/* Creation Date : 19/12/2017                                             */
/* Comment       : MW_PagesKeys Database Table                           */
/************************************************************************/

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MWCore.Areas.MWCore.Models.DBClasses.Pages
{
    public class MW_PagesKeys
    {
        [Key]
        public int ID { get; set; }
        public int PageID { get; set; }
        public string KeyName { get; set; }
        public string KeyType { get; set; }
        public int KeySourceID { get; set; }
        public bool IsDeleted { get; set; }

        [ForeignKey("PageID")]
        public MW_Pages MW_Pages { get; set; }
    }
}