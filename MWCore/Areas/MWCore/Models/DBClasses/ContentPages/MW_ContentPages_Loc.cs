/*****************************************************************************/
/* File Name     : MW_ContentPages_Loc.cs                                   */
/* Created By    : Abdulla Hawwash                                         */
/* Creation Date : 19/12/2017                                             */
/* Comment       : MW_ContentPages_Loc Database Table                    */
/************************************************************************/

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace MWCore.Areas.MWCore.Models.DBClasses.ContentPages
{
    public class MW_ContentPages_Loc
    {
        [Key]
        public int ID { get; set; }
        public int PageID { get; set; }
        public string PageTitle { get; set; }
        [AllowHtml]
        public string PageDetails { get; set; }
        public int LanguageID { get; set; }

        [ForeignKey("PageID")]
        public MW_ContentPages MW_ContentPages { get; set; }
    }
}