using CryptoCityWallet.DTO;
using System.Collections.Generic;
using CryptoCityWallet.Repository;

namespace CryptoCityWallet.AppService
{
    public class UserWalletAppService
    {
       public bool Create(TblUserAuth tblUserAuth, dbWorldCCityContext db = null)
        {
            if (db != null)
            {
                UserWalletRepository userWalletRepository = new UserWalletRepository();
                return userWalletRepository.Create(tblUserAuth, db);
            }
            else
            {
                using (db = new dbWorldCCityContext())
                {
                    using (var transaction = db.Database.BeginTransaction())
                    {
                        UserWalletRepository userWalletRepository = new UserWalletRepository();  
                        transaction.Commit();

                        return userWalletRepository.Create(tblUserAuth, db);
                    }
                }
            }
           
        }

        public List<TblUserWallet> Get(TblUserAuth tblUserAuth, dbWorldCCityContext db = null)
        {
            if (db != null)
            {
                UserWalletRepository userWalletRepository = new UserWalletRepository();
                return userWalletRepository.Get(tblUserAuth, db);
            }
            else
            {
                using (db = new dbWorldCCityContext())
                {
                    using (var transaction = db.Database.BeginTransaction())
                    {
                        UserWalletRepository userWalletRepository = new UserWalletRepository();
                        return userWalletRepository.Get(tblUserAuth, db);
                    }
                }
            }
            
        }

    }
}
