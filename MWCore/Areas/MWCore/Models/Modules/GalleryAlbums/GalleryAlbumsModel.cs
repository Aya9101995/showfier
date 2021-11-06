using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MWCore.Areas.MWCore.Models.Modules.GalleryAlbums
{
    public class GalleryAlbumsModel
    {
        public int GalleryAlbumID { get; set; }
        public string Title { get; set; }
        public string Desc { get; set; }
        public int LanguageID { get; set; }
        public string CoverIamge { get; set; }
        public bool Status { get; set; }
        public List<GalleryModel> lstGalleries { get; set; }
    }
}