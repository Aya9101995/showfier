/*****************************************************************************/
/* File Name     : MW_FAQ_Loc.cs                                            */
/* Created By    : Abdulla Hawwash                                         */
/* Creation Date : 19/12/2017                                             */
/* Comment       : MW_FAQ_Loc Database Table                             */
/************************************************************************/

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MWCore.Areas.MWCore.Models.DBClasses.FAQs
{
    public class MW_FAQ_Loc
    {
        [Key]
        public int ID { get; set; }
        public Nullable<int> FAQID { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resources.Validations), ErrorMessageResourceName = "RequirdField")]
        public string FAQQuetion { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resources.Validations), ErrorMessageResourceName = "RequirdField")]
        public string FAQAnswer { get; set; }
        public Nullable<int> LanguageID { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }

        [ForeignKey("FAQID")]
        public MW_FAQ MW_FAQ { get; set; }
    }
}