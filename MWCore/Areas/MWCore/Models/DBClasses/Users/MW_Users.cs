/*****************************************************************************/
/* File Name     : MW_Users.cs                                              */
/* Created By    : Abdulla Hawwash                                         */
/* Creation Date : 19/12/2017                                             */
/* Comment       : MW_Users Database Table                               */
/************************************************************************/

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;


namespace MWCore.Areas.MWCore.Models.DBClasses.Users
{
    public class MW_Users
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.Validations), ErrorMessageResourceName = "RequirdField")]
        public string FullName { get; set; }



        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessageResourceType = typeof(Resources.Validations), ErrorMessageResourceName = "EmailFormat")]
        [Remote("EmailAlreadyExistsAsync", "Users", AdditionalFields = "ID", HttpMethod = "POST", ErrorMessage = "Email address already registered.")]
        public string Email { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.Validations), ErrorMessageResourceName = "RequirdField")]
        [RegularExpression("^[0-9]*$", ErrorMessageResourceType = typeof(Resources.Validations), ErrorMessageResourceName = "NumberOnly")]

        public string Mobile { get; set; }

        
        [Remote("UserAlreadyExistsAsync", "Users", AdditionalFields = "ID", HttpMethod = "POST", ErrorMessage = "User name already registered.")]
        public string Username { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.Validations), ErrorMessageResourceName = "RequirdField")]
        public string Password { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.Validations), ErrorMessageResourceName = "RequirdField")]
        public string UserImage { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.Validations), ErrorMessageResourceName = "RequirdField")]
        public int PolicyGroupID { get; set; }
        public bool Status { get; set; }
        public bool CanPublish { get; set; }
        public bool IsDeleted { get; set; }
        public int UsernameOrder { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }

        [ForeignKey("PolicyGroupID")]
        public MW_GroupPolicies MW_GroupPolicies { get; set; }
    }
}