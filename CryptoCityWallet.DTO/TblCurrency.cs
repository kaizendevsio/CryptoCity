using System;
using System.Collections.Generic;

namespace CryptoCityWallet.DTO
{
    public partial class TblCurrency
    {
        public TblCurrency()
        {
            TblExchangeRateSourceCurrency = new HashSet<TblExchangeRate>();
            TblExchangeRateTargetCurrency = new HashSet<TblExchangeRate>();
        }

        public long Id { get; set; }
        public bool? IsEnabled { get; set; }
        public DateTime? CreatedOn { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public long? ModifiedBy { get; set; }
        public DateTime? LastChanged { get; set; }
        public string Name { get; set; }
        public string CurrencyIsoCode3 { get; set; }
        public string Description { get; set; }
        public short? CurrencyType { get; set; }

        public virtual ICollection<TblExchangeRate> TblExchangeRateSourceCurrency { get; set; }
        public virtual ICollection<TblExchangeRate> TblExchangeRateTargetCurrency { get; set; }
    }
}
