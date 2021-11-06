using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MWCore.Areas.MWCore.Models.Modules.Customers.Models
{
    public class CustomersWalletsModel
    {
        public int WalletID { get; set; }
        public int CustomerID { get; set; }
        public decimal Ballance { get; set; }
        public List<CustomersWalletsTransactionsModel> lstTransactions { get; set; }
    }
}