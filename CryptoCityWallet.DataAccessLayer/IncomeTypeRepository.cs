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
   public class IncomeTypeRepository
    {
        public bool Create()
        {
            throw new NotImplementedException();
        }
        public TblIncomeType Get(TblIncomeType incomeTypeQuery, dbWorldCCityContext db)
        {
            TblIncomeType incomeType = db.TblIncomeType.FirstOrDefault(item => item.Id == incomeTypeQuery.Id || item.IncomeShortName == incomeTypeQuery.IncomeShortName);
            return incomeType;
        }
    }
}
