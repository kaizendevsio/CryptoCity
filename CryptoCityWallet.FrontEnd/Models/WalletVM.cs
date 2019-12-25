using CryptoCityWallet.Entities.BO;
using CryptoCityWallet.Entities.DTO;
using System;
using System.Collections.Generic;

namespace CryptoCityWallet.FrontEnd.Models
{
    public class WalletVM : UserVM
    {
        public int GenLink { get; set; }
        public string PaymentAddress { get; set; }
        public TransactionVM TransactionHistory {get;set;}
        public List<UserWalletBO> UserWallets { get; set; }

    }
}
