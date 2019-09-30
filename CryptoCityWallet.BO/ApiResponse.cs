using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoCityWallet.BO
{
    public class ApiResponse
    {
        public string Status { get; set; }
        public string HttpStatusCode { get; set; }
        public string Message { get; set; }
    }
}
