using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoCityWallet.Entities.Enums
{
    [Flags]
    public enum AccountType
    {
        Personal = 0,
        Business = 1
    }
}
