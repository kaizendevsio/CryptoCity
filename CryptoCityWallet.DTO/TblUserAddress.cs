using System;
using System.Collections.Generic;
using System.Collections;

namespace CryptoCityWallet.DTO
{
    public partial class TblUserAddress
    {
        public long Id { get; set; }
        public bool? IsEnabled { get; set; }
        public DateTime? CreatedOn { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public long? ModifiedBy { get; set; }
        public DateTime? LastChanged { get; set; }
        public long UserAuthId { get; set; }
        public string PostalCode { get; set; }
        public string CityName { get; set; }
        public BitArray StateName { get; set; }
        public string Address { get; set; }
        public long? CityId { get; set; }
        public long? CountryId { get; set; }
        public string CountryIsoCode2 { get; set; }
        public bool? IsPrimary { get; set; }

        public TblUserAuth UserAuth { get; set; }
    }
}
