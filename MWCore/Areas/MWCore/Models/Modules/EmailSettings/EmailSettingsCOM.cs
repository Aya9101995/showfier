/*****************************************************************************/
/* File Name     : EmailSettingsCOM.cs                                      */
/* Created By    : Abdulla Hawwash                                         */
/* Creation Date : 19/12/2017                                             */
/* Comment       : Email Settings                                        */
/************************************************************************/

using MWCore.Areas.MWCore.Models.DBClasses;
using MWCore.Areas.MWCore.Models.DBClasses.Settings;
using System.Linq;

namespace MWCore.Areas.MWCore.Models.Modules.EmailSettings
{
    public class EmailSettingsCOM
    {
        #region Method :: GetEmailSettings
        public MW_EmailSettings GetEmailSettings()
        {
            using (MWCoreEntity db = new MWCoreEntity())
            {
                return db.MW_EmailSettings.FirstOrDefault();
            }
        }
        #endregion

        #region Method :: SaveSettings
        public MW_EmailSettings SaveSettings(MWCoreModel oModel)
        {
            using (MWCoreEntity db = new MWCoreEntity())
            {
                MW_EmailSettings oEmailSettings = new MW_EmailSettings();
                if (oModel.oEmailSettings.ID > 0)
                {
                    oEmailSettings = db.MW_EmailSettings.FirstOrDefault();
                }
                oEmailSettings.EmailTo = oModel.oEmailSettings.EmailTo;
                oEmailSettings.OutgoingServer = oModel.oEmailSettings.OutgoingServer;
                oEmailSettings.EnableSSL = oModel.oEmailSettings.EnableSSL;
                oEmailSettings.PortID = oModel.oEmailSettings.PortID;
                oEmailSettings.SenderEmail = oModel.oEmailSettings.SenderEmail;
                oEmailSettings.SenderPassword = oModel.oEmailSettings.SenderPassword;
                if (oModel.oEmailSettings.ID <= 0)
                {
                    db.MW_EmailSettings.Add(oEmailSettings);
                }
                db.SaveChanges();
                return db.MW_EmailSettings.FirstOrDefault();
            }
        } 
        #endregion
    }
}