using MWCore.Areas.MWCore.Models.DBClasses;
using MWCore.Areas.MWCore.Models.Modules.SystemLanguages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MWCore.Models.Attributes
{
    public class InternationalizationAttribute : ActionFilterAttribute
    {
        private List<string> _supportedLocales;
        private readonly string _defaultLang;

        public InternationalizationAttribute()
        {
            _supportedLocales = new List<string>() { "en", "ar" };
            _defaultLang = "en";
        }

        private void SetLang(string lang)
        {
            lang = lang.Trim().ToLower();
            SystemLanguagesModel oSystemLanguage = null;
            oSystemLanguage = new SystemLanguagesModel()
            {
                LanguageID = 1,
                LanguageCode = "en-US",
                LanguageName = "English"
            };
            if (lang.StartsWith("ar"))
            {
                oSystemLanguage = new SystemLanguagesModel()
                {
                    LanguageID = 2,
                    LanguageCode = "ar-KW",
                    LanguageName = "عربى"
                };
            }
            if(HttpContext.Current.Session != null)
            {
                HttpContext.Current.Session["FrontEndSystemLangugage"] = oSystemLanguage;
            }
        }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string lang = (string)filterContext.RouteData.Values["lang"] ?? _defaultLang;
            if (string.IsNullOrEmpty(lang))
                lang = _defaultLang;
            if (_supportedLocales.Any(a => a.Trim().ToLower().StartsWith(lang.Trim().ToLower())))
                SetLang(lang);
            else
                SetLang("en");
        }
    }
}