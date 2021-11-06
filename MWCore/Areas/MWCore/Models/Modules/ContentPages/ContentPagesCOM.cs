/*****************************************************************************/
/* File Name     : ContentPagesCOM.cs                                       */
/* Created By    : Abdulla Hawwash                                         */
/* Creation Date : 19/12/2017                                             */
/* Comment       : Content Pages                                         */
/************************************************************************/

using MWCore.Areas.MWCore.Models.DBClasses;
using MWCore.Areas.MWCore.Models.DBClasses.ContentPages;
using MWCore.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace MWCore.Areas.MWCore.Models.Modules.ContentPages
{
    public class ContentPagesCOM
    {
        #region Method :: GetContentPages
        public List<MW_ContentPages_Loc> GetContentPages(int nLanguageID)
        {
            using (MWCoreEntity db = new MWCoreEntity())
            {
                return db.MW_ContentPages_Loc.Include(x => x.MW_ContentPages).Where(x => x.LanguageID == nLanguageID).ToList();
            }
        }
        #endregion

        #region Method :: GetContentPageDetails
        public MW_ContentPages_Loc GetContentPageDetails(int nPageID, int nLanguageID)
        {
            using (MWCoreEntity db = new MWCoreEntity())
            {
                return db.MW_ContentPages_Loc.Include(x => x.MW_ContentPages).Where(x => x.PageID == nPageID && x.LanguageID == nLanguageID).SingleOrDefault();
            }
        }
        #endregion

        #region Method :: SaveContentPage
        public List<MW_ContentPages_Loc> SaveContentPage(MWCoreModel oModel)
        {
            using (MWCoreEntity db = new MWCoreEntity())
            {
                MW_ContentPages_Loc oContentPage_Loc = db.MW_ContentPages_Loc.Include(x => x.MW_ContentPages).Single(x => x.PageID == oModel.oContentPage_Loc.PageID && x.LanguageID == oModel.oSystemLanguage.ID);
                if (oContentPage_Loc != null)
                {
                    //oContentPage_Loc.PageTitle = oModel.oContentPage_Loc.PageTitle;
                    oContentPage_Loc.PageDetails = oModel.oContentPage_Loc.PageDetails;
                    oContentPage_Loc.MW_ContentPages.UpdatedBy = oModel.oUserInfo.ID;
                    oContentPage_Loc.MW_ContentPages.UpdatedDate = DateTime.Today;
                    db.SaveChanges();
                }
                return db.MW_ContentPages_Loc.Include(x => x.MW_ContentPages).Where(x => x.LanguageID == oModel.oSystemLanguage.ID).ToList();
            }
        }
        #endregion

        public string GetChatUrl(int LanguageID)
        {
            string URL = System.Configuration.ConfigurationManager.AppSettings["DefaultWebsiteURL"].ToString();
            return URL + (LanguageID == 1 ? "/en/Chat" : "/ar/Chat");
        }
        public List<MW_ContentPages_Loc> GetHomePAgeContentPages(int LanguageID)
        {
            using (MWCoreEntity db = new MWCoreEntity())
            {
                List<MW_ContentPages_Loc> lstContentPages = new List<MW_ContentPages_Loc>();
                lstContentPages = db.MW_ContentPages_Loc.Include(x => x.MW_ContentPages).Where(x => x.PageID == 1 || x.PageID == 2 && x.LanguageID == LanguageID).ToList();
                return lstContentPages;
            }
        }
        public ContentPageDetails GetPageDetails(int PageID, int LanguageID)
        {
            using (MWCoreEntity db = new MWCoreEntity())
            {
                return (from contentpage in db.MW_ContentPages
                        join contentpage_loc in db.MW_ContentPages_Loc on contentpage.ID equals contentpage_loc.PageID
                        where contentpage.ID == PageID && contentpage_loc.LanguageID == LanguageID
                        select new ContentPageDetails()
                        {
                            ID = contentpage.ID,
                            PageDetails = contentpage_loc.PageDetails,
                            //PageTitle = contentpage_loc.PageTitle
                        }).FirstOrDefault();
            }
        }
    }
}