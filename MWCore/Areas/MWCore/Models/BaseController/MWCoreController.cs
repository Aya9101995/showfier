/*****************************************************************************/
/* File Name     : MWCoreController.cs                                      */
/* Created By    : Abdulla Hawwash                                         */
/* Creation Date : 19/12/2017                                             */
/* Comment       : Base Controller For Admin Panel                       */
/************************************************************************/


using MawaqaaCodeLibrary;
using MWCore.Areas.MWCore.Models.DBClasses;
using MWCore.Areas.MWCore.Models.DBClasses.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MWCore.Areas.MWCore.Models.BaseController
{
    public class MWCoreController : Controller
    {
        #region Method :: oUserInfo
        public MW_Users oUserInfo
        {
            get { return (MW_Users)Session["UserInfo"]; }
            set { Session["UserInfo"] = value; }
        }
        #endregion

        #region Method :: OnAuthorization
        protected override void OnAuthorization(AuthorizationContext filterContext)
        {
            //List<string> lstAllowedIPs = System.Configuration.ConfigurationManager.AppSettings["AllowedIPs"].ToString().Split(',').ToList();
            string CurrentUserIPAddress = Request.UserHostAddress;
            //if ((lstAllowedIPs.Count() == 1 && lstAllowedIPs.FirstOrDefault() == "0") || lstAllowedIPs.Any(x => x == CurrentUserIPAddress))
            //{
            string sPageName = this.ControllerContext.RouteData.Values["controller"].ToString();
            string sActionName = this.ControllerContext.RouteData.Values["action"].ToString();
            //if (sPageName != "AccountControl" || (sPageName == "AccountControl" && sActionName == "ChangePassword") || (sPageName.ToLower() == "dashboardcontrol" && (sActionName.ToLower() != "publishpubnubmessage" || sActionName.ToLower() != "updatemapusingweb")))
            if (sActionName.ToLower() != "publishpubnubmessage" && sActionName.ToLower() != "updatemapusingweb")
            {
                if (Session["UserInfo"] != null)
                {
                    oUserInfo = (MW_Users)Session["UserInfo"];

                    if (sPageName.ToLower() != "error" && sPageName.ToLower() != "dashboardcontrol" && sActionName.ToLower() != "changepassword")
                    {
                        if (!CheckUserPermissions(oUserInfo.PolicyGroupID, sPageName))
                        {
                            Response.Redirect("~/MWCore/Error/Index?n=2");
                        }
                    }
                }
                else
                {
                    Response.Redirect("~/MWCore/AccountControl/Login?url=" + Request.Url.AbsoluteUri);

                }
            }
            //}
            //else
            //{
            //    filterContext.Result = new System.Web.Mvc.HttpStatusCodeResult(403);
            //}

            base.OnAuthorization(filterContext);
        }
        #endregion

        #region Method :: OnException
        protected override void OnException(ExceptionContext filterContext)
        {
            int nErrorID = -65000;
            string sUserID, sUserTypeID;
            if (Session["UserInfo"] != null)
            {
                MW_Users oUser = (MW_Users)Session["UserInfo"];
                sUserID = oUser.ID.ToString();
                sUserTypeID = oUser.Username.ToString();
            }
            else
            {
                sUserID = sUserTypeID = "";
            }
            try
            {
                Exception oError = filterContext.Exception;
                filterContext.ExceptionHandled = true;
                string sErrorLogPath = "~/ErrorLog/Log.xml";
                if (oError.Message != "Server cannot set content type after HTTP headers have been sent.")
                {
                    string sErrorMessage = oError.Message;
                    if (oError.InnerException != null)
                    {
                        sErrorMessage += ";Inner Exception:" + oError.InnerException.Message;
                        if (oError.InnerException.InnerException != null)
                        {
                            sErrorMessage += ";Inner Exception:" + oError.InnerException.InnerException.Message;
                        }
                    }
                    nErrorID = ErrorLog.InsertToLog(Server.MapPath(sErrorLogPath)
                    , Request.Url.ToString(), sErrorMessage, oError.StackTrace, sUserID, sUserTypeID);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            //Response.Redirect("~/MWCore/Error/Index?id=" + nErrorID.ToString());
            base.OnException(filterContext);
        }
        #endregion

        private bool CheckUserPermissions(int GroupID, string PageName)
        {
            return true;
            if (PageName == "APILogger")
            {
                return true;
            }
            using (MWCoreEntity db = new MWCoreEntity())
            {
                int nPageID = db.MW_GroupPlociesPages.Where(x => x.PageName == PageName).FirstOrDefault() != null ? db.MW_GroupPlociesPages.Where(x => x.PageName == PageName).FirstOrDefault().ID : -99;
                if (nPageID != -99)
                {
                    return db.MW_GroupPoliciesPermissions.Any(x => x.GroupID == GroupID && x.PageID == nPageID);
                }
                else
                {
                    return false;
                }
            }
        }
    }
}