/*****************************************************************************/
/* File Name     : AccountControlController.cs                              */
/* Created By    : Abdulla Hawwash                                         */
/* Creation Date : 19/12/2017                                             */
/* Comment       : Account Controller                                    */
/************************************************************************/

using MWCore.Areas.MWCore.Models;
using MWCore.Areas.MWCore.Models.DBClasses;
using MWCore.Areas.MWCore.Models.DBClasses.Users;
using MWCore.Areas.MWCore.Models.Modules.Account;
using System.Web.Mvc;

namespace MWCore.Areas.MWCore.Controllers
{
    public class AccountControlController : Controller
    {
        // GET: MWCore/Account
        #region ActionResult :: Index
        public ActionResult Index()
        {
            return RedirectToAction("Login");
        }
        #endregion

        #region ActionResult :: Login
        public ActionResult Login(string url = "")
        {
            MWCoreModel oModel = new MWCoreModel();
            oModel.RedirectToUrl = url;
            oModel.oUserInfo = new MW_Users();
            return View(oModel);
        } 
        #endregion

        #region ActionResult :: Login (Post)
        [HttpPost]
        public ActionResult Login(MWCoreModel oModel)
        {
            AccountCOM oAccount = new AccountCOM();
            MW_Users oUser = oAccount.Login(oModel.oUserInfo);
            if (oUser != null && oUser.ID > 0)
            {
                Session["UserInfo"] = oUser;
                if (oModel.RedirectToUrl != null && oModel.RedirectToUrl != "")
                {
                    return Redirect(oModel.RedirectToUrl);
                }
                return RedirectToAction("Index", "DashboardControl");
            }
            else
            {
                ViewBag.LoginErrorMessage = "Wrong Username Or Password";
                return View();
            }
        }
        #endregion

        #region Method :: Logout
        public void Logout()
        {
            Session["UserInfo"] = null;
            Session.Clear();
            Session.Abandon();
            Session.RemoveAll();
            System.Web.Security.FormsAuthentication.SignOut();
            Response.Redirect("~/MWCore/AccountControl");
        }
        #endregion

        #region ActionResult :: Change Password 
        public ActionResult ChangePassword()
        {
            AccountCOM oAccount = new AccountCOM();
            MWCoreModel oModel = new MWCoreModel();
            oModel.oChangePassword = new ChangePasswordClass();
            if (Session["UserInfo"] != null)
            {
                oModel.oChangePassword.UserID = ((MW_Users)Session["UserInfo"]).ID;
            }

            return View(oModel);

        }
        #endregion
        #region ActionResult :: Change Password (Post)
        [HttpPost]
        public ActionResult ChangePassword(MWCoreModel oModel)
        {
            AccountCOM oAccount = new AccountCOM();
            int retVal = oAccount.ChangePassword(oModel);
            if (retVal == -1)
            {
                ViewBag.ChangePasswordMessage = "Your old password is wrong";
                return View(oModel);
            }
            else
            {
                ViewBag.ChangePasswordMessage = "Your password has changed successfully";
                return View(oModel);
            }
        }
        #endregion
    }
}