using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MWCore.Areas.MWCore.Models.Modules.Banners
{
    public class BannersModel
    {
        public int BannerID { get; set; }
        public string ImagePath { get; set; }
        public bool Status { get; set; }
    }
}