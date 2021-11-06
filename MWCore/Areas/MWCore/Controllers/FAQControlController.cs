/*****************************************************************************/
/* File Name     : FAQControlController.cs                                  */
/* Created By    : Abdulla Hawwash                                         */
/* Creation Date : 19/12/2017                                             */
/* Comment       : FAQ Controller                                        */
/************************************************************************/

using MWCore.Areas.MWCore.Models;
using MWCore.Areas.MWCore.Models.BaseController;
using MWCore.Areas.MWCore.Models.DBClasses;
using MWCore.Areas.MWCore.Models.DBClasses.FAQs;
using MWCore.Areas.MWCore.Models.Modules.FAQ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MWCore.Areas.MWCore.Controllers
{
    public class FAQControlController : MWCoreController
    {
        // GET: MWCore/FAQControl
        #region ActionResult :: Index
        public ActionResult Index()
        {
            MWCoreModel oModel = new MWCoreModel();
            FAQCOM oFAQ = new FAQCOM();
            oModel.lstFAQ = oFAQ.GetFAQ(oModel.oSystemLanguage.ID);
            oModel.oFAQ = new FAQModel();
            return View(oModel);
        }
        #endregion

        #region ActionResult :: AddEditFAQ
        public ActionResult AddEditFAQ(int? FAQID)
        {
            MWCoreModel oModel = new MWCoreModel();
            if (FAQID != null && FAQID > 0)
            {
                FAQCOM oFAQ = new FAQCOM();
                oModel.oFAQ = oFAQ.GetFAQDetails((int)FAQID, oModel.oSystemLanguage.ID);
            }
            else
            {

                oModel.oFAQ = new FAQModel()
                {
                    FAQID = 0
                };
            }
            using (MWCoreEntity db = new MWCoreEntity())
            {
                List<MW_FAQ> lstFAQs = db.MW_FAQ.OrderBy(x => x.SortOrder).ToList();
                List<int> lstsortOrder = new List<int>();
                foreach (var item in lstFAQs)
                {
                    if (item.SortOrder != oModel.oFAQ.SortOrder)
                    {
                        lstsortOrder.Add(Convert.ToInt32(item.SortOrder));

                    }
                }
                oModel.lstSortOrder = lstsortOrder;
            }
            return PartialView("_AddEditFAQ", oModel);
        }
        #endregion

        #region ActionResult :: SaveFAQ
        public ActionResult SaveFAQ(MWCoreModel oModel)
        {
            FAQCOM oFAQ = new FAQCOM();
            oModel.lstFAQ = oFAQ.SaveFAQ(oModel);
            return PartialView("_FAQ", oModel);
        }
        #endregion

        #region ActionResult :: DeleteFAQ
        public ActionResult DeleteFAQ(int FAQID)
        {
            MWCoreModel oModel = new MWCoreModel();
            FAQCOM oFAQ = new FAQCOM();
            oModel.lstFAQ = oFAQ.DeleteFAQ(FAQID, oModel);
            return PartialView("_FAQ", oModel);
        }
        #endregion

        #region ActionResult :: ChangeStatus
        public ActionResult ChangeStatus(int FAQID)
        {
            MWCoreModel oModel = new MWCoreModel();
            FAQCOM oFAQ = new FAQCOM();
            oModel.lstFAQ = oFAQ.ChangeStatus(FAQID, oModel);
            oModel.oFAQ = new FAQModel();
            return PartialView("_FAQ", oModel);
        }
        #endregion
    }
}