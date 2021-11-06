/*****************************************************************************/
/* File Name     : FAQCOM.cs                                                */
/* Created By    : Abdulla Hawwash                                         */
/* Creation Date : 19/12/2017                                             */
/* Comment       : FAQ                                                   */
/************************************************************************/

using MWCore.Areas.MWCore.Models.DBClasses;
using MWCore.Areas.MWCore.Models.DBClasses.FAQs;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace MWCore.Areas.MWCore.Models.Modules.FAQ
{
    public class FAQCOM
    {
        #region Method :: GetFAQ
        public List<FAQModel> GetFAQ(int nLanguageID, bool Status = false)
        {
            using (MWCoreEntity db = new MWCoreEntity())
            {
                return (from faq in db.MW_FAQ
                        join faq_loc in db.MW_FAQ_Loc on faq.ID equals faq_loc.FAQID
                        where faq_loc.LanguageID == nLanguageID && !faq.IsDeleted
                        && (Status ? faq.Status : true)
                        select new FAQModel()
                        {
                            FAQAnswer = faq_loc.FAQAnswer,
                            FAQQuetion = faq_loc.FAQQuetion,
                            FAQID = faq.ID,
                            LanguageID = faq_loc.LanguageID,
                            SortOrder = faq.SortOrder,
                            Status = faq.Status,
                        }).OrderBy(x => x.SortOrder).ToList();
            }
        }
        #endregion

        #region Method :: GetFAQDetails
        public FAQModel GetFAQDetails(int FAQID, int nLanguageID)
        {
            using (MWCoreEntity db = new MWCoreEntity())
            {
                return (from faq in db.MW_FAQ
                        join faq_loc in db.MW_FAQ_Loc on faq.ID equals faq_loc.FAQID
                        where faq_loc.LanguageID == nLanguageID && !faq.IsDeleted && faq.ID == FAQID
                        select new FAQModel()
                        {
                            FAQAnswer = faq_loc.FAQAnswer,
                            FAQQuetion = faq_loc.FAQQuetion,
                            FAQID = faq.ID,
                            LanguageID = faq_loc.LanguageID,
                            SortOrder = faq.SortOrder,
                            Status = faq.Status
                        }).FirstOrDefault();
            }
        }
        #endregion

        #region Method :: SaveFAQ
        public List<FAQModel> SaveFAQ(MWCoreModel oModel)
        {
            using (MWCoreEntity db = new MWCoreEntity())
            {
                MW_FAQ oFAQ = new MW_FAQ();
                MW_FAQ_Loc oFAQ_Loc = new MW_FAQ_Loc();
                if (oModel.oFAQ.FAQID > 0)
                {
                    oFAQ_Loc = db.MW_FAQ_Loc.FirstOrDefault(x => x.FAQID == oModel.oFAQ.FAQID && x.LanguageID == oModel.oSystemLanguage.ID);
                    oFAQ = db.MW_FAQ.FirstOrDefault(x => x.ID == oFAQ_Loc.FAQID);
                }
                oFAQ.Status = oModel.oFAQ.Status;
                oFAQ.SortOrder = oModel.oFAQ.SortOrder;
                oFAQ_Loc.FAQQuetion = oModel.oFAQ.FAQQuetion;
                oFAQ_Loc.FAQAnswer = oModel.oFAQ.FAQAnswer;
                oFAQ_Loc.LanguageID = oModel.oSystemLanguage.ID;
                if (oModel.oFAQ.FAQID == 0)
                {
                    oFAQ_Loc.FAQID = oFAQ.ID;
                    oFAQ_Loc.CreatedBy = oModel.oUserInfo.ID;
                    oFAQ_Loc.CreatedDate = DateTime.Today;
                    db.MW_FAQ.Add(oFAQ);
                    db.MW_FAQ_Loc.Add(oFAQ_Loc);
                    db.SaveChanges();
                    int nCount = oModel.lstSystemLanguages.Count - 1;
                    for (int nIndex = 0; nIndex <= nCount; nIndex++)
                    {
                        MW_FAQ_Loc oFAQLoc = new MW_FAQ_Loc();
                        oFAQLoc.FAQID = oFAQ.ID;
                        oFAQLoc.FAQQuetion = oModel.oFAQ.FAQQuetion;
                        oFAQLoc.FAQAnswer = oModel.oFAQ.FAQAnswer;
                        oFAQLoc.LanguageID = oModel.lstSystemLanguages[nIndex].LanguageID;
                        oFAQLoc.CreatedBy = oModel.oUserInfo.ID;
                        oFAQLoc.CreatedDate = DateTime.Today;
                        db.MW_FAQ_Loc.Add(oFAQLoc);
                    }
                }

                db.SaveChanges();
                return GetFAQ(oModel.oSystemLanguage.ID);
            }
        }
        #endregion

        #region Method :: DeleteFAQ
        public List<FAQModel> DeleteFAQ(int FAQID, MWCoreModel oModel)
        {
            using (MWCoreEntity db = new MWCoreEntity())
            {
                MW_FAQ oFAQ = db.MW_FAQ.Single(x => x.ID == FAQID);
                if (oFAQ != null)
                {
                    List<MW_FAQ_Loc> lstFAQ_Loc = db.MW_FAQ_Loc.Where(x => x.FAQID == FAQID).ToList();
                    db.MW_FAQ_Loc.RemoveRange(lstFAQ_Loc);
                    db.MW_FAQ.Remove(oFAQ);
                    db.SaveChanges();
                }
                return GetFAQ(oModel.oSystemLanguage.ID);
            }
        }
        #endregion

        #region Method :: ChangeStatus
        public List<FAQModel> ChangeStatus(int FAQID, MWCoreModel oModel)
        {
            using (MWCoreEntity db = new MWCoreEntity())
            {
                MW_FAQ oFAQ = db.MW_FAQ.Single(x => x.ID == FAQID);
                if (oFAQ != null)
                {
                    oFAQ.Status = oFAQ.Status == true ? false : true;
                    db.SaveChanges();
                }
                return GetFAQ(oModel.oSystemLanguage.ID);
            }
        }
        #endregion
    }
}