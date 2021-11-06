/*****************************************************************************/
/* File Name     : MW_SocialMedia.cs                                        */
/* Created By    : Abdulla Hawwash                                         */
/* Creation Date : 19/12/2017                                             */
/* Comment       : MW_SocialMedia Database Table                         */
/************************************************************************/

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MWCore.Areas.MWCore.Models.DBClasses.SocialMedia
{
    public class MW_SocialMedia
    {
        [Key]
        public int ID { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resources.Validations), ErrorMessageResourceName = "RequirdField")]
        public string SocialMediaType { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resources.Validations), ErrorMessageResourceName = "RequirdField")]
        [UrlAttribute(ErrorMessageResourceType = typeof(Resources.Validations), ErrorMessageResourceName = "URLFormat")]
        public string SocialMediaLink { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resources.Validations), ErrorMessageResourceName = "RequirdField")]
        public string SocialMediaIcon { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resources.Validations), ErrorMessageResourceName = "RequirdField")]
        [RegularExpression("^[1-9][0-9]*$", ErrorMessageResourceType = typeof(Resources.Validations), ErrorMessageResourceName = "PositiveOnly")]
        public Nullable<int> SortOrder { get; set; }
        public Nullable<bool> Status { get; set; }
    }
}