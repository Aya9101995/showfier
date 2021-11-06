using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace MWCore.Areas.MWCore.Models.Common
{
    public class ImagesUploader
    {
        public static string UploadBase64Image(string sImage)
        {
            string sUploadPath = System.Configuration.ConfigurationManager.AppSettings["UploadPath"].ToString();
            string sFileName = string.Empty;
            sFileName = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".jpg";
            var path = Path.Combine(sUploadPath);
            string sPath = System.IO.Path.Combine(path.ToString());
            sImage = sImage.Replace(" ", "+");
            if ((sImage.Length % 4) == 0)
            {
                File.WriteAllBytes(sPath + sFileName, Convert.FromBase64String(sImage));
                return sFileName;
            }
            else
            {
                return "-99";
            }
        }
    }
}