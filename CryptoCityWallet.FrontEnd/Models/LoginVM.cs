using System;

namespace CryptoCityWallet.FrontEnd.Models
{
    public class LoginVM
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
