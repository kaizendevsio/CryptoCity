﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CryptoCityWallet.Entities.BO;

namespace CryptoCityWallet.FrontEnd.Models
{
    public class WithdrawalVM
    {
        public string Fullname { get; set; }
        public string Username { get; set; }
        public DateTime DateJoined { get; set; }
        public UserBO UserInfo { get; set; }
    }
}