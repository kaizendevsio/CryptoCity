using CryptoCityWallet.Entities.BO;
using System;
using System.Collections.Generic;

namespace CryptoCityWallet.FrontEnd.Models
{
    public class UsersVM : UserBO
    {
         

        public int Code { get; set; }
        public int ID { get; set; }
        public string Name { get; set; }
        public int IntCode { get; set; }
        public string IntName { get; set; }
        public string TradeItem { get; set; }
        public double DepositBTC { get; set; }
        public double DepositETH { get; set; }
        public double DepositUSDT { get; set; }
        public double DepositBCH { get; set; }
         
    }
}
