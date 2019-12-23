﻿using System;
using System.Collections.Generic;
using System.Text;
using CryptoCityWallet.Entities.DTO;

namespace CryptoCityWallet.Entities.BO
{
   public class UserBusinessPackageBO : TblUserAuth
    {
        public string FromCurrencyIso3{ get; set; }
        public string FromWalletCode { get; set; }
        public decimal AmountPaid { get; set; }
        public string PaymentAddress { get; set; }
        public int BusinessPackageID { get; set; }
    }
}