using CryptoCityWallet.Entities.Enums;
using System;
using System.Collections.Generic;

namespace CryptoCityWallet.Entities.DTO
{
    public partial class TblUserBusinessPackage
    {
        public long Id { get; set; }
        public bool? IsEnabled { get; set; }
        public DateTime? CreatedOn { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public long? ModifiedBy { get; set; }
        public DateTime? LastChanged { get; set; }
        public long? UserAuthId { get; set; }
        public long? BusinessPackageId { get; set; }
        public PackageStatus PackageStatus { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public long? UserDepositRequestId { get; set; }
        public DateTime? CancellationDate { get; set; }
        public DateTime? ActivationDate { get; set; }

        public virtual TblBusinessPackage BusinessPackage { get; set; }
        public virtual TblUserAuth UserAuth { get; set; }
        public virtual TblUserDepositRequest UserDepositRequest { get; set; }
    }
}
