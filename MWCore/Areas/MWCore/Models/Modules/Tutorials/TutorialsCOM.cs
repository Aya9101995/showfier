using MWCore.Areas.MWCore.Models.DBClasses;
using MWCore.Areas.MWCore.Models.DBClasses.Tutorials;
using MWCore.Areas.MWCore.Models.Modules.SystemLanguages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MWCore.Areas.MWCore.Models.Modules.Tutorials
{
    public class TutorialsCOM
    {
        public List<TutorialsModel> GetTutorials(int LanguageID, bool Status = false)
        {
            using (MWCoreEntity db = new MWCoreEntity())
            {
                return (from Tutorial in db.MW_Tutorials
                        join Tutorial_loc in db.MW_Tutorials_Loc on Tutorial.ID equals Tutorial_loc.TutorialID
                        where Tutorial_loc.LanguageID == LanguageID && !Tutorial.IsDeleted
                        && (Status == true ? Tutorial.Status == true : true)
                        select new TutorialsModel()
                        {
                            Image = Tutorial_loc.Image,
                            LanguageID = LanguageID,
                            Title = Tutorial_loc.Title,
                            TutorialID = Tutorial.ID,
                            Status = Tutorial.Status,
                            Description = Tutorial_loc.Description,
                            SortOrder = Tutorial.SortOrder
                        }).OrderBy(x => x.SortOrder).ToList();
            }
        }

        public TutorialsModel GetTutorialDetails(int TutorialID, int LanguageID)
        {
            using (MWCoreEntity db = new MWCoreEntity())
            {
                return (from Tutorial in db.MW_Tutorials
                        join Tutorial_loc in db.MW_Tutorials_Loc on Tutorial.ID equals Tutorial_loc.TutorialID
                        where Tutorial_loc.LanguageID == LanguageID && !Tutorial.IsDeleted
                        && Tutorial.ID == TutorialID
                        select new TutorialsModel()
                        {
                            Image = Tutorial_loc.Image,
                            LanguageID = LanguageID,
                            Title = Tutorial_loc.Title,
                            TutorialID = Tutorial.ID,
                            Status = Tutorial.Status,
                            Description = Tutorial_loc.Description,
                            SortOrder = Tutorial.SortOrder
                        }).FirstOrDefault();
            }
        }

        public List<TutorialsModel> SaveTutorial(TutorialsModel oModel, List<SystemLanguagesModel> lstLanguages)
        {
            using (MWCoreEntity db = new MWCoreEntity())
            {
                MW_Tutorials oTutorial = new MW_Tutorials();
                MW_Tutorials_Loc oTutorial_Loc = new MW_Tutorials_Loc();
                if (oModel.TutorialID > 0)
                {
                    oTutorial = db.MW_Tutorials.FirstOrDefault(x => x.ID == oModel.TutorialID);
                    oTutorial_Loc = db.MW_Tutorials_Loc.FirstOrDefault(x => x.TutorialID == oModel.TutorialID && x.LanguageID == oModel.LanguageID);
                }
                oTutorial.SortOrder = oModel.SortOrder;
                oTutorial.Status = oModel.Status;
                oTutorial_Loc.Image = oModel.Image;
                oTutorial_Loc.Title = oModel.Title;
                oTutorial_Loc.Description = oModel.Description;
                oTutorial_Loc.LanguageID = oModel.LanguageID;
                if (oModel.TutorialID == 0)
                {
                    db.MW_Tutorials.Add(oTutorial);
                    db.SaveChanges();
                    oTutorial_Loc.TutorialID = oTutorial.ID;
                    db.MW_Tutorials_Loc.Add(oTutorial_Loc);
                    db.SaveChanges();
                    int nCount = lstLanguages.Count - 1;
                    for (int nIndex = 0; nIndex <= nCount; nIndex++)
                    {
                        MW_Tutorials_Loc oTutorialLoc = new MW_Tutorials_Loc();
                        oTutorialLoc.TutorialID = oTutorial.ID;
                        oTutorialLoc.Title = oModel.Title;
                        oTutorialLoc.Description = oModel.Description;
                        oTutorialLoc.Image = oModel.Image;
                        oTutorialLoc.LanguageID = lstLanguages[nIndex].LanguageID;
                        db.MW_Tutorials_Loc.Add(oTutorialLoc);
                    }
                }
                db.SaveChanges();
                return GetTutorials(oModel.LanguageID);
            }
        }

        #region Method :: DeleteTutorial
        public List<TutorialsModel> DeleteTutorial(int TutorialID, int LanguageID)
        {
            using (MWCoreEntity db = new MWCoreEntity())
            {
                MW_Tutorials oTutorial = db.MW_Tutorials.Single(x => x.ID == TutorialID);
                if (oTutorial != null)
                {
                    oTutorial.IsDeleted = true;
                    db.SaveChanges();
                }
                return GetTutorials(LanguageID);
            }
        }
        #endregion

        #region Method :: ChangeStatus
        public List<TutorialsModel> ChangeStatus(int TutorialID, int LanguageID)
        {
            using (MWCoreEntity db = new MWCoreEntity())
            {
                MW_Tutorials oTutorial = db.MW_Tutorials.Single(x => x.ID == TutorialID);
                if (oTutorial != null)
                {
                    oTutorial.Status = oTutorial.Status == true ? false : true;
                    db.SaveChanges();
                }
                return GetTutorials(LanguageID);
            }
        }
        #endregion
    }
}