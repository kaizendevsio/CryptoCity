using System;
using System.Collections.Generic;

namespace CryptoCityWallet.FrontEnd.Models
{
    public class WalletMVMList : UserVM
    {
        public List<WalletMVM> WalletList { get; set; }

        public List<TransactionWallet> TransactionWallet { get; set; }

    }
}
