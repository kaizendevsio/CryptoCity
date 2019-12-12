using System;
using System.Collections.Generic;
using System.Text;
using CryptoCityWallet.Entities.Enums;

namespace CryptoCityWallet.Entities.BO
{
    public class TransactionQueryBO
    {
        public string FilterString { get; set; }
        public TransactionType TransactionType { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public SortingType SortingType { get; set; }
    }
}
