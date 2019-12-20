using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoCityWallet.Entities.BO
{
  public class WalletTransactionBO : BaseAuditBO
    {
        public string From{ get; set; }
        public string To { get; set; }
        public decimal? Amount { get; set; }
        public string TxHash { get; set; }
        public bool IsFeeEnabled { get; set; }
    }
}
