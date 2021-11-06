using MWCore.Areas.MWCore.Models.DBClasses;
using MWCore.Areas.MWCore.Models.DBClasses.NewsLetters;
using MWCore.Areas.MWCore.Models.Modules.Emails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MWCore.Areas.MWCore.Models.Modules.NewsLettersSubscriptions
{
    public class NewsLettersSubscriptionsCOM
    {
        public NewsLettersSubscriptionsModel Subscrip(NewsLettersSubscriptionsModel oModel)
        {
            using(MWCoreEntity db = new MWCoreEntity())
            {
                MW_NewsLettersSubscriptions oNewsLetterSubscription = db.MW_NewsLettersSubscriptions.FirstOrDefault(x => x.Email == oModel.Email);
                if(oNewsLetterSubscription==null)
                {
                    oNewsLetterSubscription = new MW_NewsLettersSubscriptions();
                    oNewsLetterSubscription.Email = oModel.Email;
                    oNewsLetterSubscription.CreatedDate = DateTime.Now;
                    db.MW_NewsLettersSubscriptions.Add(oNewsLetterSubscription);
                    db.SaveChanges();
                }
                oModel.SubscriptionID = oNewsLetterSubscription.ID;
                return oModel;
            }
        }

        public static void SendEmailForSubscribers(NewsLettersModel oModel)
        {
            using(MWCoreEntity db = new MWCoreEntity())
            {
                List<string> lstEmails = db.MW_NewsLettersSubscriptions.Select(x => x.Email).ToList();
                EmailCOM oEmailCOM = new EmailCOM();
                foreach (var item in lstEmails)
                {
                    oEmailCOM.SendEmail(item, oModel.Subject, oModel.Body, true);
                }
            }
        }
    }
}