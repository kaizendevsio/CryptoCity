using CryptoCityWallet.Entities.Enums;
using System;
using System.Collections.Generic;

namespace CryptoCityWallet.Entities.DTO
{
    public partial class TblDividend
    {
        public long Id { get; set; }
        public bool? IsEnabled { get; set; }
        public DateTime? CreatedOn { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public long? ModifiedBy { get; set; }
        public DateTime? LastChanged { get; set; }
        public long DividendCd { get; set; }
        public decimal? DividendPrice { get; set; }
        public DateTime? DividendDateRegistered { get; set; }
        public long? DividendUserCd { get; set; }
        public AffiliateBonusType? DividendBonusCd { get; set; }
        public long? DividendOrderCd { get; set; }
        public long? DividendRankCd { get; set; }
        public decimal? DividendRate { get; set; }
        public DateTime? DividendDate { get; set; }
        public long? DividendCloseCd { get; set; }
        public long? DividendUserAuthId { get; set; }

        public virtual TblUserAuth DividendUserAuth { get; set; }
    }
}
