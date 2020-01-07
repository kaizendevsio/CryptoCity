using System.Collections.Generic;
using CryptoCityWallet.Entities.DTO;

namespace CryptoCityWallet.Entities.BO
{
    public class UserResponseBO : ApiResponseBO
    {
        public TblUserAuth UserAuth { get; set; }
        public TblUserInfo UserInfo { get; set; }
        public TblUserRole UserRole { get; set; }
        public UserMapBO UserBinaryMap { get; set; }
        public UnilevelMapBO UserUnilevelMap { get; set; }
        public List<TblUserBusinessPackage> BusinessPackages { get; set; }
        public List<UserWalletBO> UserWallet { get; set;}
        public List<TblUserWalletTransaction> UserWalletTransactions { get; set; }
        public List<TblUserWalletAddress> UserWalletAddress { get; set; }
    }
}
