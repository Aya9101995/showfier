using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MWCore.Areas.MWCore.Models.Common
{
    public class BooleanMustBeTrueAttribute : ValidationAttribute, IClientValidatable
    {
        public override bool IsValid(object propertyValue)
        {
            return propertyValue != null
            && propertyValue is bool
            && (bool)propertyValue;
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            yield return new ModelClientValidationRule
            {
                ErrorMessage = FormatErrorMessage(metadata.GetDisplayName()),
                ValidationType = "checkboxrequired"
            };
        }

    }
}