using System;
using System.Text;
using System.Linq;
using System.Security.Cryptography;
using CryptoCityWallet.Entities.DTO;
using CryptoCityWallet.Entities.BO;
using CryptoCityWallet.Entities.Enums;
using CryptoCityWallet.DataAccessLayer;
using System.Collections.Generic;

namespace CryptoCityWallet.DataAccessLayer
{
   public class CurrencyTypeRepository
    {
        public TblCurrency Get(TblCurrency currency, dbWorldCCityContext db)
        {
            TblCurrency currencyType = db.TblCurrency.FirstOrDefault(item => item.Id == currency.Id || item.CurrencyIsoCode3 == currency.CurrencyIsoCode3);
            return currencyType;
        }
    }
}
