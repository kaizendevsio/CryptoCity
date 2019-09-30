using System.Collections.Generic;
using CryptoCityWallet.DTO;

namespace CryptoCityWallet.BO
{
    public class UserAuthResponse : ApiResponse
    {
        public TblUserAuth UserAuth { get; set; }
        public TblUserInfo UserInfo { get; set; }
        public List<TblUserWallet> UserWallet { get; set;}
    }
}
