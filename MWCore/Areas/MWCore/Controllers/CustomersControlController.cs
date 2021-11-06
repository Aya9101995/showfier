using MWCore.Areas.MWCore.Models;
using MWCore.Areas.MWCore.Models.BaseController;
using MWCore.Areas.MWCore.Models.Modules.Categories;
using MWCore.Areas.MWCore.Models.Modules.Countries;
using MWCore.Areas.MWCore.Models.Modules.Customers.Components;
using MWCore.Areas.MWCore.Models.Modules.Customers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MWCore.Areas.MWCore.Controllers
{
    public class CustomersControlController : MWCoreController
    {
        // GET: MWCore/CustomersControl
        public ActionResult Index()
        {
            MWCoreModel oModel = new MWCoreModel();
            CustomersCOM oCustomersCOM = new CustomersCOM();
            oModel.lstCustomers = oCustomersCOM.GetCustomers(oModel.oSystemLanguage.ID);
            oModel.lstGenderList = new List<SelectListItem>()
            {
                new SelectListItem()
                {
                    Text="Male",
                    Value="1"
                }, new SelectListItem()
                {
                    Text="Female",
                    Value="2"
                }
            };
            return View(oModel);
        }

        public ActionResult ViewCustomer(int CustomerID)
        {
            MWCoreModel oModel = new MWCoreModel();
            CustomersCOM oCustomersCOM = new CustomersCOM();
            oModel.oCustomer = oCustomersCOM.GetCustomersFullDetails(CustomerID, oModel.oSystemLanguage.ID);
            return PartialView("_ViewCustomer", oModel);
        }

        public ActionResult EditCustomer(int CustomerID)
        {
            MWCoreModel oModel = new MWCoreModel();
            CustomersCOM oCustomersCOM = new CustomersCOM();
            if (CustomerID > 0)
            {
                oModel.oCustomer = oCustomersCOM.GetCustomerDetails(CustomerID);
            }

            oModel.lstCountriesPhoneCodesList = CountriesCOM.GetCountiresPhoneCodes();
            oModel.lstCategoriesItemsList = CategoriesCOM.GetCategoriesList(oModel.oSystemLanguage.ID);
            oModel.lstGenderList = new List<SelectListItem>()
            {
                new SelectListItem()
                {
                    Text="Male",
                    Value="1"
                }, new SelectListItem()
                {
                    Text="Female",
                    Value="2"
                }
            };
            return PartialView("_AddEditCustomers", oModel);
        }

        public ActionResult SaveCustomer(MWCoreModel oModel)
        {
            CustomersCOM oCustomersCOM = new CustomersCOM();
            oModel.lstCustomers = oCustomersCOM.SaveCustomer(oModel.oCustomer , oModel.oSystemLanguage.ID);
            
            return PartialView("_Customers", oModel);
        }

        [HttpPost]
        public JsonResult EmailAlreadyExistsAsync(CustomersModel oCustomer)
        {
            CustomersCOM oCustomersCOM = new CustomersCOM();
            var result = oCustomersCOM.CheckEmail(oCustomer);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult PhoneNumberAlreadyExistsAsync(FormCollection parm)
        {
            CustomersModel oModel = new CustomersModel();
            oModel.CustomerID = Convert.ToInt32(parm["oCustomer.CustomerID"]);
            oModel.PhoneCode = parm["oCustomer.PhoneCode"];
            oModel.PhoneNumber = parm["oCustomer.PhoneNumber"];
            CustomersCOM oCustomersCOM = new CustomersCOM();
            var result = oCustomersCOM.CheckPhoneNumber(oModel);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ChangeStatus(int CustomerID)
        {
            MWCoreModel oModel = new MWCoreModel();
            CustomersCOM oCustomersCOM = new CustomersCOM();
            oModel.lstCustomers = oCustomersCOM.ChangeStatus(CustomerID, oModel.oSystemLanguage.ID);
            return PartialView("_Customers", oModel);
        }
    }
}