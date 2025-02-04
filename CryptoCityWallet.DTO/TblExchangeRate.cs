﻿using System;
using System.Collections.Generic;

namespace CryptoCityWallet.DTO
{
    public partial class TblExchangeRate
    {
        public long Id { get; set; }
        public bool? IsEnabled { get; set; }
        public DateTime? CreatedOn { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public long? ModifiedBy { get; set; }
        public DateTime? LastChanged { get; set; }
        public long SourceCurrencyId { get; set; }
        public long TargetCurrencyId { get; set; }
        public decimal? Value { get; set; }
        public decimal? Fee { get; set; }
        public DateTime? EffectivityDate { get; set; }
        public DateTime? ExpiryDate { get; set; }

        public TblCurrency SourceCurrency { get; set; }
        public TblCurrency TargetCurrency { get; set; }
    }
}
