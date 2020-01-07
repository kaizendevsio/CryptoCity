using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoCityWallet.ExternalUtilities.Models
{
   public class BlockchainApiSettings
    {
        public string ApiKey { get; set; }
        public string XpubKey { get; set; }
        public string CallbackURL { get; set; }
        public Uri ApiUri { get; set; }
        public Uri BlockCypherApiUri { get; set; }
        public string ServiceUrl { get; set; }
        public string WalletID { get; set; }
        public string WalletPassword { get; set; }
    }
}
