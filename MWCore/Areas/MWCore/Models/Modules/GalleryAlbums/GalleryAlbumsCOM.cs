using MWCore.Areas.MWCore.Models.DBClasses;
using MWCore.Areas.MWCore.Models.DBClasses.Gallery;
using MWCore.Areas.MWCore.Models.Modules.SystemLanguages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MWCore.Areas.MWCore.Models.Modules.GalleryAlbums
{
    public class GalleryAlbumsCOM
    {
        public List<GalleryAlbumsModel> GetGalleryAlbums(int LanguageID, bool Status = false)
        {
            using (MWCoreEntity db = new MWCoreEntity())
            {
                return (from GalleryAlbums in db.MW_GalleryAlbums
                        join GalleryAlbums_Loc in db.MW_GalleryAlbums_Loc on GalleryAlbums.ID equals GalleryAlbums_Loc.GalleryAlbumID
                        join image in db.MW_Gallery on GalleryAlbums.ID equals image.GalleryAlbumID into Images
                        from image in Images.DefaultIfEmpty()
                        where GalleryAlbums_Loc.LanguageID == LanguageID && !GalleryAlbums.IsDeleted && (Status == true ? GalleryAlbums.Status == true : true)
                        && (image != null ? (Status == true ? image.Status == true : true) && !image.IsDeleted : true)
                        select new
                        {
                            Status = GalleryAlbums.Status,
                            LanguageID = GalleryAlbums_Loc.LanguageID,
                            GalleryAlbumID = GalleryAlbums.ID,
                            Desc = GalleryAlbums_Loc.Desc,
                            Title = GalleryAlbums_Loc.Title,
                            MainImage = GalleryAlbums.CoverIamge,
                            Image = image != null ? image.FileName : "",
                            FileType = image != null ? image.FileType : 0,
                            ImageStatus = image != null ? image.Status : false
                        }).AsEnumerable().GroupBy(x => x.GalleryAlbumID).Select(GalleryAlbums => new GalleryAlbumsModel()
                        {
                            Status = GalleryAlbums.FirstOrDefault().Status,
                            LanguageID = GalleryAlbums.FirstOrDefault().LanguageID,
                            GalleryAlbumID = GalleryAlbums.FirstOrDefault().GalleryAlbumID,
                            Desc = GalleryAlbums.FirstOrDefault().Desc,
                            Title = GalleryAlbums.FirstOrDefault().Title,
                            CoverIamge = GalleryAlbums.FirstOrDefault().MainImage,
                            lstGalleries = (from image in GalleryAlbums
                                            select new GalleryModel()
                                            {
                                                FileName = image.Image,
                                                FileType = image.FileType,
                                                Status = image.ImageStatus
                                            }).ToList()
                        }).ToList();
            }
        }

        public GalleryAlbumsModel GetGalleryAlbumsDetails(int GalleryAlbumID, int LanguageID, bool Status = false)
        {
            using (MWCoreEntity db = new MWCoreEntity())
            {
                return (from GalleryAlbums in db.MW_GalleryAlbums
                        join GalleryAlbums_Loc in db.MW_GalleryAlbums_Loc on GalleryAlbums.ID equals GalleryAlbums_Loc.GalleryAlbumID
                        join image in db.MW_Gallery on GalleryAlbums.ID equals image.GalleryAlbumID into Images
                        from image in Images.DefaultIfEmpty()
                        where GalleryAlbums_Loc.LanguageID == LanguageID && !GalleryAlbums.IsDeleted && GalleryAlbums.ID == GalleryAlbumID
                        && (image != null ? (Status == true ? image.Status == true : true) && !image.IsDeleted : true)
                        select new
                        {
                            Status = GalleryAlbums.Status,
                            LanguageID = GalleryAlbums_Loc.LanguageID,
                            GalleryAlbumID = GalleryAlbums.ID,
                            Desc = GalleryAlbums_Loc.Desc,
                            Title = GalleryAlbums_Loc.Title,
                            MainImage = GalleryAlbums.CoverIamge,
                            Image = image != null ? image.FileName : "",
                            FileType = image != null ? image.FileType : 0,
                            ImageStatus = image != null ? image.Status : false
                        }).AsEnumerable().GroupBy(x => x.GalleryAlbumID).Select(GalleryAlbums => new GalleryAlbumsModel()
                        {
                            Status = GalleryAlbums.FirstOrDefault().Status,
                            LanguageID = GalleryAlbums.FirstOrDefault().LanguageID,
                            GalleryAlbumID = GalleryAlbums.FirstOrDefault().GalleryAlbumID,
                            Desc = GalleryAlbums.FirstOrDefault().Desc,
                            Title = GalleryAlbums.FirstOrDefault().Title,
                            CoverIamge = GalleryAlbums.FirstOrDefault().MainImage,
                            lstGalleries = (from image in GalleryAlbums
                                            select new GalleryModel()
                                            {
                                                FileName = image.Image,
                                                FileType = image.FileType,
                                                Status = image.ImageStatus
                                            }).ToList()
                        }).FirstOrDefault();
            }
        }

        public List<GalleryAlbumsModel> SaveGalleryAlbums(GalleryAlbumsModel oModel, List<SystemLanguagesModel> lstSystemLanguages)
        {
            using (MWCoreEntity db = new MWCoreEntity())
            {
                MW_GalleryAlbums oGalleryAlbums = new MW_GalleryAlbums();
                MW_GalleryAlbums_Loc oGalleryAlbums_Loc = new MW_GalleryAlbums_Loc();
                if (oModel.GalleryAlbumID > 0)
                {
                    oGalleryAlbums = db.MW_GalleryAlbums.FirstOrDefault(x => x.ID == oModel.GalleryAlbumID);
                    oGalleryAlbums_Loc = db.MW_GalleryAlbums_Loc.FirstOrDefault(x => x.GalleryAlbumID == oModel.GalleryAlbumID && x.LanguageID == oModel.LanguageID);
                }
                oGalleryAlbums.Status = oModel.Status;
                oGalleryAlbums.CoverIamge = oModel.CoverIamge;
                oGalleryAlbums_Loc.Desc = oModel.Desc;
                oGalleryAlbums_Loc.Title = oModel.Title;
                oGalleryAlbums_Loc.LanguageID = oModel.LanguageID;
                if (oModel.GalleryAlbumID == 0)
                {
                    db.MW_GalleryAlbums.Add(oGalleryAlbums);
                    db.SaveChanges();
                    oGalleryAlbums_Loc.GalleryAlbumID = oGalleryAlbums.ID;
                    db.MW_GalleryAlbums_Loc.Add(oGalleryAlbums_Loc);
                    db.SaveChanges();
                    int nCount = lstSystemLanguages.Count - 1;
                    for (int nIndex = 0; nIndex <= nCount; nIndex++)
                    {
                        MW_GalleryAlbums_Loc oGalleryAlbumsLoc = new MW_GalleryAlbums_Loc();
                        oGalleryAlbumsLoc.GalleryAlbumID = oGalleryAlbums.ID;
                        oGalleryAlbumsLoc.Desc = oModel.Desc;
                        oGalleryAlbumsLoc.Title = oModel.Title;
                        oGalleryAlbumsLoc.LanguageID = lstSystemLanguages[nIndex].LanguageID;
                        db.MW_GalleryAlbums_Loc.Add(oGalleryAlbumsLoc);
                    }
                }
                db.SaveChanges();
                return GetGalleryAlbums(oModel.LanguageID);
            }
        }

        public List<GalleryAlbumsModel> ChangeStatus(int GalleryAlbumID, int LanguageID)
        {
            using (MWCoreEntity db = new MWCoreEntity())
            {
                MW_GalleryAlbums GalleryAlbums = db.MW_GalleryAlbums.FirstOrDefault(x => x.ID == GalleryAlbumID);
                if (GalleryAlbums != null)
                {
                    GalleryAlbums.Status = GalleryAlbums.Status == true ? false : true;
                    db.SaveChanges();
                }
                return GetGalleryAlbums(LanguageID);
            }
        }

        public List<GalleryAlbumsModel> DeleteRecord(int GalleryAlbumID, int LanguageID)
        {
            using (MWCoreEntity db = new MWCoreEntity())
            {
                MW_GalleryAlbums GalleryAlbums = db.MW_GalleryAlbums.FirstOrDefault(x => x.ID == GalleryAlbumID);
                if (GalleryAlbums != null)
                {
                    GalleryAlbums.IsDeleted = true;
                    db.SaveChanges();
                }
                return GetGalleryAlbums(LanguageID);
            }
        }

        public List<GalleryModel> GetImages(int GalleryAlbumID)
        {
            using (MWCoreEntity db = new MWCoreEntity())
            {
                return (from image in db.MW_Gallery
                        where image.GalleryAlbumID == GalleryAlbumID && !image.IsDeleted
                        select new GalleryModel()
                        {
                            GalleryID = image.ID,
                            FileName = image.FileName,
                            FileType = image.FileType,
                            Status = image.Status,
                            GalleryAlbumID = image.GalleryAlbumID
                        }).ToList();
            }
        }

        public GalleryModel GetImage(int GalleryID)
        {
            using (MWCoreEntity db = new MWCoreEntity())
            {
                return (from image in db.MW_Gallery
                        where image.ID == GalleryID
                        select new GalleryModel()
                        {
                            GalleryID = image.ID,
                            FileName = image.FileName,
                            FileType = image.FileType,
                            Status = image.Status,
                            GalleryAlbumID = image.GalleryAlbumID
                        }).FirstOrDefault();
            }
        }
        public List<GalleryModel> SaveImage(GalleryModel oModel)
        {
            using (MWCoreEntity db = new MWCoreEntity())
            {
                MW_Gallery oImage = new MW_Gallery();
                if (oModel.GalleryID > 0)
                {
                    oImage = db.MW_Gallery.FirstOrDefault(x => x.ID == oModel.GalleryID);
                }
                oImage.GalleryAlbumID = oModel.GalleryAlbumID;
                oImage.FileName = oModel.FileName;
                oImage.FileType = oModel.FileType;
                oImage.Status = oModel.Status;
                if (oModel.GalleryID == 0)
                {
                    db.MW_Gallery.Add(oImage);
                }
                db.SaveChanges();
                return GetImages(oModel.GalleryAlbumID);
            }
        }

        public List<GalleryModel> ChangeImageStatus(int GalleryID, int GalleryAlbumID)
        {
            using (MWCoreEntity db = new MWCoreEntity())
            {
                MW_Gallery oImage = db.MW_Gallery.FirstOrDefault(x => x.ID == GalleryID);
                if (oImage != null)
                {
                    oImage.Status = oImage.Status == true ? false : true;
                }
                db.SaveChanges();
                return GetImages(GalleryAlbumID);
            }
        }

        public List<GalleryModel> DeleteImage(int GalleryID, int GalleryAlbumID)
        {
            using (MWCoreEntity db = new MWCoreEntity())
            {
                MW_Gallery oImage = db.MW_Gallery.FirstOrDefault(x => x.ID == GalleryID);
                if (oImage != null)
                {
                    oImage.IsDeleted = true;
                }
                db.SaveChanges();
                return GetImages(GalleryAlbumID);
            }
        }
    }
}