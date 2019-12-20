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
   public class ExchangeRateRepository
    {
        public bool Create()
        {
            return true;
        }
        public TblExchangeRate Get(TblExchangeRate exchangeRate,dbWorldCCityContext db)
        {
            var _q = from a in db.TblExchangeRate
                     where a.SourceCurrencyId == exchangeRate.SourceCurrencyId && a.TargetCurrencyId == exchangeRate.TargetCurrencyId && a.IsEnabled == true
                     join b in db.TblCurrency on a.SourceCurrencyId equals b.Id
                     join c in db.TblCurrency on a.TargetCurrencyId equals c.Id
                     select new TblExchangeRate
                     {
                         Id = a.Id,
                         SourceCurrency = b,
                         SourceCurrencyId = b.Id,
                         TargetCurrency = c,
                         TargetCurrencyId = c.Id                         
                     };

            TblExchangeRate _qRes = _q.FirstOrDefault<TblExchangeRate>();

            if (_qRes.Value == null)
            {
                throw new System.ArgumentException("Exchange Rate Not Available");
            }
            return _qRes;
        }

        public List<TblExchangeRate> GetAll(int sourceCurrencyId, dbWorldCCityContext db)
        {
            var _q = from a in db.TblExchangeRate
                     where a.SourceCurrencyId == sourceCurrencyId && a.IsEnabled == true
                     join b in db.TblCurrency on a.SourceCurrencyId equals b.Id
                     join c in db.TblCurrency on a.TargetCurrencyId equals c.Id
                     select new TblExchangeRate
                     {
                         Id = a.Id,
                         SourceCurrency = b,
                         SourceCurrencyId = b.Id,
                         TargetCurrency = c,
                         TargetCurrencyId = c.Id
                     };

            List<TblExchangeRate> _qRes = _q.ToList<TblExchangeRate>();

            return _qRes;
        }

    }
}
