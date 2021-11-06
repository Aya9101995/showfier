using MWCore.Areas.MWCore.Models.DBClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MWCore.Areas.MWCore.Models.Modules.StatusManager
{
    public class StatusManagerCOM
    {
        public List<SelectListItem> GetStatusList(int StatusForID, int LanguageID)
        {
            using (MWCoreEntity db = new MWCoreEntity())
            {
                return (from statusmanager in db.MW_StatusManager
                        join statusmanager_loc in db.MW_StatusManager_Loc on statusmanager.ID equals statusmanager_loc.StatusManagerID
                        where statusmanager.StatusForID == StatusForID && statusmanager_loc.LanguageID == LanguageID
                        select new SelectListItem()
                        {
                            Text = statusmanager_loc.StatusTitle,
                            Value = statusmanager.StatusNumber.ToString()
                        }).ToList();
            }
        }
    }
}