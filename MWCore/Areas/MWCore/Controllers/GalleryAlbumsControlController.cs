using MWCore.Areas.MWCore.Models;
using MWCore.Areas.MWCore.Models.BaseController;
using MWCore.Areas.MWCore.Models.Modules.GalleryAlbums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MWCore.Areas.MWCore.Controllers
{
    public class GalleryAlbumsControlController : MWCoreController
    {
        // GET: MWCore/GalleryAlbumsControl
        public ActionResult Index()
        {
            MWCoreModel oModel = new MWCoreModel();
            GalleryAlbumsCOM oGalleryAlbumsCOM = new GalleryAlbumsCOM();
            oModel.oGalleryAlbum = new GalleryAlbumsModel()
            {
                LanguageID = oModel.oSystemLanguage.ID
            };
            oModel.lstGalleryAlbums = oGalleryAlbumsCOM.GetGalleryAlbums(oModel.oSystemLanguage.ID);
            return View(oModel);
        }

        public ActionResult AddEditGalleryAlbums(int? GalleryAlbumsID)
        {
            MWCoreModel oModel = new MWCoreModel();
            if (GalleryAlbumsID != null && GalleryAlbumsID > 0)
            {
                GalleryAlbumsCOM oGalleryAlbumsCOM = new GalleryAlbumsCOM();
                oModel.oGalleryAlbum = oGalleryAlbumsCOM.GetGalleryAlbumsDetails((int)GalleryAlbumsID, oModel.oSystemLanguage.ID);
            }
            else
            {

                oModel.oGalleryAlbum = new GalleryAlbumsModel()
                {
                    LanguageID = oModel.oSystemLanguage.ID,
                };
            }
            return PartialView("_AddEditGalleryAlbums", oModel);
        }

        public ActionResult SaveGalleryAlbums(MWCoreModel oModel)
        {
            GalleryAlbumsCOM oGalleryAlbumsCOM = new GalleryAlbumsCOM();
            oModel.lstGalleryAlbums = oGalleryAlbumsCOM.SaveGalleryAlbums(oModel.oGalleryAlbum, oModel.lstSystemLanguages);
            return PartialView("_GalleryAlbums", oModel);
        }
        public ActionResult ChangeStatus(int GalleryAlbumsID)
        {
            MWCoreModel oModel = new MWCoreModel();
            GalleryAlbumsCOM oGalleryAlbumsCOM = new GalleryAlbumsCOM();
            oModel.lstGalleryAlbums = oGalleryAlbumsCOM.ChangeStatus(GalleryAlbumsID, oModel.oSystemLanguage.ID);
            oModel.oGalleryAlbum = new GalleryAlbumsModel()
            {
                LanguageID = oModel.oSystemLanguage.ID
            };
            return PartialView("_GalleryAlbums", oModel);
        }

        public ActionResult DeleteGalleryAlbums(int GalleryAlbumsID)
        {
            MWCoreModel oModel = new MWCoreModel();
            GalleryAlbumsCOM oGalleryAlbumsCOM = new GalleryAlbumsCOM();
            oModel.lstGalleryAlbums = oGalleryAlbumsCOM.DeleteRecord(GalleryAlbumsID, oModel.oSystemLanguage.ID);
            oModel.oGalleryAlbum = new GalleryAlbumsModel()
            {
                LanguageID = oModel.oSystemLanguage.ID
            };
            return PartialView("_GalleryAlbums", oModel);
        }

        public ActionResult Gallery(int GalleryAlbumID = 0)
        {
            MWCoreModel oModel = new MWCoreModel();
            GalleryAlbumsCOM oGalleryAlbumsCOM = new GalleryAlbumsCOM();
            oModel.oGallery = new GalleryModel()
            {
                GalleryAlbumID = GalleryAlbumID
            };
            oModel.lstGalleries = oGalleryAlbumsCOM.GetImages(GalleryAlbumID);
            return View(oModel);
        }
        public ActionResult AddEditGalleryImage(int? GalleryID, int GalleryAlbumID)
        {
            MWCoreModel oModel = new MWCoreModel();
            if (GalleryID != null && GalleryID > 0)
            {
                GalleryAlbumsCOM oGalleryAlbumsCOM = new GalleryAlbumsCOM();
                oModel.oGallery = oGalleryAlbumsCOM.GetImage((int)GalleryID);
            }
            else
            {

                oModel.oGallery = new GalleryModel()
                {
                    GalleryAlbumID = GalleryAlbumID
                };
            }
            return PartialView("_AddEditGalleryImage", oModel);
        }
        public ActionResult SaveGalleryImage(MWCoreModel oModel)
        {
            GalleryAlbumsCOM oGalleryAlbumsCOM = new GalleryAlbumsCOM();
            System.IO.FileInfo oFile = new System.IO.FileInfo("~/assets/images/uploads/" + oModel.oGallery.FileName);

            if (oFile.Extension.ToLower() == ".jpg" || oFile.Extension.ToLower() == ".jpeg" || oFile.Extension.ToLower() == ".png" || oFile.Extension.ToLower() == ".gif")
            {
                oModel.oGallery.FileType = 1;
            }
            else
            {
                oModel.oGallery.FileType = 2;
            }
            oModel.lstGalleries = oGalleryAlbumsCOM.SaveImage(oModel.oGallery);
            return PartialView("_Gallery", oModel);
        }

        public ActionResult ChangeStatusImage(int GalleryID, int GalleryAlbumID)
        {
            MWCoreModel oModel = new MWCoreModel();
            GalleryAlbumsCOM oGalleryAlbumsCOM = new GalleryAlbumsCOM();
            oModel.lstGalleries = oGalleryAlbumsCOM.ChangeImageStatus(GalleryID, GalleryAlbumID);
            oModel.oGallery = new GalleryModel()
            {
                GalleryAlbumID = GalleryAlbumID
            };
            return PartialView("_Gallery", oModel);
        }

        public ActionResult DeleteGalleryImage(int GalleryID, int GalleryAlbumID)
        {
            MWCoreModel oModel = new MWCoreModel();
            GalleryAlbumsCOM oGalleryAlbumsCOM = new GalleryAlbumsCOM();
            oModel.lstGalleries = oGalleryAlbumsCOM.DeleteImage(GalleryID, GalleryAlbumID);
            oModel.oGallery = new GalleryModel()
            {
                GalleryAlbumID = GalleryAlbumID
            };
            return PartialView("_Gallery", oModel);
        }
    }
}