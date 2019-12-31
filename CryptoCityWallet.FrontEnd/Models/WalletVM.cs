using CryptoCityWallet.Entities.BO;
using CryptoCityWallet.Entities.DTO;
using CryptoCityWallet.ExternalUtilities.Models;
using System;
using System.Collections.Generic;

namespace CryptoCityWallet.FrontEnd.Models
{
    public class WalletVM : UserVM
    {
        public string WalletCode { get; set; }
        public string WalletName { get; set; }
        public string PaymentAddress { get; set; }
        public TransactionVM TransactionHistory {get;set;}
        public List<UserWalletBO> UserWallets { get; set; }
        public List<TblUserWalletAddress> UserWalletAddresses { get; set; }
        public BlockchainTx UserWalletAddressTxs { get; set; }

    }
}
