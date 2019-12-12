using System;

namespace CryptoCityWallet.Entities.Enums
{
   public enum AuthStatus
    {
        Pending = 0,
        Locked = 1,
        Blocked = 2,
        System_Error = 3,
        Pending_Activation = 4,
        User_Disabled = 5,
        Session_Reused = 6,
        Session_Expired = 7,
        Wrong_Pin = 8,
        Wrong_Password = 9,
        Invalid_User = 10,
        Success = 11
    }

}
