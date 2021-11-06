using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MWCore.Areas.MWCore.Models.DBClasses.Customers
{
    public class MW_CustomersWalletsTransactions
    {
        [Key]
        public int ID { get; set; }
        public int WalletID { get; set; }
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

        [ForeignKey("WalletID")]
        public MW_CustomersWallets MW_CustomersWallets { get; set; }
    }
}