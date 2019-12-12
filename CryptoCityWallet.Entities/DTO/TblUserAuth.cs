using System;
using System.Collections.Generic;

namespace CryptoCityWallet.Entities.DTO
{
    public partial class TblUserAuth
    {
        public TblUserAuth()
        {
            TblUserAddress = new HashSet<TblUserAddress>();
            TblUserDepositRequest = new HashSet<TblUserDepositRequest>();
            TblUserIncomeTransaction = new HashSet<TblUserIncomeTransaction>();
            TblUserRole = new HashSet<TblUserRole>();
            TblUserWallet = new HashSet<TblUserWallet>();
            TblUserWalletAddress = new HashSet<TblUserWalletAddress>();
            TblUserWalletTransaction = new HashSet<TblUserWalletTransaction>();
            TblUserWithdrawalRequest = new HashSet<TblUserWithdrawalRequest>();
        }

        public long Id { get; set; }
        public bool? IsEnabled { get; set; }
        public DateTime? CreatedOn { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public long? ModifiedBy { get; set; }
        public DateTime? LastChanged { get; set; }
        public long UserInfoId { get; set; }
        public byte[] SecretByte { get; set; }
        public bool? IsTempPassword { get; set; }
        public byte[] ResetPasswordCodeByte { get; set; }
        public DateTime? ResetPasswordCodeExpiration { get; set; }
        public short? LoginStatus { get; set; }
        public string UserName { get; set; }
        public short? PasswordFailAttempt { get; set; }
        public string TemporaryPassword { get; set; }
        public string UserAlias { get; set; }
        public byte[] PasswordByte { get; set; }

        public virtual TblUserInfo UserInfo { get; set; }
        public virtual TblUserMap TblUserMap { get; set; }
        public virtual ICollection<TblUserAddress> TblUserAddress { get; set; }
        public virtual ICollection<TblUserDepositRequest> TblUserDepositRequest { get; set; }
        public virtual ICollection<TblUserIncomeTransaction> TblUserIncomeTransaction { get; set; }
        public virtual ICollection<TblUserRole> TblUserRole { get; set; }
        public virtual ICollection<TblUserWallet> TblUserWallet { get; set; }
        public virtual ICollection<TblUserWalletAddress> TblUserWalletAddress { get; set; }
        public virtual ICollection<TblUserWalletTransaction> TblUserWalletTransaction { get; set; }
        public virtual ICollection<TblUserWithdrawalRequest> TblUserWithdrawalRequest { get; set; }
    }
}
