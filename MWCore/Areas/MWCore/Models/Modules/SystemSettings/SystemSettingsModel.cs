using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MWCore.Areas.MWCore.Models.Modules.SystemSettings
{
    public class SystemSettingsModel
    {
        public int ID { get; set; }
        /// <summary>
        /// enumPromoCodesTypes
        /// </summary>
        public int PromoCodeType { get; set; }

        public string DefaultWebsiteURL { get; set; }
        /// <summary>
        /// enumPromoCodesDiscountsTypes
        /// </summary>
        public int PromoCodeDiscountType { get; set; }
        public decimal PromoCodeDicountValue { get; set; }
        public decimal MaxPrice { get; set; }
        public bool IsChatEnabled { get; set; }
    }
}