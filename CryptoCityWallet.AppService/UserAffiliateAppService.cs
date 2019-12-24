using CryptoCityWallet.Entities.DTO;
using CryptoCityWallet.Entities.BO;
using CryptoCityWallet.Entities.Enums;
using CryptoCityWallet.DataAccessLayer;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;

namespace CryptoCityWallet.AppService
{
   public class UserAffiliateAppService
    {
        public List<TblDividend> GetAllTradeProfits(TblUserAuth userAuth, dbWorldCCityContext db = null)
        {
            if (db != null)
            {
                UserDividendRepository userDividendRepository = new UserDividendRepository();
                return userDividendRepository.GetAll(userAuth, db);
            }
            else
            {
                using (db = new dbWorldCCityContext())
                {
                    using (var transaction = db.Database.BeginTransaction())
                    {
                        UserDividendRepository userDividendRepository = new UserDividendRepository();
                        return userDividendRepository.GetAll(userAuth, db);
                    }
                }
            }
        }

    }
}
