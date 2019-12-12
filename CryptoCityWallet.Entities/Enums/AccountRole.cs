using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoCityWallet.Entities.Enums
{
    [Flags]
    public enum AccessRole : byte
    {
        None = 0,
        Admin = 1,
        SuperAdmin = 2,
        Client = 3,
        Default = 4,
        Support = 5,
        Free = 10
    }
}
