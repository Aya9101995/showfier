using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MWCore.Areas.MWCore.Models.DBClasses.Customers
{
    public class MW_CustomersWallets
    {
        [Key]
        public int ID { get; set; }
        public int CustomerID { get; set; }
        public decimal Ballance { get; set; }
        [ForeignKey("CustomerID")]
        public MW_Customers MW_Customers { get; set; }
        public virtual ICollection<MW_CustomersWalletsTransactions> MW_CustomersWalletsTransactions { get; set; }
    }
}