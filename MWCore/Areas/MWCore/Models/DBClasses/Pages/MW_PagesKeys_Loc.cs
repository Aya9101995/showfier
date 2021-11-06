/*****************************************************************************/
/* File Name     : MW_PagesKeys_Loc.cs                                      */
/* Created By    : Abdulla Hawwash                                         */
/* Creation Date : 19/12/2017                                             */
/* Comment       : MW_PagesKeys_Loc Database Table                       */
/************************************************************************/

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace MWCore.Areas.MWCore.Models.DBClasses.Pages
{
    public class MW_PagesKeys_Loc
    {
        [Key]
        public int ID { get; set; }
        public int KeyID { get; set; }
        [AllowHtml]
        public string KeyValue { get; set; }
        public int LanguageID { get; set; }

        [ForeignKey("KeyID")]
        public MW_PagesKeys MW_PagesKeys { get; set; }
    }
}