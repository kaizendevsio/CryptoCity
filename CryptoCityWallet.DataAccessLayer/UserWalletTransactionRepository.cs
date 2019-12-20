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
    }
}
