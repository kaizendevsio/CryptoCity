using System;
using System.Collections.Generic;

namespace CryptoCityWallet.Entities.DTO
{
    public partial class VDividend
    {
        public long? Id { get; set; }
        public long? UserInfoId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long? DividendCd { get; set; }
        public decimal? DividendPrice { get; set; }
        public long? DividendBonusCd { get; set; }
        public string BonusName { get; set; }
        public long? DividendOrderCd { get; set; }
        public long? DividendRankCd { get; set; }
        public decimal? DividendRate { get; set; }
        public DateTime? DividendDate { get; set; }
        public long? DividendCloseCd { get; set; }
        public long? UserAuthId { get; set; }
        public long? Uid { get; set; }
    }
}
