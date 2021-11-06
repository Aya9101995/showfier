/*****************************************************************************/
/* File Name     : MW_EmailSettings.cs                                      */
/* Created By    : Abdulla Hawwash                                         */
/* Creation Date : 19/12/2017                                             */
/* Comment       : MW_EmailSettings Database Table                       */
/************************************************************************/

using System;
using System.ComponentModel.DataAnnotations;

namespace MWCore.Areas.MWCore.Models.DBClasses.Settings
{
    public class MW_EmailSettings
    {
        [Key]
        public int ID { get; set; }
        public string EmailTo { get; set; }
        public string OutgoingServer { get; set; }
        public Nullable<bool> EnableSSL { get; set; }
        public Nullable<int> PortID { get; set; }
        public string SenderEmail { get; set; }
        public string SenderPassword { get; set; }
    }
}