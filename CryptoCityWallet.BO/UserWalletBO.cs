using CryptoCityWallet.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoCityWallet.BO
{
    public class UserWalletBO
    {
        public long Id { get; set; }
        public bool? IsEnabled { get; set; }
        public DateTime? CreatedOn { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public long? ModifiedBy { get; set; }
        public DateTime? LastChanged { get; set; }
        public long? UserAuthId { get; set; }
        public long? WalletTypeId { get; set; }
        public decimal? Balance { get; set; }
        public decimal? BalanceFiat { get; set; }
        public string WalletName { get; set; }
        public string WalletCode { get; set; }

        public virtual TblExchangeRate ExchangeRate { get; set; }
        public virtual TblUserAuth UserAuth { get; set; }
        public virtual TblWalletType WalletType { get; set; }

    }
}
