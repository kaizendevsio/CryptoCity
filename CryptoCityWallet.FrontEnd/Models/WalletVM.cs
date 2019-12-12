using System;
using System.Collections.Generic;

namespace CryptoCityWallet.FrontEnd.Models
{
    public class WalletVM
    {
        public decimal BTCBalance { get; set; }

        public decimal BCHBalance { get; set; }

        public decimal ETHBalance { get; set; }

        public decimal TTHBalance { get; set; }


        public List<TransactionVM> TransactionHistory {get;set;}


    }
}
