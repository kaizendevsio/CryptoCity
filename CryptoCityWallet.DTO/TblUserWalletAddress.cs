using System;
using System.Collections.Generic;

namespace CryptoCityWallet.DTO
{
    public partial class TblUserWalletAddress
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
        public string CurrencyIsoCode3 { get; set; }
        public byte[] AddressByte { get; set; }
        public decimal? Balance { get; set; }

        public TblUserAuth UserAuth { get; set; }
    }
}
