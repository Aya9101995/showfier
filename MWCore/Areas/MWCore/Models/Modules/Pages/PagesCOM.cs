using MWCore.Areas.MWCore.Models.DBClasses;
using MWCore.Areas.MWCore.Models.DBClasses.Pages;
using MWCore.Areas.MWCore.Models.Modules.SystemLanguages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MWCore.Areas.MWCore.Models.Modules.Pages
{
    public class PagesCOM
    {
        public List<PagesModel> GetPages(int LanguageID, int ParentID, bool Status = false)
        {
            using (MWCoreEntity db = new MWCoreEntity())
            {
                return (from Pages in db.MW_Pages
                        join Pages_Loc in db.MW_Pages_Loc on Pages.ID equals Pages_Loc.PageID
                        where Pages_Loc.LanguageID == LanguageID && !Pages.IsDeleted && (Status == true ? Pages.Status == true : true)
                        && Pages.ParentID == ParentID
                        select new PagesModel()
                        {
                            LanguageID = LanguageID,
                            PageBanner = Pages.PageBanner,
                            ParentID = Pages.ParentID,
                            PageDetails = Pages_Loc.PageDetails,
                            PageID = Pages.ID,
                            PageTags = Pages_Loc.PageTags,
                            PageTitle = Pages_Loc.PageTitle,
                            PageURL = Pages_Loc.PageURL,
                            ShowInFooter = Pages.ShowInFooter,
                            ShowInMenu = Pages.ShowInMenu,
                            Status = Pages.Status,
                            IsPage = Pages.IsPage,
                            IsPreDefinedPage = Pages.IsPreDefinedPage,
                            PageName = Pages_Loc.PageName
                        }).ToList();
            }
        }

        public PagesModel GetPagesDetails(int PageID, int LanguageID, bool Status = false)
        {
            using (MWCoreEntity db = new MWCoreEntity())
            {
                return (from Pages in db.MW_Pages
                        join Pages_Loc in db.MW_Pages_Loc on Pages.ID equals Pages_Loc.PageID
                        where Pages_Loc.LanguageID == LanguageID && !Pages.IsDeleted && Pages.ID == PageID
                        select new PagesModel()
                        {
                            LanguageID = LanguageID,
                            ParentID = Pages.ParentID,
                            PageBanner = Pages.PageBanner,
                            PageDetails = Pages_Loc.PageDetails,
                            PageID = Pages.ID,
                            PageTags = Pages_Loc.PageTags,
                            PageTitle = Pages_Loc.PageTitle,
                            PageURL = Pages_Loc.PageURL,
                            ShowInFooter = Pages.ShowInFooter,
                            ShowInMenu = Pages.ShowInMenu,
                            Status = Pages.Status,
                            IsPage = Pages.IsPage,
                            IsPreDefinedPage = Pages.IsPreDefinedPage,
                            PageName = Pages_Loc.PageName
                        }).FirstOrDefault();
            }
        }

        public List<PagesModel> SavePages(PagesModel oModel, List<SystemLanguagesModel> lstSystemLanguages)
        {
            using (MWCoreEntity db = new MWCoreEntity())
            {
                MW_Pages oPages = new MW_Pages();
                MW_Pages_Loc oPages_Loc = new MW_Pages_Loc();
                if (oModel.PageID > 0)
                {
                    oPages = db.MW_Pages.FirstOrDefault(x => x.ID == oModel.PageID);
                    oPages_Loc = db.MW_Pages_Loc.FirstOrDefault(x => x.PageID == oModel.PageID && x.LanguageID == oModel.LanguageID);
                }
                oPages.Status = oModel.Status;
                oPages.IsPage = oModel.IsPage;
                oPages.IsPreDefinedPage = oModel.IsPreDefinedPage;
                oPages.ParentID = oModel.ParentID;
                if (oPages.IsPage)
                {
                    oPages_Loc.PageTitle = oModel.PageTitle;
                    oPages.PageBanner = oModel.PageBanner;
                    oPages.ShowInFooter = oModel.ShowInFooter;
                    oPages.ShowInMenu = oModel.ShowInMenu;
                    oPages_Loc.PageDetails = oModel.PageDetails;
                    oPages_Loc.PageTags = oModel.PageTags;
                    oPages_Loc.PageURL = oModel.PageURL;
                }
                else
                {
                    oPages_Loc.PageTitle = "";
                    oPages.PageBanner = "";
                    oPages.ShowInFooter = false;
                    oPages.ShowInMenu = false;
                    oPages_Loc.PageDetails = "";
                    oPages_Loc.PageTags = "";
                    oPages_Loc.PageURL = "";
                }

                oPages_Loc.PageName = oModel.PageName;
                oPages_Loc.LanguageID = oModel.LanguageID;
                if (oModel.PageID == 0)
                {
                    db.MW_Pages.Add(oPages);
                    db.SaveChanges();
                    oPages_Loc.PageID = oPages.ID;
                    db.MW_Pages_Loc.Add(oPages_Loc);
                    db.SaveChanges();
                    int nCount = lstSystemLanguages.Count - 1;
                    for (int nIndex = 0; nIndex <= nCount; nIndex++)
                    {
                        MW_Pages_Loc oPagesLoc = new MW_Pages_Loc();
                        oPagesLoc.PageID = oPages.ID;
                        oPagesLoc.PageName = oModel.PageName;
                        if (oPages.IsPage)
                        {
                            oPagesLoc.PageTitle = oModel.PageTitle;
                            oPagesLoc.PageDetails = oModel.PageDetails;
                            oPagesLoc.PageTags = oModel.PageTags;
                            oPagesLoc.PageURL = oModel.PageURL;
                        }
                        else
                        {
                            oPagesLoc.PageTitle = "";
                            oPagesLoc.PageDetails = "";
                            oPagesLoc.PageTags = "";
                            oPagesLoc.PageURL = "";
                        }
                        oPagesLoc.LanguageID = lstSystemLanguages[nIndex].LanguageID;
                        db.MW_Pages_Loc.Add(oPagesLoc);
                    }
                }
                db.SaveChanges();
                return GetPages(oModel.LanguageID, oModel.ParentID);
            }
        }

        public List<PagesModel> ChangeStatus(int PageID, int LanguageID)
        {
            using (MWCoreEntity db = new MWCoreEntity())
            {
                MW_Pages Pages = db.MW_Pages.FirstOrDefault(x => x.ID == PageID);
                if (Pages != null)
                {
                    Pages.Status = Pages.Status == true ? false : true;
                    db.SaveChanges();
                }
                return GetPages(LanguageID, Pages.ParentID);
            }
        }

        public List<PagesModel> DeleteRecord(int PageID, int LanguageID)
        {
            using (MWCoreEntity db = new MWCoreEntity())
            {
                MW_Pages Pages = db.MW_Pages.FirstOrDefault(x => x.ID == PageID);
                if (Pages != null)
                {
                    Pages.IsDeleted = true;
                    db.SaveChanges();
                }
                return GetPages(LanguageID, Pages.ParentID);
            }
        }

        public bool checkURL(PagesModel oModel)
        {
            using (MWCoreEntity db = new MWCoreEntity())
            {
                if (oModel.PageID == 0)
                {
                    return !db.MW_Pages_Loc.Any(x => x.PageURL == oModel.PageURL && x.LanguageID == oModel.LanguageID);
                }
                else
                {
                    return !db.MW_Pages_Loc.Any(x => x.PageURL == oModel.PageURL && x.PageID != oModel.PageID && x.LanguageID == oModel.LanguageID);
                }
            }
        }

        public PagesModel GetPagesDetailsByURL(string PageURL, int LanguageID)
        {
            using (MWCoreEntity db = new MWCoreEntity())
            {
                PagesModel oPage = (from Pages in db.MW_Pages
                                    join Pages_Loc in db.MW_Pages_Loc on Pages.ID equals Pages_Loc.PageID
                                    where Pages_Loc.LanguageID == LanguageID && !Pages.IsDeleted && (Pages_Loc.PageURL.ToLower() == PageURL.ToLower() || Pages_Loc.PageName.ToLower() == PageURL.ToLower())
                                    select new PagesModel()
                                    {
                                        LanguageID = LanguageID,
                                        PageDetails = Pages_Loc.PageDetails,
                                        PageBanner = Pages.PageBanner,
                                        PageID = Pages.ID,
                                        PageTags = Pages_Loc.PageTags,
                                        PageTitle = Pages_Loc.PageTitle,
                                        PageURL = Pages_Loc.PageURL,
                                        ShowInFooter = Pages.ShowInFooter,
                                        ShowInMenu = Pages.ShowInMenu,
                                        Status = Pages.Status,
                                        PageName = Pages_Loc.PageName,
                                        IsPage = Pages.IsPage,
                                        IsPreDefinedPage = Pages.IsPreDefinedPage
                                    }).FirstOrDefault();
                if (oPage != null)
                {
                    oPage.SecondURL = db.MW_Pages_Loc.FirstOrDefault(x => x.PageID == oPage.PageID && x.LanguageID != oPage.LanguageID).PageURL;
                }
                return oPage;
            }
        }

        public List<PagesKeysModel> GetPagesKey(int LanguageID, int PageID)
        {
            using (MWCoreEntity db = new MWCoreEntity())
            {
                return (from key in db.MW_PagesKeys
                        join key_loc in db.MW_PagesKeys_Loc on key.ID equals key_loc.KeyID
                        where key_loc.LanguageID == LanguageID && !key.IsDeleted
                        && key.PageID == PageID
                        select new PagesKeysModel()
                        {
                            LanguageID = LanguageID,
                            PageID = key.PageID,
                            KeyID = key.ID,
                            KeyName = key.KeyName,
                            KeySourceID = key.KeySourceID,
                            KeyType = key.KeyType,
                            KeyValue = key_loc.KeyValue
                        }).ToList();
            }
        }

        public PagesKeysModel GetPageKeyDetails(int LanguageID, int KeyID)
        {
            using (MWCoreEntity db = new MWCoreEntity())
            {
                return (from key in db.MW_PagesKeys
                        join key_loc in db.MW_PagesKeys_Loc on key.ID equals key_loc.KeyID
                        where key_loc.LanguageID == LanguageID && !key.IsDeleted
                        && key.ID == KeyID
                        select new PagesKeysModel()
                        {
                            LanguageID = LanguageID,
                            PageID = key.PageID,
                            KeyID = key.ID,
                            KeyName = key.KeyName,
                            KeySourceID = key.KeySourceID,
                            KeyType = key.KeyType,
                            KeyValue = key_loc.KeyValue
                        }).FirstOrDefault();
            }
        }

        public List<PagesKeysModel> SavePageKey(PagesKeysModel oModel, List<SystemLanguagesModel> lstSystemLanguages)
        {
            using (MWCoreEntity db = new MWCoreEntity())
            {
                MW_PagesKeys oPageKey = new MW_PagesKeys();
                MW_PagesKeys_Loc oPageKey_Loc = new MW_PagesKeys_Loc();
                if (oModel.KeyID > 0)
                {
                    oPageKey_Loc = db.MW_PagesKeys_Loc.FirstOrDefault(x => x.KeyID == oModel.KeyID && x.LanguageID == oModel.LanguageID);
                    oPageKey = db.MW_PagesKeys.FirstOrDefault(x => x.ID == oPageKey_Loc.KeyID);
                }

                oPageKey.KeyName = oModel.KeyName;
                oPageKey.PageID = oModel.PageID;
                oPageKey_Loc.KeyValue = oModel.KeyValue;
                oPageKey_Loc.LanguageID = oModel.LanguageID;
                oPageKey.KeyType = oModel.KeyType;
                if (oModel.KeyID == 0)
                {
                    int nMax = db.MW_PagesKeys.Count() > 0 ? db.MW_PagesKeys.Max(select => select.KeySourceID) : 0;
                    oPageKey.KeySourceID = nMax + 1;
                    oPageKey_Loc.KeyID = oPageKey.ID;
                    db.MW_PagesKeys.Add(oPageKey);
                    db.MW_PagesKeys_Loc.Add(oPageKey_Loc);
                    db.SaveChanges();
                    int nCount = lstSystemLanguages.Count - 1;
                    for (int nIndex = 0; nIndex <= nCount; nIndex++)
                    {
                        MW_PagesKeys_Loc oPageKeyLoc = new MW_PagesKeys_Loc();
                        oPageKeyLoc.KeyID = oPageKey.ID;
                        oPageKeyLoc.KeyValue = oModel.KeyValue;
                        oPageKeyLoc.LanguageID = lstSystemLanguages[nIndex].LanguageID;
                        db.MW_PagesKeys_Loc.Add(oPageKeyLoc);
                    }
                }
                db.SaveChanges();
                return GetPagesKey(oModel.LanguageID, oModel.PageID);
            }
        }

        public List<PagesModel> DeletePageKEy(int KeyID, int LanguageID)
        {
            using (MWCoreEntity db = new MWCoreEntity())
            {
                MW_PagesKeys PageKey = db.MW_PagesKeys.FirstOrDefault(x => x.ID == KeyID);
                if (PageKey != null)
                {
                    PageKey.IsDeleted = true;
                    db.SaveChanges();
                }
                return GetPages(LanguageID, PageKey.PageID);
            }
        }

        public static string GetPageKeyByName(string KeyName, int LanguageID)
        {
            using (MWCoreEntity db = new MWCoreEntity())
            {
                return (from key in db.MW_PagesKeys
                        join key_loc in db.MW_PagesKeys_Loc on key.ID equals key_loc.KeyID
                        where key_loc.LanguageID == LanguageID && !key.IsDeleted
                        && key.KeyName.ToLower() == KeyName.ToLower()
                        select key_loc.KeyValue).FirstOrDefault();
            }
        }
    }
}