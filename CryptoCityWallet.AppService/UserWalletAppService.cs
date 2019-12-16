using CryptoCityWallet.Entities.DTO;
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
                return userWalletRepository.GetAll(tblUserAuth, db);
            }
            else
            {
                using (db = new dbWorldCCityContext())
                {
                    using (var transaction = db.Database.BeginTransaction())
                    {
                        UserWalletRepository userWalletRepository = new UserWalletRepository();
                        return userWalletRepository.GetAll(tblUserAuth, db);
                    }
                }
            }

        }
        public List<UserWalletBO> GetBO(TblUserAuth tblUserAuth, dbWorldCCityContext db = null)
        {
            if (db != null)
            {
                UserWalletRepository userWalletRepository = new UserWalletRepository();
                return userWalletRepository.GetAllBO(tblUserAuth, db);
            }
            else
            {
                using (db = new dbWorldCCityContext())
                {
                    using (var transaction = db.Database.BeginTransaction())
                    {
                        UserWalletRepository userWalletRepository = new UserWalletRepository();
                        return userWalletRepository.GetAllBO(tblUserAuth, db);
                    }
                }
            }

        }
        public bool Increment(UserWalletBO userWallet, WalletTransactionBO walletTransaction, dbWorldCCityContext db = null)
        {
            UserWalletRepository userWalletRepository = new UserWalletRepository();

            if (db != null)
            {
                TblUserWallet sourceUserWallet = userWalletRepository.Get(userWallet, db);
                UserWalletBO targetUserWallet = new UserWalletBO();

                targetUserWallet.UserAuthId = userWallet.UserAuthId;
                targetUserWallet.WalletTypeId = userWallet.WalletTypeId;
                targetUserWallet.Balance = sourceUserWallet.Balance + (decimal)walletTransaction.Amount;

                return userWalletRepository.Update(targetUserWallet, db);

            }
            else
            {
                using (db = new dbWorldCCityContext())
                {
                    using (var transaction = db.Database.BeginTransaction())
                    {
                        TblUserWallet sourceUserWallet = userWalletRepository.Get(userWallet, db);
                        UserWalletBO targetUserWallet = new UserWalletBO();

                        targetUserWallet.UserAuthId = userWallet.UserAuthId;
                        targetUserWallet.WalletTypeId = userWallet.WalletTypeId;
                        targetUserWallet.Balance = sourceUserWallet.Balance + (decimal)walletTransaction.Amount;

                        bool res = userWalletRepository.Update(targetUserWallet, db);
                        transaction.Commit();

                        return res;
                    }
                }
            }

        }
        public bool Decrement(UserWalletBO userWallet, WalletTransactionBO walletTransaction, dbWorldCCityContext db = null)
        {
            UserWalletRepository userWalletRepository = new UserWalletRepository();

            if (db != null)
            {
                TblUserWallet sourceUserWallet = userWalletRepository.Get(userWallet, db);
                UserWalletBO targetUserWallet = new UserWalletBO();

                targetUserWallet.UserAuthId = userWallet.UserAuthId;
                targetUserWallet.WalletTypeId = userWallet.WalletTypeId;
                targetUserWallet.Balance = sourceUserWallet.Balance - (decimal)walletTransaction.Amount;

                return userWalletRepository.Update(targetUserWallet, db);

            }
            else
            {
                using (db = new dbWorldCCityContext())
                {
                    using (var transaction = db.Database.BeginTransaction())
                    {
                        TblUserWallet sourceUserWallet = userWalletRepository.Get(userWallet, db);
                        UserWalletBO targetUserWallet = new UserWalletBO();

                        targetUserWallet.UserAuthId = userWallet.UserAuthId;
                        targetUserWallet.WalletTypeId = userWallet.WalletTypeId;
                        targetUserWallet.Balance = sourceUserWallet.Balance - (decimal)walletTransaction.Amount;

                        bool res = userWalletRepository.Update(targetUserWallet, db);
                        transaction.Commit();

                        return res;
                    }
                }
            }
        }
        public bool Adjust(UserWalletBO userWallet, WalletTransactionBO walletTransaction, dbWorldCCityContext db = null)
        {
            UserWalletRepository userWalletRepository = new UserWalletRepository();

            if (db != null)
            {
                TblUserWallet sourceUserWallet = userWalletRepository.Get(userWallet, db);
                UserWalletBO targetUserWallet = new UserWalletBO();

                targetUserWallet.UserAuthId = userWallet.UserAuthId;
                targetUserWallet.WalletTypeId = userWallet.WalletTypeId;
                targetUserWallet.Balance = (decimal)walletTransaction.Amount;

                return userWalletRepository.Update(targetUserWallet, db);

            }
            else
            {
                using (db = new dbWorldCCityContext())
                {
                    using (var transaction = db.Database.BeginTransaction())
                    {
                        TblUserWallet sourceUserWallet = userWalletRepository.Get(userWallet, db);
                        UserWalletBO targetUserWallet = new UserWalletBO();

                        targetUserWallet.UserAuthId = userWallet.UserAuthId;
                        targetUserWallet.WalletTypeId = userWallet.WalletTypeId;
                        targetUserWallet.Balance = (decimal)walletTransaction.Amount;

                        bool res = userWalletRepository.Update(targetUserWallet, db);
                        transaction.Commit();

                        return res;
                    }
                }
            }
        }
        public bool Transfer(UserWalletBO sourceUserWalletBO, UserWalletBO targetUserWalletBO, WalletTransactionBO walletTransaction, dbWorldCCityContext db = null)
        {
            UserWalletRepository userWalletRepository = new UserWalletRepository();

            if (db != null)
            {
                TblUserWallet sourceUserWallet = userWalletRepository.Get(sourceUserWalletBO, db);
                TblUserWallet targetUserWallet = userWalletRepository.Get(targetUserWalletBO, db);
                
                UserWalletBO sourceUserWalletUpdate = new UserWalletBO();
                sourceUserWalletUpdate.UserAuthId = sourceUserWallet.UserAuthId;
                sourceUserWalletUpdate.WalletTypeId = sourceUserWallet.WalletTypeId;
                sourceUserWalletUpdate.Balance = (decimal)sourceUserWallet.Balance - walletTransaction.Amount;

                bool a = userWalletRepository.Update(sourceUserWalletUpdate, db);

                if (a == false)
                {
                    return false;
                }
                else { 
                UserWalletBO targetUserWalletUpdate = new UserWalletBO();
                    targetUserWalletUpdate.UserAuthId = targetUserWallet.UserAuthId;
                    targetUserWalletUpdate.WalletTypeId = targetUserWallet.WalletTypeId;
                    targetUserWalletUpdate.Balance = (decimal)targetUserWallet.Balance + walletTransaction.Amount;

                    userWalletRepository.Update(targetUserWalletUpdate, db);
                    return true;
                }
            }
            else 
            {
                using (db = new dbWorldCCityContext())
                {
                    using (var transaction = db.Database.BeginTransaction())
                    {
                        TblUserWallet sourceUserWallet = userWalletRepository.Get(sourceUserWalletBO, db);
                        TblUserWallet targetUserWallet = userWalletRepository.Get(targetUserWalletBO, db);

                        UserWalletBO sourceUserWalletUpdate = new UserWalletBO();
                        sourceUserWalletUpdate.UserAuthId = sourceUserWallet.UserAuthId;
                        sourceUserWalletUpdate.WalletTypeId = sourceUserWallet.WalletTypeId;
                        sourceUserWalletUpdate.Balance = (decimal)sourceUserWallet.Balance - walletTransaction.Amount;

                        bool a = userWalletRepository.Update(sourceUserWalletUpdate, db);

                        if (a == false)
                        {
                            return false;
                        }
                        else
                        {
                            UserWalletBO targetUserWalletUpdate = new UserWalletBO();
                            targetUserWalletUpdate.UserAuthId = targetUserWallet.UserAuthId;
                            targetUserWalletUpdate.WalletTypeId = targetUserWallet.WalletTypeId;
                            targetUserWalletUpdate.Balance = (decimal)targetUserWallet.Balance + walletTransaction.Amount;

                            userWalletRepository.Update(targetUserWalletUpdate, db);
                            transaction.Commit();

                            return true;
                        }
                    }
                }
            }
            
        }

    }
}
