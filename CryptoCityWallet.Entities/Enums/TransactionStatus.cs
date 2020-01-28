﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoCityWallet.Entities.Enums
{
    [Flags]
    public enum TransactionStatus : int
    {
        Pending = 0,
        Ok = 1,
        Approved = 2,
        Error = 3,
        Canceled = 4,
        Completed = 5,
        Rejected = 6
    }
}
