using MWCore.Areas.MWCore.Models.Modules.Banners;
using MWCore.Areas.MWCore.Models.Modules.Pages;
using MWCore.Areas.MWCore.Models.Modules.SystemLanguages;
using MWCore.Models;
using MWCore.Models.BaseController;
using System.Web.Mvc;

namespace MWCore.Controllers
{
    public class HomeController : MWCoreFrontEndController
    {
        // GET: Home
        public ActionResult Index(string PageName)
        {
            MWFrontEndModel oModel = new MWFrontEndModel();
            PagesCOM oPagesCOM = new PagesCOM();
            if (PageName != null)
            {
                string sLanguage = oModel.oSystemLanguage.LanguageID == 1 ? "en" : "ar";
                
                oModel.oPage = oPagesCOM.GetPagesDetailsByURL(PageName, oModel.oSystemLanguage.LanguageID);
                if (oModel.oPage != null)
                {
                    if (oModel.oPage.IsPage)
                    {
                        if (oModel.oPage.IsPreDefinedPage)
                        {
                            return Redirect("/" + sLanguage + oModel.oPage.PageURL);
                        }
                        else
                        {
                            oModel.PageTitle = oModel.oPage.PageTitle;
                        }
                    }
                    else
                    {

                        return Redirect("/" + sLanguage + "/PageNotFound/Index");
                    }
                }
                else
                {
                    return Redirect("/" + sLanguage + "/PageNotFound/Index");
                }
            }
            else
            {
                oModel.oPage = oPagesCOM.GetPagesDetailsByURL("home", oModel.oSystemLanguage.LanguageID);
                BannersCOM oBannersCOM = new BannersCOM();
                oModel.lstBanners = oBannersCOM.GetBanners(true);
                oModel.BannerClass = "banner";
            }

            return View(oModel);
        }
        #region Method :: ChangeLanguage
        public void ChangeLanguage(int LanguageID, string CurrentURL)
        {
            SystemLanguagesCOM oSystemLanguagesCOM = new SystemLanguagesCOM();
            SystemLanguagesModel oSystemLanguage = oSystemLanguagesCOM.GetSystemLanguageDetails(LanguageID);
            Session["FrontEndSystemLangugage"] = oSystemLanguage;
            Response.Redirect(CurrentURL);
        }
        #endregion    
    }
}