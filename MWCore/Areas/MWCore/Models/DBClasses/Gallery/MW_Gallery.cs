using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MWCore.Areas.MWCore.Models.DBClasses.Gallery
{
    public class MW_Gallery
    {
        [Key]
        public int ID { get; set; }
        public int GalleryAlbumID { get; set; }
        public int FileType { get; set; }
        public string FileName { get; set; }
        public bool Status { get; set; }
        public bool IsDeleted { get; set; }
        [ForeignKey("GalleryAlbumID")]
        public MW_GalleryAlbums MW_GalleryAlbums { get; set; }
    }
}