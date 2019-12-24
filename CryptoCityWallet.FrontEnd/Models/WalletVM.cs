using CryptoCityWallet.Entities.DTO;
using System;
using System.Collections.Generic;

namespace CryptoCityWallet.FrontEnd.Models
{
    public class WalletVM : UserVM
    {
        public decimal BTCBalance { get; set; }

        public decimal BCHBalance { get; set; }

        public decimal ETHBalance { get; set; }

        public decimal TTHBalance { get; set; }

        public int GenLink { get; set; }

        public string PaymentAddress { get; set; }
        public TransactionVM TransactionHistory {get;set;}

    }
}
