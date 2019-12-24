using CryptoCityWallet.Entities.BO;
using CryptoCityWallet.Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoCityWallet.FrontEnd.Models
{
    public class TradeVM : UserVM
    {
        public double TotalInvestment { get; set; }
        public double YesterdayProfit { get; set; }
        public double WCCPBalance { get; set; }
        public List<UserWalletBO> UserWallets { get; set; }
        public List<TblDividend> TradeTransactions { get; set; }
        public List<TblUserBusinessPackage> UserBusinessPackages{ get; set; }
        public UserBusinessPackageBO UserBusinessPackageBuy { get; set; }
    }
}
