using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoCityWallet.Entities.Enums
{
    [Flags]
    public enum AffiliateBonusType : long
    {
        AffiliateProfits = 1,
        BinaryProfits = 2,
        DailyProfits = 4
    }
}
