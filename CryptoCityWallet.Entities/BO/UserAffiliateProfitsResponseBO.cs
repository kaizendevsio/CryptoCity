using CryptoCityWallet.Entities.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoCityWallet.Entities.BO
{
   public class UserAffiliateProfitsResponseBO : UserResponseBO
    {
        public List<TblDividend> TradeTransactions { get; set; }
    }
}
