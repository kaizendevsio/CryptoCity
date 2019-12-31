using CryptoCityWallet.ExternalUtilities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoCityWallet.Entities.BO
{
   public class WalletAddressResponseBO : UserResponseBO
    {
        public string Address { get; set; }
        public string XpubKey { get; set; }
        public ChangellyResponse changellyResponse { get; set; }
        public string AddressTransactions { get; set; }
    }
}
