using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoCityWallet.Entities.Enums
{
    [Flags]
    public enum DepositStatus
    {
        PendingPayment = 0,
        UnPaid = 1,
        UnderPaid = 2,
        Paid = 3,
        Expired = 4,
        InvalidPayment = 5,
        Blocked = 6,
        Revoked = 7
    }
}
