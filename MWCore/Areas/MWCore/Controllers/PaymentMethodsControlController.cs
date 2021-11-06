using MWCore.Areas.MWCore.Models;
using MWCore.Areas.MWCore.Models.BaseController;
using MWCore.Areas.MWCore.Models.Modules.PaymentMethods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MWCore.Areas.MWCore.Controllers
{
    public class PaymentMethodsControlController : MWCoreController
    {
        // GET: MWCore/PaymentMethodsControl
        public ActionResult Index()
        {
            MWCoreModel oModel = new MWCoreModel();
            PaymentMethodsCOM oPaymentsMethodsCOM = new PaymentMethodsCOM();
            oModel.lstPaymentMethods = oPaymentsMethodsCOM.GetPaymentsMethods(oModel.oSystemLanguage.ID);
            return View(oModel);
        }
        public ActionResult AddEditPaymentsMethods(int? PaymentMethodID)
        {
            MWCoreModel oModel = new MWCoreModel();
            if (PaymentMethodID != null && PaymentMethodID > 0)
            {
                PaymentMethodsCOM oPaymentsMethodsCOM = new PaymentMethodsCOM();
                oModel.oPaymentMethods = oPaymentsMethodsCOM.GetPaymentMethodDetails((int)PaymentMethodID, oModel.oSystemLanguage.ID);
            }
            else
            {
                oModel.oPaymentMethods = new PaymentMethodsModel();
                oModel.oPaymentMethods.LanguageID = oModel.oSystemLanguage.ID;
            }
            oModel.lstPaymentsMethodsTypes = new List<SelectListItem>()
            {
                new SelectListItem()
                {
                    Text="Cash On Delivery",
                    Value = "1"
                },
                new SelectListItem()
                {
                    Text="KNET",
                    Value = "2"
                }
            };
            return PartialView("_AddEditPaymentsMethods", oModel);
        }

        public ActionResult SavePaymentMethod(MWCoreModel oModel)
        {
            PaymentMethodsCOM oPaymentsMethodsCOM = new PaymentMethodsCOM();
            oModel.lstPaymentMethods = oPaymentsMethodsCOM.SavePaymentMethod(oModel.oPaymentMethods, oModel.lstSystemLanguages);
            return PartialView("_PaymentsMethods", oModel);
        }

        public ActionResult DeletePaymentMethod(int PaymentMethodID)
        {
            MWCoreModel oModel = new MWCoreModel();
            PaymentMethodsCOM oPaymentsMethodsCOM = new PaymentMethodsCOM();
            oModel.lstPaymentMethods = oPaymentsMethodsCOM.DeletePaymentMethod(PaymentMethodID, oModel.oSystemLanguage.ID);
            return PartialView("_PaymentsMethods", oModel);
        }

        public ActionResult ChangeStatus(int PaymentMethodID)
        {
            MWCoreModel oModel = new MWCoreModel();
            PaymentMethodsCOM oPaymentsMethodsCOM = new PaymentMethodsCOM();
            oModel.lstPaymentMethods = oPaymentsMethodsCOM.ChangeStatus(PaymentMethodID, oModel.oSystemLanguage.ID);
            return PartialView("_PaymentsMethods", oModel);
        }
    }
}