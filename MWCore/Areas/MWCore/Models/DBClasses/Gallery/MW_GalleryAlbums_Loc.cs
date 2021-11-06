using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MWCore.Areas.MWCore.Models.DBClasses.Gallery
{
    public class MW_GalleryAlbums_Loc
    {
        [Key]
        public int ID { get; set; }
        public int GalleryAlbumID { get; set; }
        public string Title { get; set; }
        public string Desc { get; set; }
        public int LanguageID { get; set; }
        [ForeignKey("GalleryAlbumID")]
        public MW_GalleryAlbums MW_GalleryAlbums { get; set; }
    }
}