/*****************************************************************************/
/* File Name     : FileUploader.cs                                          */
/* Created By    : Abdulla Hawwash                                         */
/* Creation Date : 19/12/2017                                             */
/* Comment       : File Uploader                                         */
/************************************************************************/

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace MWCore.Areas.MWCore.Models.Common
{
    public class FileUploader
    {
        [Required(ErrorMessage = "Required.")]
        [FileType("jpg,jpeg,png", ErrorMessage = "File Type")]
        public List<HttpPostedFileBase> Files { get; set; }
        [FileType("jpg,jpeg,png", ErrorMessage = "File Type")]
        public List<HttpPostedFileBase> EditFiles { get; set; }
        public FileUploader()
        {
            Files = new List<HttpPostedFileBase>();
            EditFiles = new List<HttpPostedFileBase>();
        }
    }
}