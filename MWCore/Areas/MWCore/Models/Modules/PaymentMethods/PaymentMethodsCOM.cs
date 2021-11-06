using MWCore.Areas.MWCore.Models.DBClasses;
using MWCore.Areas.MWCore.Models.DBClasses.PaymentMethods;
using MWCore.Areas.MWCore.Models.DBClasses.Settings;
using MWCore.Areas.MWCore.Models.Modules.SystemLanguages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MWCore.Areas.MWCore.Models.Modules.PaymentMethods
{
    public class PaymentMethodsCOM
    {
        public List<PaymentMethodsModel> GetPaymentsMethods(int LanguageID, bool Status = false)
        {
            using (MWCoreEntity db = new MWCoreEntity())
            {
                return (from paymentmethod in db.MW_PaymentMethods
                        join paymentmethod_loc in db.MW_PaymentMethods_Loc on paymentmethod.ID equals paymentmethod_loc.PaymentMethodID
                        where paymentmethod_loc.LanguageID == LanguageID && !paymentmethod.IsDeleted
                        && (Status == true ? paymentmethod.Status == true : true)
                        select new PaymentMethodsModel()
                        {
                            Image = paymentmethod.Image,
                            LanguageID = LanguageID,
                            Name = paymentmethod_loc.Name,
                            PaymentMethodID = paymentmethod.ID,
                            Status = paymentmethod.Status,
                            PaymentMethodType = paymentmethod.PaymentMethodType
                        }).ToList();
            }
        }

        public PaymentMethodsModel GetPaymentMethodDetails(int PaymentMethodID, int LanguageID)
        {
            using (MWCoreEntity db = new MWCoreEntity())
            {
                return (from paymentmethod in db.MW_PaymentMethods
                        join paymentmethod_loc in db.MW_PaymentMethods_Loc on paymentmethod.ID equals paymentmethod_loc.PaymentMethodID
                        where paymentmethod_loc.LanguageID == LanguageID && !paymentmethod.IsDeleted
                        && paymentmethod.ID == PaymentMethodID
                        select new PaymentMethodsModel()
                        {
                            Image = paymentmethod.Image,
                            LanguageID = LanguageID,
                            Name = paymentmethod_loc.Name,
                            PaymentMethodID = paymentmethod.ID,
                            Status = paymentmethod.Status,
                            PaymentMethodType = paymentmethod.PaymentMethodType
                        }).FirstOrDefault();
            }
        }

        public List<PaymentMethodsModel> SavePaymentMethod(PaymentMethodsModel oModel, List<SystemLanguagesModel> lstLanguages)
        {
            using (MWCoreEntity db = new MWCoreEntity())
            {
                MW_PaymentMethods oPaymentMethod = new MW_PaymentMethods();
                MW_PaymentMethods_Loc oPaymentMethod_Loc = new MW_PaymentMethods_Loc();
                if (oModel.PaymentMethodID > 0)
                {
                    oPaymentMethod = db.MW_PaymentMethods.FirstOrDefault(x => x.ID == oModel.PaymentMethodID);
                    oPaymentMethod_Loc = db.MW_PaymentMethods_Loc.FirstOrDefault(x => x.PaymentMethodID == oModel.PaymentMethodID && x.LanguageID == oModel.LanguageID);
                }
                oPaymentMethod.PaymentMethodType = oModel.PaymentMethodType;
                oPaymentMethod.Status = oModel.Status;
                oPaymentMethod.Image = oModel.Image;
                oPaymentMethod_Loc.Name = oModel.Name;
                oPaymentMethod_Loc.LanguageID = oModel.LanguageID;
                if (oModel.PaymentMethodID == 0)
                {
                    db.MW_PaymentMethods.Add(oPaymentMethod);
                    db.SaveChanges();
                    oPaymentMethod_Loc.PaymentMethodID = oPaymentMethod.ID;
                    db.MW_PaymentMethods_Loc.Add(oPaymentMethod_Loc);
                    db.SaveChanges();
                    int nCount = lstLanguages.Count - 1;
                    for (int nIndex = 0; nIndex <= nCount; nIndex++)
                    {
                        MW_PaymentMethods_Loc oPaymentMethodLoc = new MW_PaymentMethods_Loc();
                        oPaymentMethodLoc.PaymentMethodID = oPaymentMethod.ID;
                        oPaymentMethodLoc.Name = oModel.Name;
                        oPaymentMethodLoc.LanguageID = lstLanguages[nIndex].LanguageID;
                        db.MW_PaymentMethods_Loc.Add(oPaymentMethodLoc);
                    }
                }
                db.SaveChanges();
                return GetPaymentsMethods(oModel.LanguageID);
            }
        }

        #region Method :: DeletePaymentMethod
        public List<PaymentMethodsModel> DeletePaymentMethod(int PaymentMethodID, int LanguageID)
        {
            using (MWCoreEntity db = new MWCoreEntity())
            {
                MW_PaymentMethods oPaymentMethod = db.MW_PaymentMethods.Single(x => x.ID == PaymentMethodID);
                if (oPaymentMethod != null)
                {
                    oPaymentMethod.IsDeleted = true;
                    db.SaveChanges();
                }
                return GetPaymentsMethods(LanguageID);
            }
        }
        #endregion

        #region Method :: ChangeStatus
        public List<PaymentMethodsModel> ChangeStatus(int PaymentMethodID, int LanguageID)
        {
            using (MWCoreEntity db = new MWCoreEntity())
            {
                MW_PaymentMethods oPaymentMethod = db.MW_PaymentMethods.Single(x => x.ID == PaymentMethodID);
                if (oPaymentMethod != null)
                {
                    oPaymentMethod.Status = oPaymentMethod.Status == true ? false : true;
                    db.SaveChanges();
                }
                return GetPaymentsMethods(LanguageID);
            }
        }
        #endregion

        public static List<SelectListItem> GetPaymentsMethodsList(int LanguageID)
        {
            using (MWCoreEntity db = new MWCoreEntity())
            {
                return (from paymentmethod in db.MW_PaymentMethods
                        join paymentmethod_loc in db.MW_PaymentMethods_Loc on paymentmethod.ID equals paymentmethod_loc.PaymentMethodID
                        where paymentmethod_loc.LanguageID == LanguageID && !paymentmethod.IsDeleted
                        && paymentmethod.Status == true
                        select new SelectListItem()
                        {
                            Text = paymentmethod_loc.Name,
                            Value = paymentmethod.ID.ToString()
                        }).ToList();
            }
        }
    }
}