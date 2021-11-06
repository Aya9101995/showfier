using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MWCore.Areas.MWCore.Models.Modules.GalleryAlbums
{
    public class GalleryModel
    {
        public int GalleryID { get; set; }
        public int GalleryAlbumID { get; set; }
        public int FileType { get; set; }
        public string FileName { get; set; }
        public bool Status { get; set; }
    }
}