using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MWCore.Areas.MWCore.Models.Modules.Customers.Models
{
    public class CustomersWalletsTransactionsModel
    {
        public long TransactionID { get; set; }
        public long WalletID { get; set; }
        /// <summary>
        /// incoming
        /// </summary>
        public decimal Debit { get; set; }
        /// <summary>
        /// outgoing
        /// </summary>
        public decimal Credit { get; set; }
        /// <summary>
        /// 1 => Order
        /// 2 => Topup
        /// </summary>
        public int ReferenceType { get; set; }
        public long ReferenceID { get; set; }
        public string Notes { get; set; }
        public DateTime TransactionDate { get; set; }
    }
}