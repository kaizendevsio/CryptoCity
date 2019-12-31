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
        public List<TblUserMap> GetAll(TblUserMap userMapQuery, dbWorldCCityContext db)
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

            List<TblUserMap> _qRes = _q.ToList<TblUserMap>();

            return _qRes;
        }
        public UserMapBO GetMap(TblUserAuth userAuth, int position = 1 )
        {
            UserMapRepository userMapRepository = new UserMapRepository();
            dbWorldCCityContext db = new dbWorldCCityContext();

            var _q = from mapUserAuthLeft in db.TblUserAuth
                     from mapUserAuthRight in db.TblUserAuth

                     join mapUserLeft in db.TblUserMap on mapUserAuthLeft.Id equals mapUserLeft.Id
                     join mapUserInfoLeft in db.TblUserInfo on mapUserAuthLeft.UserInfoId equals mapUserInfoLeft.Id

                     join mapUserRight in db.TblUserMap on mapUserAuthRight.Id equals mapUserRight.Id
                     join mapUserInfoRight in db.TblUserInfo on mapUserAuthRight.UserInfoId equals mapUserInfoRight.Id


                     where mapUserLeft.UplineUserId == userAuth.Id && mapUserLeft.Position == 1 && mapUserRight.UplineUserId == userAuth.Id && mapUserRight.Position == 2

                     select new UserMapBO
                     {
                         name = userAuth.UserName,
                         relationship = "101",
                         children = new List<UserMapBO> { new UserMapBO { title = String.Format("{0} {1}", mapUserInfoLeft.FirstName, mapUserInfoLeft.LastName), name = mapUserAuthLeft.UserName}, new UserMapBO { title = String.Format("{0} {1}", mapUserInfoRight.FirstName, mapUserInfoRight.LastName), name = mapUserAuthRight.UserName } }

                     };

            UserMapBO _qRes = _q.FirstOrDefault();

            UserMapBO userMapBO = new UserMapBO();



            if (_qRes != null)
            {
                //UserMapBO _x = GetMap(_qRes.children[0].UserAuth);
                //UserMapBO _y = GetMap(_qRes.children[1].UserAuth);
                //_qRes.children[0].children = _x == null ? new List<UserMapBO>() : _x.children;
                //_qRes.children[1].children = _y == null ? new List<UserMapBO>() : _y.children;
            }

            return _qRes;
        }
    }
}
