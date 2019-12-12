using CryptoCityWallet.Entities.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoCityWallet.Entities.BO
{
    public class UserWalletBO : BaseAuditBO
    {
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
