/*****************************************************************************/
/* File Name     : FileTypeAttribute.cs                                     */
/* Created By    : Abdulla Hawwash                                         */
/* Creation Date : 19/12/2017                                             */
/* Comment       : File Type Attribute                                   */
/************************************************************************/

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MWCore.Areas.MWCore.Models.Common
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class FileTypeAttribute : ValidationAttribute, IClientValidatable
    {
        private const string _DefaultErrorMessage = "Only the following file types are allowed: {0}";
        private IEnumerable<string> _ValidTypes { get; set; }

        public FileTypeAttribute(string validTypes)
        {
            _ValidTypes = validTypes.Split(',').Select(s => s.Trim().ToLower());
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            IEnumerable<HttpPostedFileBase> files = value as IEnumerable<HttpPostedFileBase>;
            if (files != null)
            {
                foreach (HttpPostedFileBase file in files)
                {
                    if (file != null && !_ValidTypes.Any(e => file.FileName.EndsWith(e)))
                    {
                        return new ValidationResult(ErrorMessageString);
                    }
                }
            }
            return ValidationResult.Success;
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            var rule = new ModelClientValidationRule
            {
                ValidationType = "filetype"
            };
            rule.ValidationParameters.Add("validtypes", string.Join(",", _ValidTypes));
            yield return rule;
        }
    }
}