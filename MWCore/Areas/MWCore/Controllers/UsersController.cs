using MWCore.Areas.MWCore.Models;
using MWCore.Areas.MWCore.Models.BaseController;
using MWCore.Areas.MWCore.Models.DBClasses;
using MWCore.Areas.MWCore.Models.DBClasses.Users;
using MWCore.Areas.MWCore.Models.Modules.Users;
using System;
using System.IO;
using System.Linq;
using System.Web.Mvc;


namespace MWCore.Areas.MWCore.Controllers
{
    public class UsersController : MWCoreController
    {
        // GET: MWCore/Users
        #region ActionResult :: Index
        public ActionResult Index()
        {
            MWCoreModel oModel = new MWCoreModel();
            UsersCOM oUsersCOM = new UsersCOM();
            oModel.lstUsers = oUsersCOM.GetUsers();
            return View(oModel);
        }
        #endregion

        #region ActionResult :: AddEditUsers
        public ActionResult AddEditUsers(int? UserID)
        {

            MWCoreModel oModel = new MWCoreModel();
            UsersCOM oUsersCOM = new UsersCOM();
            oModel.lstGroupPoliciesList = oUsersCOM.GetGroupPoliciesList();
            if (UserID != null && UserID > 0)
            {

                oModel.oUser = oUsersCOM.GetUserDetails((int)UserID);
            }
            else
            {

                oModel.oUser = new Models.DBClasses.Users.MW_Users();

            }
            return PartialView("_AddEditUsers", oModel);
        }
        #endregion

        #region ActionResult :: SaveUser
        public ActionResult SaveUser(MWCoreModel oModel)
        {
            UsersCOM oUsersCOM = new UsersCOM();
            oModel.lstUsers = oUsersCOM.SaveUser(oModel);

            if (Session["UserInfo"] != null)
            {
                int userId = ((MW_Users)Session["UserInfo"]).ID;
                if (oModel.oUser != null)
                {
                    if (oModel.oUser.ID == userId)
                    {
                        var ouser = oUsersCOM.GetUserDetails(userId);

                        oModel.oUserInfo.UserImage = ouser.UserImage;
                        oModel.oUserInfo.FullName = ouser.FullName;
                    }
                }
            }

            return PartialView("_Users", oModel);
        }
        #endregion

        #region ActionResult :: DeleteUser
        public ActionResult DeleteUser(int UserID)
        {
            MWCoreModel oModel = new MWCoreModel();
            UsersCOM oUsersCOM = new UsersCOM();
            oModel.lstUsers = oUsersCOM.DeleteUser(UserID);
            return View("_Users", oModel);
        }
        #endregion

        #region ActionResult :: ChangeStatus
        public ActionResult ChangeStatus(int UserID)
        {
            MWCoreModel oModel = new MWCoreModel();
            UsersCOM oUsersCOM = new UsersCOM();
            oModel.lstUsers = oUsersCOM.ChangeStatus(UserID);
            return View("_Users", oModel);
        }
        #endregion

        #region ActionResult :: My Profile
        public ActionResult MyProfile()
        {
            MWCoreModel oModel = new MWCoreModel();
            UsersCOM oUsersCOM = new UsersCOM();

            if (Session["UserInfo"] != null)
            {
                int userId = ((MW_Users)Session["UserInfo"]).ID;
                oModel.oUser = oUsersCOM.GetUserDetails(userId);
            }
            return View(oModel);
        }
        #endregion

        #region ActionResult :: Update Profile
        public ActionResult UpdateProfile(MWCoreModel oModel)
        {
            UsersCOM oUsersCOM = new UsersCOM();

            oModel.oUser = oUsersCOM.UpdateUserProfile(oModel);

            if (Session["UserInfo"] != null)
            {
                int userId = ((MW_Users)Session["UserInfo"]).ID;
                if (oModel.oUser != null)
                {
                    if (oModel.oUser.ID == userId)
                    {
                        var ouser = oUsersCOM.GetUserDetails(userId);

                        oModel.oUserInfo.UserImage = ouser.UserImage;
                        oModel.oUserInfo.FullName = ouser.FullName;
                    }
                }
            }
            return RedirectToAction("MyProfile");

        }
        #endregion

        #region JsonResult :: UploadFeedImage (Post)
        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult UploadUserImage()
        {
            string sFileName = string.Empty;
            if (System.Web.HttpContext.Current.Request.Files.AllKeys.Any())
            {
                var pic = System.Web.HttpContext.Current.Request.Files["MyImages"];
                if (pic.ContentLength > 0)
                {
                    string sFileExtenction = Path.GetExtension(pic.FileName);

                    System.IO.FileInfo oFileInfo = new FileInfo(pic.FileName);
                    sFileName = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + oFileInfo.Extension;
                    var path = Path.Combine(Server.MapPath("~/assets/images/Uploads/"));
                    string sPath = System.IO.Path.Combine(path.ToString());
                    if (!System.IO.Directory.Exists(sPath))
                    {
                        System.IO.Directory.CreateDirectory(sPath);
                    }
                    var sUploadPath = string.Format("{0}\\{1}", sPath, sFileName);
                    pic.SaveAs(sUploadPath);

                }
            }
            return Json(Convert.ToString(sFileName), JsonRequestBehavior.AllowGet);
        }
        #endregion
        [HttpPost]
        public JsonResult UsernameExists(MW_Users oUser)
        {
            UsersCOM oUsersCOM = new UsersCOM();
            return Json(oUsersCOM.CheckUsername(oUser));
        }
        [HttpPost]
        public JsonResult EmailExists(MW_Users oUser)
        {
            UsersCOM oUsersCOM = new UsersCOM();
            return Json(oUsersCOM.CheckEmail(oUser));
        }

        [HttpPost]
        public JsonResult UserAlreadyExistsAsync(MW_Users oUser)
        {
            UsersCOM oUsersCOM = new UsersCOM();
            var result = oUsersCOM.CheckUsername(oUser);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult EmailAlreadyExistsAsync(MW_Users oUser)
        {
            UsersCOM oUsersCOM = new UsersCOM();
            var result = oUsersCOM.CheckEmail(oUser);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}