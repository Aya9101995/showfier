using MWCore.Areas.MWCore.Models.DBClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MWCore.Areas.MWCore.Models.Modules.SystemLanguages
{
    public class SystemLanguagesCOM
    {
        public static List<SystemLanguagesModel> GetSystemLanguages()
        {
            using (MWCoreEntity db = new MWCoreEntity())
            {
                return (from language in db.MW_SystemLanguages
                        select new SystemLanguagesModel()
                        {
                            LanguageID = language.ID,
                            LanguageName = language.LanguageName,
                            LanguageCode = language.LanguageCode
                        }).ToList();
            }
        }

        public SystemLanguagesModel GetSystemLanguageDetails(int LanguageID)
        {
            using (MWCoreEntity db = new MWCoreEntity())
            {
                return (from language in db.MW_SystemLanguages
                        where language.ID == LanguageID
                        select new SystemLanguagesModel()
                        {
                            LanguageID = language.ID,
                            LanguageName = language.LanguageName,
                            LanguageCode = language.LanguageCode
                        }).FirstOrDefault();
            }
        }
    }
}