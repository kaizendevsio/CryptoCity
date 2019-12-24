using System;
using System.Collections.Generic;

namespace CryptoCityWallet.Entities.DTO
{
    public partial class VClose
    {
        public long? CloseCd { get; set; }
        public DateTime? CloseDate { get; set; }
        public DateTime? CloseDateRegistered { get; set; }
        public decimal? CloseDevidend { get; set; }
        public DateTime? CloseDateStart { get; set; }
        public DateTime? CloseDateEnd { get; set; }
        public TimeSpan? CloseTime { get; set; }
    }
}
