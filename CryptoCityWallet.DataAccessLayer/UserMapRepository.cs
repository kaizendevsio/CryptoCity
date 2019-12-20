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
    public class UserMapRepository
    {
        public bool Create(TblUserMap userMapQuery, dbWorldCCityContext db)
        {
            db.TblUserMap.Add(userMapQuery);
            db.SaveChanges();

            return true;

        }
        public TblUserMap Get(TblUserMap userMapQuery, dbWorldCCityContext db)
        {
            var _q = from a in db.TblUserMap
                     where a.Id == userMapQuery.Id || a.UserUid == userMapQuery.UserUid
                     join b in db.TblUserAuth on a.Id equals b.Id
                     select new TblUserMap
                     {
                         Id = a.Id,
                         CreatedOn = a.CreatedOn,
                         IsEnabled = a.IsEnabled,
                         ModifiedOn = a.ModifiedOn,
                         UserUid = a.UserUid,
                         Position = a.Position,
                         SponsorUserId = a.SponsorUserId,
                         UplineUserId = a.UplineUserId,
                         IdNavigation = a.IdNavigation
                     };

            TblUserMap _qRes = _q.FirstOrDefault<TblUserMap>();

            return _qRes;
        }   
    }
}
