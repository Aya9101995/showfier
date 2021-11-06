/*****************************************************************************/
/* File Name     : SocialMediaControlController.cs                          */
/* Created By    : Abdulla Hawwash                                         */
/* Creation Date : 19/12/2017                                             */
/* Comment       : Social Media Controller                               */
/************************************************************************/

using MWCore.Areas.MWCore.Models;
using MWCore.Areas.MWCore.Models.BaseController;
using MWCore.Areas.MWCore.Models.DBClasses;
using MWCore.Areas.MWCore.Models.DBClasses.SocialMedia;
using MWCore.Areas.MWCore.Models.Modules.SocialMedia;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MWCore.Areas.MWCore.Controllers
{
    public class SocialMediaControlController : MWCoreController
    {
        // GET: MWCore/SocialMediaControl
        #region ActionResult :: Index
        public ActionResult Index()
        {
            MWCoreModel oModel = new MWCoreModel();
            SocialMediaCOM oSocialMedia = new SocialMediaCOM();
            oModel.lstSocialMedia = oSocialMedia.GetSocialMedia();
            return View(oModel);
        }
        #endregion

        #region ActionResult :: AddEditSocialMedia
        public ActionResult AddEditSocialMedia(int? SocialMediaID)
        {
            MWCoreModel oModel = new MWCoreModel();
            if (SocialMediaID != null && SocialMediaID > 0)
            {
                SocialMediaCOM oSocialMedia = new SocialMediaCOM();
                oModel.oSocialMedia = oSocialMedia.GetSocialMediaDetails((int)SocialMediaID);
            }
            else
            {
                oModel.oSocialMedia = new MW_SocialMedia();
            }
            return PartialView("_AddEditSocialMedia", oModel);
        }
        #endregion

        #region ActionResult :: SaveSocialMedia
        public ActionResult SaveSocialMedia(MWCoreModel oModel)
        {
            SocialMediaCOM oSocialMedia = new SocialMediaCOM();
            oModel.lstSocialMedia = oSocialMedia.SaveSocialMedia(oModel);
            return PartialView("_SocialMedia", oModel);
        }
        #endregion

        #region ActionResult :: DeleteSocialMedia
        public ActionResult DeleteSocialMedia(int SocialMediaID)
        {
            MWCoreModel oModel = new MWCoreModel();
            SocialMediaCOM oSocialMedia = new SocialMediaCOM();
            oModel.lstSocialMedia = oSocialMedia.DeleteSocialMedia(SocialMediaID);
            return PartialView("_SocialMedia", oModel);
        }
        #endregion

        #region ActionResult :: ChangeStatus
        public ActionResult ChangeStatus(int SocialMediaID)
        {
            MWCoreModel oModel = new MWCoreModel();
            SocialMediaCOM oSocialMedia = new SocialMediaCOM();
            oModel.lstSocialMedia = oSocialMedia.ChangeStatus(SocialMediaID);
            return PartialView("_SocialMedia", oModel);
        }
        #endregion
    }
}