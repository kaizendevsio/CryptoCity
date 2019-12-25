using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoCityWallet.Entities.BO
{
   public class CryptoCurrencyDepositBO
    {
        public string SourceCurrency { get; set; }
        public string targetCurrency { get; set; }
        public decimal Amount { get; set; }
    }
}
