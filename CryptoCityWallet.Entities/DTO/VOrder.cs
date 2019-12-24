using System;
using System.Collections.Generic;

namespace CryptoCityWallet.Entities.DTO
{
    public partial class VOrder
    {
        public long? UserInfoId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long? UserDepositRequestId { get; set; }
        public decimal? Amount { get; set; }
        public DateTime? CreatedOn { get; set; }
        public long? BusinessPackageId { get; set; }
        public short? PackageStatus { get; set; }
        public DateTime? CancellationDate { get; set; }
        public long? UserAuthId { get; set; }
    }
}
