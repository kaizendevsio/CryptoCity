﻿using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace CryptoCityWallet.ExternalUtilities.Models
{
   public class ResponseBO
    {
        public CookieCollection ResponseCookies { get; set; }

        public string ResponseResult { get; set; }
    }
}