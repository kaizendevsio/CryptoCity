using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoCityWallet.Entities.Enums
{
    [Flags]
    public enum BinaryMapStatus : int
    {
        Unset = 0,
        Available = 1,
        BinaryPositionTaken = 2,
        InvalidBinarySponsor = 3,
        InvalidDirectSponsor = 4
    }
}
