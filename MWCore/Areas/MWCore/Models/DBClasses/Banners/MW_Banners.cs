/*****************************************************************************/
/* File Name     : MW_Banners.cs                                            */
/* Created By    : Abdulla Hawwash                                         */
/* Creation Date : 19/12/2017                                             */
/* Comment       : MW_Banners Database Table                             */
/************************************************************************/

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MWCore.Areas.MWCore.Models.DBClasses.Banners
{
    public class MW_Banners
    {
        [Key]
        public int ID { get; set; }
        public string ImagePath { get; set; }
        public bool Status { get; set; }
        public bool IsDeleted { get; set; }
    }
}