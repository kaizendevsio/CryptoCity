using System;
using System.Collections.Generic;

namespace CryptoCityWallet.Entities.DTO
{
    public partial class VMember
    {
        public long? Id { get; set; }
        public long? UserAuthId { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long? SponsorUserId { get; set; }
        public long? UplineUserId { get; set; }
        public short? Position { get; set; }
        public decimal? MemberVolumeOwn { get; set; }
        public decimal? MemberVolumeUni { get; set; }
        public decimal? MemberVolumeLeft { get; set; }
        public decimal? MemberVolumeRight { get; set; }
        public long? MemberRankCd { get; set; }
        public string Uid { get; set; }
    }
}
