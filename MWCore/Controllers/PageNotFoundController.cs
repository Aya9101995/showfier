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
    public class PageNotFoundController : MWCoreFrontEndController
    {
        // GET: PageNotFound
        public ActionResult Index()
        {
            MWFrontEndModel oModel = new MWFrontEndModel();
            PagesCOM oPagesCOM = new PagesCOM();
            oModel.oPage = oPagesCOM.GetPagesDetailsByURL("pagenotfound", oModel.oSystemLanguage.LanguageID);
            return View(oModel);
        }
    }
}