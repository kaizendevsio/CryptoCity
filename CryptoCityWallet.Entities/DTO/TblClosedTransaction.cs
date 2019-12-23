using System;
using System.Collections.Generic;

namespace CryptoCityWallet.Entities.DTO
{
    public partial class TblClosedTransaction
    {
        public long Id { get; set; }
        public bool? IsEnabled { get; set; }
        public DateTime? CreatedOn { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public long? ModifiedBy { get; set; }
        public DateTime? LastChanged { get; set; }
        public long CloseCd { get; set; }
        public DateTime? CloseDate { get; set; }
        public DateTime? CloseDateRegistered { get; set; }
        public DateTime? CloseDateStart { get; set; }
        public DateTime? CloseDateEnd { get; set; }
    }
}
