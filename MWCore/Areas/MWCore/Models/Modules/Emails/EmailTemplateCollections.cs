using MWCore.Areas.MWCore.Models.DBClasses;
using MWCore.Areas.MWCore.Models.Modules.Emails.EmailsTemplates;
using MWCore.Areas.MWCore.Models.Modules.SystemSettings;

namespace MWCore.Areas.MWCore.Models.Modules.Emails
{
    public class EmailTemplateCollections
    {
        public string WebsiteURL { get; set; }
        public ResetPasswordEmailTemplate oResetPasswordEmailTemplate { get; set; }
        public WelcomeEmail oWelcomeEmail { get; set; }
        public OrderStatusModel oOrderStatus { get; set; }
        public EmailTemplateCollections()
        {
            using(MWCoreEntity db = new MWCoreEntity())
            {
                SystemSettingsModel oSystemSettings = SystemSettingsCOM.GetSystemSettingsDetails();
                if(oSystemSettings != null)
                {
                    WebsiteURL = oSystemSettings.DefaultWebsiteURL;
                }
            }
        }
    }
}