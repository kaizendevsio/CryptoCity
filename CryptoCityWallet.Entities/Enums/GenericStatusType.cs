﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoCityWallet.Entities.Enums
{
    [Flags]
    public enum GenericStatusType : int
    {
        None = 0,
        Ok = 1,
        Approved = 2,
        Error = 3,
        AccessDenied = 4,
        Disabled = 5,
        Canceled = 6
    }
}
