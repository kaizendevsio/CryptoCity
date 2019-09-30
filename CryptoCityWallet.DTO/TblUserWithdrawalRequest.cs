using System;
using System.Collections.Generic;
using System.Collections;

namespace CryptoCityWallet.DTO
{
    public partial class TblUserWithdrawalRequest
    {
        public long Id { get; set; }
        public bool? IsEnabled { get; set; }
        public DateTime? CreatedOn { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public long? ModifiedBy { get; set; }
        public DateTime? LastChanged { get; set; }
        public long UserAuthId { get; set; }
        public string Address { get; set; }
        public decimal? TotalAmount { get; set; }
        public short? WithdrawalStatus { get; set; }
        public BitArray Remarks { get; set; }

        public virtual TblUserAuth UserAuth { get; set; }
    }
}
