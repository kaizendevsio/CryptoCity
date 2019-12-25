using System;
using System.Collections.Generic;
using System.Text;
using CryptoCityWallet.Entities.DTO;

namespace CryptoCityWallet.Entities.BO
{
   public class ExchangeRateBO : TblExchangeRate
    {
        public decimal? OppositeValue { get => 1 / Value;}
    }
}
