/*****************************************************************************/
/* File Name     : SystemSettingsCOM.cs                                     */
/* Created By    : Abdulla Hawwash                                         */
/* Creation Date : 19/12/2017                                             */
/* Comment       : System Settings                                       */
/************************************************************************/

using MWCore.Areas.MWCore.Models.DBClasses;
using MWCore.Areas.MWCore.Models.DBClasses.Settings;
using System;
using System.Linq;

namespace MWCore.Areas.MWCore.Models.Modules.SystemSettings
{
    public class SystemSettingsCOM
    {
        #region Method :: GetSystemSettings
        public SystemSettingsModel GetSystemSettings()
        {
            using (MWCoreEntity db = new MWCoreEntity())
            {
                MW_SystemSettings oSystemSettings = db.MW_SystemSettings.FirstOrDefault();
                SystemSettingsModel oSystemSettingsModel = new SystemSettingsModel();
                if (oSystemSettings != null)
                {
                    
                }
                oSystemSettingsModel.DefaultWebsiteURL = System.Configuration.ConfigurationManager.AppSettings["DefaultWebsiteURL"].ToString();
                return oSystemSettingsModel;
            }
        }
        #endregion

        #region Method :: SaveSystemSettings
        public SystemSettingsModel SaveSystemSettings(MWCoreModel oModel)
        {
            using (MWCoreEntity db = new MWCoreEntity())
            {
                MW_SystemSettings oSystemSettings = db.MW_SystemSettings.FirstOrDefault();
                if (oSystemSettings == null)
                {
                    oSystemSettings = new MW_SystemSettings();
                }
                if (oSystemSettings.ID <= 0)
                {
                    db.MW_SystemSettings.Add(oSystemSettings);
                }
                db.SaveChanges();
                return GetSystemSettings();
            }
        }
        #endregion



        public static SystemSettingsModel GetSystemSettingsDetails()
        {
            using (MWCoreEntity db = new MWCoreEntity())
            {
                MW_SystemSettings oSystemSettings = db.MW_SystemSettings.FirstOrDefault();
                SystemSettingsModel oSystemSettingsModel = new SystemSettingsModel();
                if (oSystemSettings != null)
                {

                }
                oSystemSettingsModel.DefaultWebsiteURL = System.Configuration.ConfigurationManager.AppSettings["DefaultWebsiteURL"].ToString();
                return oSystemSettingsModel;
            }
        }
    }
}