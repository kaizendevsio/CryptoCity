using System;
using System.Collections.Generic;

namespace CryptoCityWallet.Entities.DTO
{
    public partial class TblUserBonus
    {
        public long Id { get; set; }
        public bool? IsEnabled { get; set; }
        public DateTime? CreatedOn { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public long? ModifiedBy { get; set; }
        public DateTime? LastChanged { get; set; }
        public long BonusCd { get; set; }
        public string BonusName { get; set; }
        public string BonusMemo { get; set; }
        public long UserAuthId { get; set; }

        public virtual TblUserAuth UserAuth { get; set; }
    }
}
