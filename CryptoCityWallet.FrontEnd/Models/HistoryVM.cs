using CryptoCityWallet.Entities.DTO;
using System;
using System.Collections.Generic;

namespace CryptoCityWallet.FrontEnd.Models
{
    public class HistoryVM : UserVM
    {
        public List<TblDividend> TradeTransactions  { get; set; }
    }
}
