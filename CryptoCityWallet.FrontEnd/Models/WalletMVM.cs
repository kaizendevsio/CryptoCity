using System;
using System.Collections.Generic;

namespace CryptoCityWallet.FrontEnd.Models
{
    public class WalletMVM : UserVM
    {
       public string Currency { get; set; }
        public double TotalBalance { get; set; }
        public double Available { get; set; }
        public double HOT { get; set; }
        public double COLD { get; set; }
        public double Rate{ get; set; }
        public double USD { get; set; }

     
}
}
