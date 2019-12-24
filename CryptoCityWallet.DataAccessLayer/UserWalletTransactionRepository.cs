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
    public class UserWalletTransactionRepository
    {
        public bool Create(UserWalletBO userWallet, WalletTransactionBO walletTransaction, dbWorldCCityContext db)
        {
            TblUserWalletTransaction userWalletTransaction = new TblUserWalletTransaction();
            userWalletTransaction.UserAuthId = userWallet.UserAuthId;
            userWalletTransaction.SourceUserWalletId = userWallet.Id;
            userWalletTransaction.Amount = (decimal)walletTransaction.Amount;
            userWalletTransaction.CreatedOn = DateTime.Now;
            userWalletTransaction.RunningBalance = userWallet.Balance;

            if (userWallet.IsEnabled == true)
            {
                userWalletTransaction.Remarks = GenericStatusType.Approved.ToString();
            }
            else
            {
                userWalletTransaction.Remarks = GenericStatusType.Disabled.ToString();
            }


            db.TblUserWalletTransaction.Add(userWalletTransaction);
            db.SaveChanges();
            return true;
        }

        public List<TblUserWalletTransaction> GetAll(TblUserAuth userAuth, dbWorldCCityContext db)
        {
            var _q = from a in db.TblUserWalletTransaction
                     join b in db.TblUserWallet on a.SourceUserWalletId equals b.Id
                     join c in db.TblWalletType on b.WalletTypeId equals c.Id
                     where a.UserAuthId == userAuth.Id
                     select new TblUserWalletTransaction
                     {
                        Id = a.Id,
                        CreatedOn = a.CreatedOn,
                        Amount = a.Amount,
                        IsEnabled = a.IsEnabled,
                        ModifiedOn = a.ModifiedOn,
                        Remarks = a.Remarks,
                        RunningBalance = a.RunningBalance,
                        SourceUserWallet = new TblUserWallet { Id = b.Id, Balance = b.Balance, WalletType = c, IsEnabled = b.IsEnabled, CreatedOn = b.CreatedOn}
                     };

            List<TblUserWalletTransaction> userWalletTransactions = _q.ToList<TblUserWalletTransaction>();

            return userWalletTransactions;
        }
    }
}
