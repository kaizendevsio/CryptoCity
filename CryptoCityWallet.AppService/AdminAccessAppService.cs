using CryptoCityWallet.Entities.DTO;
using CryptoCityWallet.Entities.BO;
using CryptoCityWallet.Entities.Enums;
using CryptoCityWallet.DataAccessLayer;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;

namespace CryptoCityWallet.AppService
{
   public class AdminAccessAppService
    {
        public List<UserBO> GetAllUsers(dbWorldCCityContext db = null)
        {
            if (db != null)
            {
                UserInfoRepository userInfoRepository = new UserInfoRepository();
                return userInfoRepository.GetAll(db);
            }
            else
            {
                using (db = new dbWorldCCityContext())
                {
                    using (var transaction = db.Database.BeginTransaction())
                    {
                        UserInfoRepository userInfoRepository = new UserInfoRepository();
                        return userInfoRepository.GetAll(db);
                    }
                }
            }
        }
    }
}
