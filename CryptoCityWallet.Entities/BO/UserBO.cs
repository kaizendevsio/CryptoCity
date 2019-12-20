using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using CryptoCityWallet.Entities.DTO;

namespace CryptoCityWallet.Entities.BO
{
    public class UserBO : BaseAuditBO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? Dob { get; set; }
        public string Email { get; set; }
        public string CompanyName { get; set; }
        public string PhoneNumber { get; set; }
        public short? Gender { get; set; }
        public string CountryIsoCode2 { get; set; }
        public string ConfirmedEmail { get; set; }
        public byte[] VerifyEmailCodeByte { get; set; }
        public short? EmailStatus { get; set; }
        public long UserInfoId { get; set; }
        public byte[] SecretByte { get; set; }
        [Required]
        public string PasswordString { get; set; }
        public bool? IsTempPassword { get; set; }
        public byte[] ResetPasswordCodeByte { get; set; }
        public DateTime? ResetPasswordCodeExpiration { get; set; }
        public short? LoginStatus { get; set; }
        [Required]
        public string UserName { get; set; }
        public short? FailPassAttempt { get; set; }
        public string TemporaryPassword { get; set; }
        public string DirectSponsorID { get; set; }
        public string BinarySponsorID { get; set; }
        public string BinaryPosition { get; set; }

    }
}
