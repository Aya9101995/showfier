using MWCore.Areas.MWCore.Models.Modules.FAQ;
using MWCore.Areas.MWCore.Models.Modules.Pages;
using MWCore.Models;
using MWCore.Models.BaseController;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MWCore.Controllers
{
    public class FAQController : MWCoreFrontEndController
    {
        // GET: FAQ
        public ActionResult Index()
        {
            MWFrontEndModel oModel = new MWFrontEndModel();
            PagesCOM oPagesCOM = new PagesCOM();
            oModel.oPage = oPagesCOM.GetPagesDetailsByURL("FAQ", oModel.oSystemLanguage.LanguageID);
            FAQCOM oFAQCOM = new FAQCOM();
            oModel.lstFAQs = oFAQCOM.GetFAQ(oModel.oSystemLanguage.LanguageID, true);
            return View(oModel);
        }
    }
}