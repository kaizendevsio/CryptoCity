using System;
using CryptoCityWallet.Entities.DTO;
using CryptoCityWallet.Entities.BO;
using CryptoCityWallet.Entities.Enums;
using CryptoCityWallet.DataAccessLayer;
using System.Collections.Generic;


namespace CryptoCityWallet.AppService
{
    public class UserMapAppService
    {
        public bool Create(UserBO userBO, TblUserAuth userAuth, dbWorldCCityContext db)
        {
            UserMapRepository userMapRepository = new UserMapRepository();
            UserAuthRepository userAuthRepository = new UserAuthRepository();

            TblUserAuth directSponsorUser = userAuthRepository.GetByUID(userBO.DirectSponsorID, db);
            TblUserAuth binarySponsorUser = userAuthRepository.GetByUID(userBO.BinarySponsorID, db);

            if (directSponsorUser == null)
            {
                directSponsorUser = new TblUserAuth
                {
                    Id = 1
                };
            }
            if (binarySponsorUser == null)
            {
                binarySponsorUser = new TblUserAuth
                {
                    Id = 1
                };
            }

            TblUserMap userMap = new TblUserMap
            {
                Id = userAuth.Id,
                SponsorUserId = directSponsorUser.Id,
                UplineUserId = binarySponsorUser.Id,
                Position = (short)Convert.ToInt32(userBO.BinaryPosition),
                UserUid = userBO.Uid
            };

            return userMapRepository.Create(userMap, db);
        }

        public UserMapBO GetBinary(TblUserAuth userAuth, dbWorldCCityContext db = null)
        {
            if (db != null)
            {
                using var transaction = db.Database.BeginTransaction();
                UserMapRepository userMapRepository = new UserMapRepository();
                UserMapBO userMap = userMapRepository.GetMap(userAuth);

                return userMap;
            }
            else
            {
                using (db = new dbWorldCCityContext())
                {
                    using var transaction = db.Database.BeginTransaction();
                    UserMapRepository userMapRepository = new UserMapRepository();
                    UserMapBO userMap = userMapRepository.GetMap(userAuth);

                    return userMap;
                }
            }
        }
        public UnilevelMapBO GetUnilevel(TblUserAuth userAuth, dbWorldCCityContext db = null)
        {
            if (db != null)
            {
                UserMapRepository userMapRepository = new UserMapRepository();
                return userMapRepository.GetUnilevel(userAuth, db);
            }
            else
            {
                using (db = new dbWorldCCityContext())
                {
                    UserMapRepository userMapRepository = new UserMapRepository();
                    return userMapRepository.GetUnilevel(userAuth, db);
                }
            }
        }
        public bool Validate(UserBO userBO, dbWorldCCityContext db)
        {
            UserAuthRepository userAuthRepository = new UserAuthRepository();
            UserMapRepository userMapRepository = new UserMapRepository();

            if (userBO.BinarySponsorID != null)
            {
                TblUserAuth binarySponsorUser = userAuthRepository.GetByUID(userBO.BinarySponsorID, db);

                if (binarySponsorUser == null)
                {
                    throw new ArgumentException("Binary Sponsor ID is invalid");
                }
                else
                {
                    List<TblUserMap> _userMapList = userMapRepository.GetAll(new TblUserMap { UplineUserId = binarySponsorUser.Id, UserUid = ""}, db).FindAll(i => i.Position == short.Parse(userBO.BinaryPosition));
                    if (_userMapList.Count > 0)
                    {
                        throw new ArgumentException("Binary position is already taken");
                    }
                }
            }

            if (userBO.DirectSponsorID != null)
            {
                TblUserAuth directSponsorUser = userAuthRepository.GetByUID(userBO.DirectSponsorID, db);

                if (directSponsorUser == null)
                {
                    throw new ArgumentException("Introducer ID is invalid");
                }
            }



            return true;

        }
    }
}

