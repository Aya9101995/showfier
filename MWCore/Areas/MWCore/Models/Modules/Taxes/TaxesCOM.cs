using MWCore.Areas.MWCore.Models.DBClasses;
using MWCore.Areas.MWCore.Models.DBClasses.Taxes;
using MWCore.Areas.MWCore.Models.Modules.SystemLanguages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MWCore.Areas.MWCore.Models.Modules.Taxes
{
    public class TaxesCOM
    {
        #region GetTaxes
        public List<TaxesModel> GetTaxes(int languageID)
        {
            using (MWCoreEntity db = new MWCoreEntity())
            {
                return (from tax in db.MW_Taxes
                        join tax_loc in db.MW_Taxes_Loc on tax.ID equals tax_loc.TaxID
                        where tax_loc.LanguageID == languageID && !tax.IsDeleted
                        select new TaxesModel()
                        {
                            Status = tax.Status,
                            TaxName = tax_loc.TaxName,
                            taxID = tax.ID,
                            TaxValue = tax.TaxValue,
                            LanguageID = languageID
                        }).ToList();
            }
        }
        #endregion

        #region DeleteTax
        public List<TaxesModel> DeleteTax(int TaxID, int LanguageID)
        {
            using (MWCoreEntity db = new MWCoreEntity())
            {
                MW_Taxes tax = db.MW_Taxes.Where(x => x.ID == TaxID).FirstOrDefault();
                if (tax != null)
                {
                    tax.IsDeleted = true;
                    db.SaveChanges();
                }
                return GetTaxes(LanguageID);
            }
        }
        #endregion

        #region ChangeStatus
        public List<TaxesModel> ChangeStatus(int TaxID, int LanguageID)
        {
            using (MWCoreEntity db = new MWCoreEntity())
            {
                MW_Taxes tax = db.MW_Taxes.Where(x => x.ID == TaxID).FirstOrDefault();
                if (tax != null)
                {
                    tax.Status = tax.Status == true ? false : true;
                    db.SaveChanges();
                }
                return GetTaxes(LanguageID);
            }
        }
        #endregion

        #region Method :: GetTaxDetails
        public TaxesModel GetTaxDetails(int TaxID, int LanguageID)
        {
            using (MWCoreEntity db = new MWCoreEntity())
            {
                return (from tax in db.MW_Taxes
                        join tax_loc in db.MW_Taxes_Loc on tax.ID equals tax_loc.TaxID
                        where tax_loc.LanguageID == LanguageID && !tax.IsDeleted && tax.ID == TaxID
                        select new TaxesModel()
                        {
                            Status = tax.Status,
                            TaxName = tax_loc.TaxName,
                            taxID = tax.ID,
                            TaxValue = tax.TaxValue,
                            LanguageID = LanguageID
                        }).FirstOrDefault();
            }
        }
        #endregion

        #region Method :: SaveTax
        public List<TaxesModel> SaveTax(TaxesModel oModel, List<SystemLanguagesModel> lstLanguages)
        {
            using (MWCoreEntity db = new MWCoreEntity())
            {
                MW_Taxes oTax = new MW_Taxes();
                MW_Taxes_Loc oTax_Loc = new MW_Taxes_Loc();
                if (oModel.taxID > 0)
                {
                    oTax_Loc = db.MW_Taxes_Loc.Single(x => x.TaxID == oModel.taxID && x.LanguageID == oModel.LanguageID);
                    oTax = db.MW_Taxes.FirstOrDefault(x => x.ID == oTax_Loc.TaxID);
                }

                oTax.IsDeleted = false;
                oTax.Status = oModel.Status;
                oTax.TaxValue = oModel.TaxValue;
                oTax_Loc.TaxName = oModel.TaxName;
                oTax_Loc.LanguageID = oModel.LanguageID;

                if (oModel.taxID == 0)
                {
                    db.MW_Taxes.Add(oTax);
                    db.SaveChanges();
                    oTax_Loc.TaxID = oTax.ID;
                    db.MW_Taxes_Loc.Add(oTax_Loc);
                    int nCount = lstLanguages.Count - 1;
                    for (int nIndex = 0; nIndex <= nCount; nIndex++)
                    {
                        MW_Taxes_Loc oTaxLoc = new MW_Taxes_Loc();
                        oTaxLoc.TaxID = oTax.ID;
                        oTaxLoc.TaxName = oModel.TaxName;
                        oTaxLoc.LanguageID = lstLanguages[nIndex].LanguageID;
                        db.MW_Taxes_Loc.Add(oTaxLoc);
                    }
                }
                db.SaveChanges();
                return GetTaxes(oModel.LanguageID);
            }
        }
        #endregion

        #region Method :: GetTaxesAPI
        public List<TaxesModel> GetTaxesAPI(int LanguageID)
        {
            using (MWCoreEntity db = new MWCoreEntity())
            {
                return (from tax in db.MW_Taxes
                        join tax_loc in db.MW_Taxes_Loc on tax.ID equals tax_loc.TaxID
                        where tax_loc.LanguageID == LanguageID && !tax.IsDeleted && tax.Status == true
                        select new TaxesModel()
                        {
                            Status = tax.Status,
                            TaxName = tax_loc.TaxName,
                            taxID = tax.ID,
                            TaxValue = tax.TaxValue,
                            LanguageID = LanguageID
                        }).ToList();
            }
        }
        #endregion

        #region Method :: GetTaxesList
        public static List<SelectListItem> GetTaxesList(int LanguageID)
        {
            using (MWCoreEntity db = new MWCoreEntity())
            {
                return (from tax in db.MW_Taxes
                        join tax_loc in db.MW_Taxes_Loc on tax.ID equals tax_loc.TaxID
                        where tax_loc.LanguageID == LanguageID && !tax.IsDeleted
                        select new SelectListItem()
                        {
                            Text = tax_loc.TaxName,
                            Value = tax_loc.TaxID.ToString()
                        }).ToList();
            }
        }
        #endregion
    }
}