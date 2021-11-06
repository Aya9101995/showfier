/*****************************************************************************/
/* File Name     : MW_FAQ.cs                                                */
/* Created By    : Abdulla Hawwash                                         */
/* Creation Date : 19/12/2017                                             */
/* Comment       : MW_FAQ Database Table                                 */
/************************************************************************/

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MWCore.Areas.MWCore.Models.DBClasses.FAQs
{
    public class MW_FAQ
    {
        [Key]
        public int ID { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resources.Validations), ErrorMessageResourceName = "RequirdField")]
        [RegularExpression("^[1-9][0-9]*$", ErrorMessageResourceType = typeof(Resources.Validations), ErrorMessageResourceName = "PositiveOnly")]
        public Nullable<int> SortOrder { get; set; }
        public bool Status { get; set; }
        public bool IsDeleted { get; set; }
    }
}