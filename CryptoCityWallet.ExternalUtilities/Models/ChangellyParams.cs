﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoCityWallet.ExternalUtilities.Models
{
   public class ChangellyParams
    {
        public string from { get; set; }
        public string to { get; set; }
        public string address { get; set; }
        public decimal amount { get; set; }
    }
}
