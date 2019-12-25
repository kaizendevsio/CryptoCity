using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoCityWallet.ExternalUtilities.Models
{
   public class ChangellyApiSettings
    {
        public string ApiKey { get; set; }
        public string ApiSecret { get; set; }
        public string ApiUrl { get; set; }
        public string ReceiveAddress { get; set; }
    }
}
