using System;
using System.Collections.Generic;

namespace CryptoCityWallet.Entities.DTO
{
    public partial class VUserData
    {
        public long? Id { get; set; }
        public bool? IsEnabled { get; set; }
        public DateTime? CreatedOn { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public long? ModifiedBy { get; set; }
        public DateTime? LastChanged { get; set; }
        public long? UserInfoId { get; set; }
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
    }
}
