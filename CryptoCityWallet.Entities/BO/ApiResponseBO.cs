using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoCityWallet.Entities.BO
{
    public class ApiResponseBO
    {
        public string Status { get; set; }
        public string HttpStatusCode { get; set; }
        public string Message { get; set; }
        public string RedirectUrl { get; set; }
    }
}