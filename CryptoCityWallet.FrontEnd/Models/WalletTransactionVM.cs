using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoCityWallet.FrontEnd.Models
{
    public class WalletTransactionVM
    {
        public string From { get; set; }
        public string To { get; set; }
        public string Amount { get; set; }
    }
}
