/*****************************************************************************/
/* File Name     : EmailSettingsControlController.cs                        */
/* Created By    : Abdulla Hawwash                                         */
/* Creation Date : 19/12/2017                                             */
/* Comment       : Email Settings Controller                             */
/************************************************************************/

using MWCore.Areas.MWCore.Models;
using MWCore.Areas.MWCore.Models.BaseController;
using MWCore.Areas.MWCore.Models.Modules.EmailSettings;
using System.Web.Mvc;

namespace MWCore.Areas.MWCore.Controllers
{
    public class EmailSettingsControlController : MWCoreController
    {
        // GET: MWCore/EmailSettingsControl
        #region ActionResult :: Index
        public ActionResult Index()
        {
            MWCoreModel oModel = new MWCoreModel();
            EmailSettingsCOM oEmailSettings = new EmailSettingsCOM();
            oModel.oEmailSettings = oEmailSettings.GetEmailSettings();
            return View(oModel);
        }
        #endregion

        #region ActionResult :: SaveEmailSettings
        public ActionResult SaveEmailSettings(MWCoreModel oModel)
        {
            EmailSettingsCOM oEmailSettings = new EmailSettingsCOM();
            oModel.oEmailSettings = oEmailSettings.SaveSettings(oModel);
            if (oModel.oEmailSettings.ID > 0)
            {
                ViewBag.Result = "Saved Successfully.";
            }
            else
            {
                ViewBag.Result = "Error, Data Not Saved.";
            }
            return PartialView("_EmailSettings", oModel);
        } 
        #endregion
    }
}