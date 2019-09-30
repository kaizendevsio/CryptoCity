using System;
using System.Text;
using System.Linq;
using System.Security.Cryptography;
using CryptoCityWallet.DTO;
using CryptoCityWallet.BO;
using CryptoCityWallet.Repository;
using System.Collections.Generic;

namespace CryptoCityWallet.Repository
{
   public class UserWalletRepository
    {
        public bool Create(TblUserAuth userAuth, dbWorldCCityContext db)
        {
            // ENUMERATE ALL WALELT TYPES
            var _q = from a in db.TblWalletType
                     where a.Type == 1
                     select new TblWalletType
                     {
                         Name = a.Name,
                         Desc = a.Desc,
                         Type = a.Type,
                         Code = a.Code,
                         Id = a.Id
                     };

            List<TblWalletType> _qWalletTypeRes = _q.ToList<TblWalletType>();

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

        public List<TblUserWallet> Get(TblUserAuth userAuth, dbWorldCCityContext db)
        {
            var _qUi = from a in db.TblUserWallet
                       where a.UserAuthId == userAuth.Id
                       select new TblUserWallet
                       {
                           Id = a.Id,
                           UserAuthId = a.UserAuthId,
                           WalletTypeId = a.WalletTypeId,
                           IsEnabled = a.IsEnabled,
                           Balance = a.Balance,
                           CreatedOn = a.CreatedOn,
                           ModifiedOn = a.ModifiedOn
                       };

            List<TblUserWallet> userWallet = _qUi.ToList<TblUserWallet>();

            return userWallet;
        }
    }
}
