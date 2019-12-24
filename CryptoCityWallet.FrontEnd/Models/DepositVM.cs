using System;

namespace CryptoCityWallet.FrontEnd.Models
{
    public class DepositVM : UserVM
    { 
        public decimal DepositAmount { get; set; }

        public string DepositCurrency { get; set; }

         
    }
}
