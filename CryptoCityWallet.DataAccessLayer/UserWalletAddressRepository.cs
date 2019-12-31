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
   public class UserWalletAddressRepository
    {
        public bool Create(TblUserWalletAddress tblUserWalletAddress, dbWorldCCityContext db)
        {
            db.TblUserWalletAddress.Add(tblUserWalletAddress);
            db.SaveChanges();
            return true;
        }

        public List<TblUserWalletAddress> GetAll(TblUserAuth userAuth, dbWorldCCityContext db)
        {
            var _q = from a in db.TblUserWalletAddress
                     join b in db.TblWalletType on a.WalletTypeId equals b.Id
                     //where a.Id == (int)walletBO.WalletTypeId
                     select new TblUserWalletAddress
                     {
                         Id = a.Id,
                         Address = a.Address,
                         CreatedOn = a.CreatedOn,
                         UserAuthId = a.UserAuthId,
                         Balance = a.Balance,
                         Remarks = a.Remarks,
                         IsEnabled = a.IsEnabled,
                         WalletType = b
                     };

            List<TblUserWalletAddress> _r = _q.ToList<TblUserWalletAddress>();

            return _r;
        }
    }
}
