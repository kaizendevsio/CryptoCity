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

         
        public List<HistoryVM> History { get; set; }
        
    }
}
