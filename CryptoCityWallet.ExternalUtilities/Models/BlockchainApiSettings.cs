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
    }
}
