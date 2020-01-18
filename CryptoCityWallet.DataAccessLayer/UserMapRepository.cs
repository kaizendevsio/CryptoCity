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
                     where a.Id == userMapQuery.Id || a.UserUid == userMapQuery.UserUid || a.UplineUserId == userMapQuery.UplineUserId
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
        private List<UserMapBO> GetMapChildren(TblUserAuth userAuth)
        {
            UserMapRepository userMapRepository = new UserMapRepository();
            UserInfoRepository userInfoRepository = new UserInfoRepository();
            UserBusinessPackageRepository userBusinessPackageRepository = new UserBusinessPackageRepository();

            using dbWorldCCityContext db = new dbWorldCCityContext();
            TblUserInfo userInfo = userInfoRepository.Get(userAuth, db);

            var _q = from a in db.TblUserMap
                     join b in db.TblUserAuth on a.Id equals b.Id
                     join c in db.TblUserInfo on b.UserInfoId equals c.Id

                     where a.UplineUserId == userAuth.Id
                     orderby a.Position ascending
                     select new TblUserMap
                     {
                         Id = a.Id,
                         CreatedOn = a.CreatedOn,
                         IsEnabled = a.IsEnabled,
                         Position = a.Position,
                         UplineUserId = a.UplineUserId,
                         IdNavigation = new TblUserAuth { Id = b.Id, CreatedOn = b.CreatedOn, IsEnabled = b.IsEnabled, UserName = b.UserName, UserAlias = b.UserAlias, UserInfo = c },
                     };

            List<TblUserMap> _qRes = _q.ToList();
            List<UserMapBO> userMapChildren = new List<UserMapBO>();

            for (int i = 0; i < _qRes.Count; i++)
            {
                UserMapBO userMap = new UserMapBO();
                List<TblUserBusinessPackage> userBusinessPackages = userBusinessPackageRepository.GetAll(_qRes[i].IdNavigation, db);
                userBusinessPackages = userBusinessPackages.FindAll(i => i.UserDepositRequest.DepositStatus == (short)DepositStatus.Paid);
                userMap.title = userBusinessPackages.Count > 0 ? @String.Format("BP ({0:#,##0.000})", userBusinessPackages.Sum(i => i.UserDepositRequest.Amount)) : "Inactive";
                userMap.name = _qRes[i].IdNavigation.UserName;
                userMap.relationship = "101";
                userMap.children = GetMapChildren(_qRes[i].IdNavigation);
                userMapChildren.Add(userMap);
            }

            return userMapChildren;
        }
        public UserMapBO GetMap(TblUserAuth userAuth)
        {
            using dbWorldCCityContext db = new dbWorldCCityContext();
            UserInfoRepository userInfoRepository = new UserInfoRepository();
            UserBusinessPackageRepository userBusinessPackageRepository = new UserBusinessPackageRepository();

            TblUserInfo userInfo = userInfoRepository.Get(userAuth, db);
            List<TblUserBusinessPackage> userBusinessPackages = userBusinessPackageRepository.GetAll(userAuth, db);
            userBusinessPackages = userBusinessPackages.FindAll(i => i.UserDepositRequest.DepositStatus == (short)DepositStatus.Paid);

            UserMapBO userMapBO = new UserMapBO
            {
                title = userBusinessPackages.Count > 0 ? @String.Format("BP ({0:#,##0.000})", userBusinessPackages.Sum(i => i.UserDepositRequest.Amount)) : "Inactive",
                name = userAuth.UserName,
                relationship = "101",
                children = GetMapChildren(userAuth)
            };

            return userMapBO;
        }
        public List<UnilevelMapBO> GetUnilevelChildren(TblUserAuth userAuth, dbWorldCCityContext db)
        {
            var _q = from a in db.TblUserMap
                     join b in db.TblUserAuth on a.Id equals b.Id
                     join c in db.TblUserInfo on b.UserInfoId equals c.Id

                     where a.SponsorUserId == userAuth.Id
                     orderby a.Id ascending
                     select new UnilevelMapBO
                     {
                         Text = b.UserName,
                         MapBO = a
                     };

            List<UnilevelMapBO> _qRes = _q.ToList<UnilevelMapBO>();

            if (_qRes.Count != 0)
            {
                for (int i = 0; i < _qRes.Count; i++)
                {
                    List<UnilevelMapBO> _p = GetUnilevelChildren(new TblUserAuth { Id = (long)_qRes[i].MapBO.Id }, db);
                    _qRes[i].Nodes = _p.Count > 0 ? _p : null;
                }

            }

            return _qRes;
        }
        public UnilevelMapBO GetUnilevel(TblUserAuth userAuth, dbWorldCCityContext db)
        {
            List<UnilevelMapBO> _o = GetUnilevelChildren(userAuth, db);
            UnilevelMapBO unilevelMapBO = new UnilevelMapBO()
            {
                Text = userAuth.UserName,
                Nodes = _o.Count > 0 ? _o : null
            };
            return unilevelMapBO;
        }

    }
}
