/*****************************************************************************/
/* File Name     : MW_SystemSettings.cs                                     */
/* Created By    : Abdulla Hawwash                                         */
/* Creation Date : 19/12/2017                                             */
/* Comment       : MW_SystemSettings Database Table                      */
/************************************************************************/

using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MWCore.Areas.MWCore.Models.DBClasses.Settings
{
    public class MW_SystemSettings
    {
        [Key]
        public int ID { get; set; }
    }
}