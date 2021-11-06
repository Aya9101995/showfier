
using MawaqaaCodeLibrary;
using MWCore.Models.Attributes;
using System;
using System.Web.Mvc;

namespace MWCore.Models.BaseController
{
    [InternationalizationAttribute]
    public class MWCoreFrontEndController : Controller
    {
        #region Method :: oUserInfo
        
        #endregion
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string sPageName = this.ControllerContext.RouteData.Values["controller"].ToString();
            string sActionName = this.ControllerContext.RouteData.Values["action"].ToString();
            base.OnActionExecuting(filterContext);
        }
        #region Method :: OnAuthorization
        protected override void OnAuthorization(AuthorizationContext filterContext)
        {

            string sPageName = this.ControllerContext.RouteData.Values["controller"].ToString();
            string sActionName = this.ControllerContext.RouteData.Values["action"].ToString();
            if (sPageName.ToLower() == "myaccount")
            {
                if (Session["CustomerUserInfo"] != null)
                {
                    //oUserInfo = (CustomersModel)Session["CustomerUserInfo"];
                    //if (oUserInfo.CustomerID <= 0)
                    //{
                    //    Response.Redirect(Url.Action("Login", "Account", new { @url = Request.Url.AbsoluteUri }));
                    //}

                }
                else
                {
                    //Session["CustomerUserInfo"] = new CustomersModel();
                    Response.Redirect(Url.Action("Login", "Account", new { @url = Request.Url.AbsoluteUri }));

                }
            }

            base.OnAuthorization(filterContext);
        }
        #endregion

        #region Method :: OnException
        protected override void OnException(ExceptionContext filterContext)
        {
            int nErrorID = -65000;
            string sUserID, sUserTypeID;
            if (Session["CustomerUserInfo"] != null)
            {
                //CustomersModel oUser = (CustomersModel)Session["CustomerUserInfo"];
                //if (oUser == null)
                //{
                //    oUser = new CustomersModel();
                //}
                sUserID = "";
                sUserTypeID = "";
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
                    nErrorID = ErrorLog.InsertToLog(Server.MapPath(sErrorLogPath)
                    , Request.Url.ToString(), oError.Message, oError.StackTrace, sUserID, sUserTypeID);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            Response.Redirect(Url.Action("Index", "PageNotFound"));
            base.OnException(filterContext);
        }
        #endregion
    }
}