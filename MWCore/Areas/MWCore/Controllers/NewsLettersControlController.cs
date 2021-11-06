using MWCore.Areas.MWCore.Models;
using MWCore.Areas.MWCore.Models.BaseController;
using MWCore.Areas.MWCore.Models.Modules.NewsLettersSubscriptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MWCore.Areas.MWCore.Controllers
{
    public class NewsLettersControlController : MWCoreController
    {
        // GET: MWCore/NewsLettersControl
        public ActionResult Index()
        {
            MWCoreModel oModel = new MWCoreModel();
            return View(oModel);
        }
        public JsonResult SendNewsLetters(MWCoreModel oModel)
        {
            Hangfire.BackgroundJob.Enqueue(() => NewsLettersSubscriptionsCOM.SendEmailForSubscribers(oModel.oNewsLetter));
            return Json(true, JsonRequestBehavior.AllowGet);
        }
    }
}