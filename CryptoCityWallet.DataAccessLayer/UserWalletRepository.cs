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
   public class UserWalletRepository
    {
        public bool Create(TblUserAuth userAuth, dbWorldCCityContext db)
        {
            // ENUMERATE ALL WALELT TYPES
            WalletTypeRepository walletTypeRepository = new WalletTypeRepository();

            List<TblWalletType> _qWalletTypeRes = walletTypeRepository.GetAll(db);

            for (int i = 0; i < _qWalletTypeRes.Count; i++)
            {
                var _userWallet = new TblUserWallet();

                _userWallet.UserAuthId = userAuth.Id;
                _userWallet.WalletTypeId = _qWalletTypeRes[i].Id;
                _userWallet.Balance = 0.0m;
                _userWallet.IsEnabled = true;

                db.TblUserWallet.Add(_userWallet);
            }

            db.SaveChanges();
            return true;
        }

        public TblUserWallet Get(UserWalletBO userWallet, dbWorldCCityContext db)
        {
            var _q = from a in db.TblUserWallet
                     join b in db.TblWalletType on a.WalletTypeId equals b.Id
                     where a.UserAuthId == userWallet.UserAuthId && a.WalletTypeId == userWallet.WalletTypeId && a.IsEnabled == true && b.IsEnabled == true
                     select new TblUserWallet
                     {
                         Id = a.Id,
                         WalletType = b,
                         Balance = a.Balance,
                         UserAuthId = a.UserAuthId,
                         WalletTypeId = a.WalletTypeId,
                         CreatedOn = a.CreatedOn,
                         IsEnabled = a.IsEnabled,
                         ModifiedOn = a.ModifiedOn
                     };

            TblUserWallet _qRes = _q.FirstOrDefault<TblUserWallet>();

            return _qRes;

            //TblUserWallet tblUserWallet = db.TblUserWallet.FirstOrDefault(item => item.UserAuthId == userWallet.UserAuthId && item.WalletTypeId == userWallet.WalletTypeId);
            //return tblUserWallet;
        }

        public List<TblUserWallet> GetAll(TblUserAuth userAuth, dbWorldCCityContext db)
        {
            var _qUi = from a in db.TblUserWallet
                       join b in db.TblWalletType on a.WalletTypeId equals b.Id
                       where a.UserAuthId == userAuth.Id
                       select new TblUserWallet
                       {
                           Id = a.Id,
                           UserAuthId = a.UserAuthId,
                           WalletTypeId = a.WalletTypeId,
                           IsEnabled = a.IsEnabled,
                           Balance = a.Balance,
                           CreatedOn = a.CreatedOn,
                           ModifiedOn = a.ModifiedOn,
                           WalletType = a.WalletType
                       };

            List<TblUserWallet> userWallet = _qUi.ToList<TblUserWallet>();

            return userWallet;
        }

        public UserWalletBO GetBO(UserWalletBO userWallet, dbWorldCCityContext db)
        {
            var _qUi = from a in db.TblUserWallet
                       join b in db.TblWalletType on a.WalletTypeId equals b.Id
                       join c in db.TblExchangeRate on a.WalletType.CurrencyId equals c.SourceCurrencyId
                       where a.UserAuthId == userWallet.UserAuthId && a.WalletTypeId == userWallet.WalletTypeId && a.IsEnabled == true && b.IsEnabled == true
                       select new UserWalletBO
                       {
                           Id = a.Id,
                           UserAuthId = a.UserAuthId,
                           WalletTypeId = a.WalletTypeId,
                           IsEnabled = a.IsEnabled,
                           Balance = a.Balance,
                           BalanceFiat = a.Balance * c.Value,
                           CreatedOn = a.CreatedOn,
                           ModifiedOn = a.ModifiedOn,
                           WalletType = a.WalletType,
                           WalletName = a.WalletType.Name,
                           WalletCode = a.WalletType.Code
                       };

            UserWalletBO _userWalletResult = _qUi.FirstOrDefault<UserWalletBO>();

            return _userWalletResult;
        }
        public List<UserWalletBO> GetAllBO(TblUserAuth userAuth, dbWorldCCityContext db)
        {
            var _qUi = from a in db.TblUserWallet
                       join b in db.TblWalletType on a.WalletTypeId equals b.Id
                       join c in db.TblExchangeRate on a.WalletType.CurrencyId equals c.SourceCurrencyId
                       where a.UserAuthId == userAuth.Id && b.IsEnabled == true && a.IsEnabled == true
                       select new UserWalletBO
                       {
                           Id = a.Id,
                           UserAuthId = a.UserAuthId,
                           WalletTypeId = a.WalletTypeId,
                           IsEnabled = a.IsEnabled,
                           Balance = a.Balance,
                           BalanceFiat = a.Balance * c.Value,
                           CreatedOn = a.CreatedOn,
                           ModifiedOn = a.ModifiedOn,
                           WalletType = a.WalletType,
                           WalletName = a.WalletType.Name,
                           WalletCode = a.WalletType.Code
                       };

            List<UserWalletBO> userWallet = _qUi.ToList<UserWalletBO>();

            return userWallet;
        }

        public bool Update(UserWalletBO userWallet, dbWorldCCityContext db)
        {
            UserWalletTransactionRepository userWalletTransactionRepository = new UserWalletTransactionRepository();
            TblUserWallet tblUserWallet = db.TblUserWallet.FirstOrDefault(item => item.UserAuthId == userWallet.UserAuthId && item.WalletTypeId == userWallet.WalletTypeId);

            UserWalletBO UWT_entry = new UserWalletBO();
            UWT_entry.Id = tblUserWallet.Id;
            UWT_entry.Balance = tblUserWallet.Balance;
            UWT_entry.UserAuthId = tblUserWallet.UserAuthId;
            UWT_entry.IsEnabled = tblUserWallet.IsEnabled;

            WalletTransactionBO walletTransaction = new WalletTransactionBO();
            walletTransaction.Amount = userWallet.Balance - UWT_entry.Balance;

            bool y = userWalletTransactionRepository.Create(UWT_entry, walletTransaction, db);

            if (y == false)
            {
                return false;
            }
            else
            {
                if (userWallet.IsEnabled == false)
                {
                    return false;
                }
                tblUserWallet.Balance = userWallet.Balance;
                tblUserWallet.ModifiedOn = DateTime.Now;

                db.TblUserWallet.Update(tblUserWallet);
                db.SaveChanges();
                return true;
            }
        }
    }
}
