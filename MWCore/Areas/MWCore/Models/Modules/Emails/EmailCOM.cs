using MWCore.Areas.MWCore.Models.Common;
using MWCore.Areas.MWCore.Models.DBClasses;
using MWCore.Areas.MWCore.Models.DBClasses.Settings;
using RazorEngine.Templating;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace MWCore.Areas.MWCore.Models.Modules.Emails
{
    public class EmailCOM
    {
        public void SendEmail(string MailTo, string MailSubject, string MailBody, bool IsHTML = true)
        {
            using (MWCoreEntity db = new MWCoreEntity())
            {
                MW_EmailSettings oEmailSettings = db.MW_EmailSettings.FirstOrDefault();
                if (oEmailSettings != null)
                {
                    string sSmtpServer = oEmailSettings.OutgoingServer;
                    int nSMTPPort = Convert.ToInt32(oEmailSettings.PortID);
                    string sEmailFrom = oEmailSettings.SenderEmail;
                    string sEmailFromPassword = oEmailSettings.SenderPassword;
                    bool bEnableSSL = Convert.ToBoolean(oEmailSettings.EnableSSL);
                    MawaqaaCodeLibrary.Common.SendEmail(sSmtpServer, nSMTPPort, sEmailFrom, sEmailFromPassword, MailTo, MailSubject, MailBody, IsHTML, bEnableSSL);
                }

            }
        }

        public void SendEmail(List<string> MailTo, string MailSubject, string MailBody, bool IsHTML = true)
        {
            using (MWCoreEntity db = new MWCoreEntity())
            {
                MW_EmailSettings oEmailSettings = db.MW_EmailSettings.FirstOrDefault();
                if (oEmailSettings != null)
                {
                    string sSmtpServer = oEmailSettings.OutgoingServer;
                    int nSMTPPort = Convert.ToInt32(oEmailSettings.PortID);
                    string sEmailFrom = oEmailSettings.SenderEmail;
                    string sEmailFromPassword = oEmailSettings.SenderPassword;
                    bool bEnableSSL = Convert.ToBoolean(oEmailSettings.EnableSSL);
                    foreach (var item in MailTo)
                    {
                        MawaqaaCodeLibrary.Common.SendEmail(sSmtpServer, nSMTPPort, sEmailFrom, sEmailFromPassword, item, MailSubject, MailBody, IsHTML, bEnableSSL);
                    }
                }

            }
        }
        public string GetEmailTo()
        {
            using (MWCoreEntity db = new MWCoreEntity())
            {
                return db.MW_EmailSettings.FirstOrDefault().EmailTo;
            }
        }
        public static ContactUsModel ContactUsAPI(ContactUsModel oModel)
        {
            EmailCOM oEmailCOM = new EmailCOM();
            oEmailCOM.SendEmail(oEmailCOM.GetEmailTo(), "Contact Us Form", EmailCOM.GetContactUsMailBody(oModel), true);
            return oModel;
        }

        public static string GetContactUsMailBody(ContactUsModel oModel)
        {
            string sDefaultWebsiteURL = System.Configuration.ConfigurationManager.AppSettings["DefaultWebsiteURL"].ToString();
            StringBuilder sbBody = new StringBuilder();
            sbBody.Append("Dear, </br>");
            sbBody.Append("<table>");
            sbBody.Append("<tr><td>Name</td><td> : </td><td>" + oModel.Name + "</td>");
            sbBody.Append("<tr><td>Email</td><td> : </td><td>" + oModel.Email + "</td>");
            //sbBody.Append("<tr><td>Phone</td><td> : </td><td>" + oModel.PhoneNumber + "</td>");
            //sbBody.Append("<tr><td>Subject</td><td> : </td><td>" + oModel.Subject + "</td>");
            sbBody.Append("<tr><td>Message</td><td> : </td><td>" + oModel.Message + "</td>");
            sbBody.Append("</table>");
            return sbBody.ToString();
        }
        public string RenderEmailTemplate(string sEmailTimplateName, EmailTemplateCollections oEmailTemplateCollections)
        {
            string sEmailsTemplatesPath = System.Configuration.ConfigurationManager.AppSettings["EmailsTemplatesPath"].ToString();
            var templateFolderPath = Path.Combine(sEmailsTemplatesPath);
            string templateFilePath = templateFolderPath + @"\" + sEmailTimplateName;
            var templateService = new TemplateService();
            var emailHtmlBody = templateService.Parse(System.IO.File.ReadAllText(templateFilePath), oEmailTemplateCollections, null, null);
            return emailHtmlBody;
        }
    }
}