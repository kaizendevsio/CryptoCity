﻿using CryptoCityWallet.Entities.DTO;
using CryptoCityWallet.Entities.BO;
using CryptoCityWallet.Entities.Enums;
using CryptoCityWallet.DataAccessLayer;
using System.Collections.Generic;

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
        public List<UserWalletBO> GetBO(TblUserAuth tblUserAuth, dbWorldCCityContext db = null)
        {
            if (db != null)
            {
                UserWalletRepository userWalletRepository = new UserWalletRepository();
                return userWalletRepository.GetBO(tblUserAuth, db);
            }
            else
            {
                using (db = new dbWorldCCityContext())
                {
                    using (var transaction = db.Database.BeginTransaction())
                    {
                        UserWalletRepository userWalletRepository = new UserWalletRepository();
                        return userWalletRepository.GetBO(tblUserAuth, db);
                    }
                }
            }

        }

    }
}
