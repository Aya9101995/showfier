using System;

namespace MWCore.Models
{
    public class MenuItemsFilterModel
    {
        public int MenuCategoryID { get; set; }
        public string MenuCategoryName { get; set; }
        //public Nullable<decimal> MinPrice { get; set; }
        //public Nullable<decimal> MaxPrice { get; set; }
        public int PageID { get; set; }
        public int PageSize { get; set; }
        public Nullable<int> TotalItemsCount { get; set; }
        public int ShopID { get; set; }
        public string SortBy { get; set; }
    }
}