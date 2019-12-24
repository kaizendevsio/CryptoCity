using System;

namespace CryptoCityWallet.FrontEnd.Models
{
    public class ErrorViewModel : UserVM
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
