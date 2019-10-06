using System;
using System.Collections.Generic;

namespace CryptoCityWallet.DTO
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
        public string SponsorUserId { get; set; }
        public string UplineUserId { get; set; }
        public short? Position { get; set; }

        public TblUserAuth IdNavigation { get; set; }
    }
}
