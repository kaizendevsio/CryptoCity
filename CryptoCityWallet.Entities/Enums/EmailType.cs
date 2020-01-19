using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoCityWallet.Entities.Enums
{
    [Flags]
    public enum EmailType : int
    {
        EmailConfirmation = 0,
        AccountRegistration = 1
    }
}
