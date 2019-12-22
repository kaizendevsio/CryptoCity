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

        public UserMapBO GetMap(TblUserAuth userAuth)
        {
            UserMapRepository userMapRepository = new UserMapRepository();
            dbWorldCCityContext db = new dbWorldCCityContext();

            var _q = from mapUserLeft in db.TblUserAuth
                     from mapUserRight in db.TblUserAuth

                     join mapLeft in db.TblUserMap on mapUserLeft.Id equals mapLeft.Id
                     join mapRight in db.TblUserMap on mapUserRight.Id equals mapRight.Id

                     join mapUserInfoLeft in db.TblUserInfo on mapUserLeft.UserInfoId equals mapUserInfoLeft.Id
                     join mapUserInfoRight in db.TblUserInfo on mapUserRight.UserInfoId equals mapUserInfoRight.Id
                     //join mapUserInfoCenter in db.TblUserInfo on userAuth.UserInfoId equals mapUserInfoCenter.Id


                     where mapLeft.UplineUserId == userAuth.Id && mapLeft.Position == 1 && mapRight.UplineUserId == userAuth.Id && mapRight.Position == 2

                     select new UserMapBO
                     {
                         name = userAuth.UserName,
                         //title = mapUserInfoCenter.Email,
                         UserAuth = userAuth,
                         children = new List<UserMapBO> { new UserMapBO { name = mapUserLeft.UserName, title = mapUserInfoLeft.Email, relationship = "101", UserAuth = new TblUserAuth { Id = mapUserLeft.Id, UserName = mapUserLeft.UserName } }, new UserMapBO { name = mapUserRight.UserName, title = mapUserInfoRight.Email, relationship = "101", UserAuth = new TblUserAuth { Id = mapUserRight.Id, UserName = mapUserRight.UserName } } },
                         relationship = "101"
                     };

            UserMapBO _qRes = _q.FirstOrDefault<UserMapBO>();

            if (_qRes != null)
            {
                UserMapBO _x = GetMap(_qRes.children[0].UserAuth);
                UserMapBO _y = GetMap(_qRes.children[1].UserAuth);
                _qRes.children[0].children = _x == null ? new List<UserMapBO>() : _x.children;
                _qRes.children[1].children = _y == null ? new List<UserMapBO>() : _y.children;
            }           

            return _qRes;
        }
    }
}
