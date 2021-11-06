using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MWCore.Areas.MWCore.Models.DBClasses.Gallery
{
    public class MW_GalleryAlbums
    {
        [Key]
        public int ID { get; set; }
        public string CoverIamge { get; set; }
        public bool Status { get; set; }
        public bool IsDeleted { get; set; }
        public virtual ICollection<MW_GalleryAlbums_Loc> MW_GalleryAlbums_Loc { get; set; }
        public virtual ICollection<MW_Gallery> MW_Gallery { get; set; }
    }
}