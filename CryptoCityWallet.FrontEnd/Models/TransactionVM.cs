using System;
using System.Collections.Generic;
using CryptoCityWallet.Entities.DTO;

namespace CryptoCityWallet.FrontEnd.Models
{
    public class TransactionVM : UserVM
    {
        public double TotalInvestment { get; set; }
        public double YesterdayProfit { get; set; }
        public double WCCPBalance { get; set; }
        public List<TblUserWalletTransaction> UserWalletTransactions{ get; set; }
    }
}
