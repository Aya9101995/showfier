using MWCore.Areas.MWCore.Models;
using MWCore.Areas.MWCore.Models.BaseController;
using MWCore.Areas.MWCore.Models.Modules.Banners;
using System.Collections.Generic;
using System.Web.Mvc;

namespace MWCore.Areas.MWCore.Controllers
{
    public class BannersControlController : MWCoreController
    {
        // GET: MWCore/BannersControl
        #region ActionResult :: Index
        public ActionResult Index()
        {
            MWCoreModel oModel = new MWCoreModel();
            BannersCOM oBannerCOM = new BannersCOM();
            oModel.lstBanners = oBannerCOM.GetBanners();
            return View(oModel);
        }
        #endregion

        [HttpPost]
        public ActionResult Index(MWCoreModel oModel)
        {
            BannersCOM oBannerCOM = new BannersCOM();
            oModel.lstBanners = oBannerCOM.GetBanners();
            return PartialView("_Banners", oModel);
        }

        #region ActionResult :: AddEditBanner
        public ActionResult AddEditBanner(int? BannerID)
        {
            MWCoreModel oModel = new MWCoreModel();
            if (BannerID != null && BannerID > 0)
            {
                BannersCOM oBannerCOM = new BannersCOM();
                oModel.oBanner = oBannerCOM.GetBannerDetails((int)BannerID);
            }
            else
            {

                oModel.oBanner = new BannersModel();
            }
            return PartialView("_AddEditBanner", oModel);
        }
        #endregion

        #region ActionResult :: SaveBanner
        public ActionResult SaveBanner(MWCoreModel oModel)
        {
            BannersCOM oBannerCOM = new BannersCOM();
            oModel.lstBanners = oBannerCOM.SaveBanner(oModel.oBanner);
            return PartialView("_Banners", oModel);
        }
        #endregion

        #region ActionResult :: DeleteBanner
        public ActionResult DeleteBanner(int BannerID)
        {
            MWCoreModel oModel = new MWCoreModel();
            BannersCOM oBannerCOM = new BannersCOM();
            oModel.lstBanners = oBannerCOM.DeleteBanner(BannerID);
            return PartialView("_Banners", oModel);
        }
        #endregion

        #region ActionResult :: ChangeStatus
        public ActionResult ChangeStatus(int BannerID)
        {
            MWCoreModel oModel = new MWCoreModel();
            BannersCOM oBannerCOM = new BannersCOM();
            oModel.lstBanners = oBannerCOM.ChangeStatus(BannerID);
            return PartialView("_Banners", oModel);
        }
        #endregion
    }
}