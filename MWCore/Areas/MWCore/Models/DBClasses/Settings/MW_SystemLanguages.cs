/*****************************************************************************/
/* File Name     : MW_SystemLanguages.cs                                    */
/* Created By    : Abdulla Hawwash                                         */
/* Creation Date : 19/12/2017                                             */
/* Comment       : MW_SystemLanguages Database Table                     */
/************************************************************************/

using System;
using System.ComponentModel.DataAnnotations;

namespace MWCore.Areas.MWCore.Models.DBClasses.Settings
{
    [Serializable]
    public class MW_SystemLanguages
    {
        [Key]
        public int ID { get; set; }
        public string LanguageName { get; set; }
        public string LanguageCode { get; set; }
    }
}