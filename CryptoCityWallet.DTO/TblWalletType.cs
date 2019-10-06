using System;
using System.Collections.Generic;

namespace CryptoCityWallet.DTO
{
    public partial class TblWalletType
    {
        public TblWalletType()
        {
            TblUserWallet = new HashSet<TblUserWallet>();
        }

        public long Id { get; set; }
        public bool? IsEnabled { get; set; }
        public DateTime? CreatedOn { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public long? ModifiedBy { get; set; }
        public DateTime? LastChanged { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
        public short Type { get; set; }
        public long? CurrencyId { get; set; }

        public TblCurrency Currency { get; set; }
        public ICollection<TblUserWallet> TblUserWallet { get; set; }
    }
}
