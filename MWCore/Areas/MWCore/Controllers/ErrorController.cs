/*****************************************************************************/
/* File Name     : ErrorController.cs                                       */
/* Created By    : Abdulla Hawwash                                         */
/* Creation Date : 19/12/2017                                             */
/* Comment       : Error Controller                                      */
/************************************************************************/

using MWCore.Areas.MWCore.Models;
using MWCore.Areas.MWCore.Models.BaseController;
using System.Web.Mvc;

namespace MWCore.Areas.MWCore.Controllers
{
    public class ErrorController : MWCoreController
    {
        // GET: MWCore/Error
        #region ActionResult :: Index
        public ActionResult Index(int id = -99)
        {
            if (id != -99)
            {
                SendError(id);
            }
            MWCoreModel oModel = new MWCoreModel();
            return View(oModel);
        }
        #endregion

        #region Method :: SendError
        private void SendError(int ErrorID)
        {

        } 
        #endregion
    }
}