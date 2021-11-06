using MWCore.Areas.MWCore.Models.Modules.Banners;
using MWCore.Areas.MWCore.Models.Modules.FAQ;
using MWCore.Areas.MWCore.Models.Modules.Pages;
using MWCore.Areas.MWCore.Models.Modules.SocialMedia;
using MWCore.Areas.MWCore.Models.Modules.SystemLanguages;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Web;

namespace MWCore.Models
{
    public class MWFrontEndModel
    {
        public string BannerClass { get; set; }
        public List<BannersModel> lstBanners { get; set; }
        public List<SystemLanguagesModel> lstSystemLanguages { get; set; }
        public SystemLanguagesModel oSystemLanguage { get; set; }
        public string WebsiteTitle { get; set; }
        public string PageTitle { get; set; }
        public PagesModel oPage { get; set; }
        public List<SocialMediaModel> lstSocialMedias { get; set; }
        public List<FAQModel> lstFAQs { get; set; }
        public int PageID { get; set; }
        public int PagesCount { get; set; }
        public string GetKeyValue(string KeyName)
        {
            return PagesCOM.GetPageKeyByName(KeyName, oSystemLanguage.LanguageID);
        }
        public MWFrontEndModel()
        {
            BannerClass = "inner-banner";
            if (HttpContext.Current != null && HttpContext.Current.Session["FrontEndSystemLangugage"] != null)
            {
                oSystemLanguage = (SystemLanguagesModel)HttpContext.Current.Session["FrontEndSystemLangugage"];
            }
            else
            {
                oSystemLanguage = new SystemLanguagesModel();
                oSystemLanguage.LanguageID = 1;
                oSystemLanguage.LanguageName = "English";
                oSystemLanguage.LanguageCode = "en-US";
            }
            try
            {
                var cultureInfo = new CultureInfo(oSystemLanguage.LanguageCode);
                Thread.CurrentThread.CurrentUICulture = cultureInfo;
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(cultureInfo.Name);
                HttpCookie langCookie = new HttpCookie("culture", oSystemLanguage.LanguageCode);
                langCookie.Expires = DateTime.Now.AddYears(1);
                if (HttpContext.Current != null) { HttpContext.Current.Response.Cookies.Add(langCookie); }
            }
            catch (Exception) { }
            lstSystemLanguages = SystemLanguagesCOM.GetSystemLanguages();
            WebsiteTitle = PagesCOM.GetPageKeyByName("Website_Title", oSystemLanguage.LanguageID);
            lstSocialMedias = SocialMediaCOM.GetSocialMediaForWeb();
        }
    }
}