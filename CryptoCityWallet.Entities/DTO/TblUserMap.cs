using System;
using System.Collections.Generic;

namespace CryptoCityWallet.Entities.DTO
{
    public partial class TblUserMap
    {
        public long Id { get; set; }
        public bool? IsEnabled { get; set; }
        public DateTime? CreatedOn { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public long? ModifiedBy { get; set; }
        public DateTime? LastChanged { get; set; }
        public string UserUid { get; set; }
        public long SponsorUserId { get; set; }
        public long UplineUserId { get; set; }
        public short? Position { get; set; }

        public virtual TblUserAuth IdNavigation { get; set; }
    }
}
