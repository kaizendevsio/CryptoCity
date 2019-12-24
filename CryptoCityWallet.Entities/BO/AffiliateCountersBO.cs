using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoCityWallet.Entities.BO
{
   public class AffiliateCountersBO : UserResponseBO
    {
        public int DirectPartners { get; set; }
        public decimal InvestmentSum { get; set; }
    }
}
