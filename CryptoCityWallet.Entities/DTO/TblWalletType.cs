using System;
using System.Collections.Generic;

namespace CryptoCityWallet.Entities.DTO
{
    public partial class TblWalletType
    {
        public TblWalletType()
        {
            TblUserDepositRequest = new HashSet<TblUserDepositRequest>();
            TblUserWallet = new HashSet<TblUserWallet>();
            TblUserWithdrawalRequest = new HashSet<TblUserWithdrawalRequest>();
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

        public virtual TblCurrency Currency { get; set; }
        public virtual ICollection<TblUserDepositRequest> TblUserDepositRequest { get; set; }
        public virtual ICollection<TblUserWallet> TblUserWallet { get; set; }
        public virtual ICollection<TblUserWithdrawalRequest> TblUserWithdrawalRequest { get; set; }
    }
}
