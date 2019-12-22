﻿using System;
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
                directSponsorUser = new TblUserAuth();
                directSponsorUser.Id = 1;
            }
            if (binarySponsorUser == null)
            {
                binarySponsorUser = new TblUserAuth();
                binarySponsorUser.Id = 1;
            }

            TblUserMap userMap = new TblUserMap();
            userMap.Id = userAuth.Id;
            userMap.SponsorUserId = directSponsorUser.Id;
            userMap.UplineUserId = binarySponsorUser.Id;
            userMap.Position = (short)Convert.ToInt32(userBO.BinaryPosition);
            userMap.UserUid = userBO.Uid;

           return userMapRepository.Create(userMap,db);
        }

        public UserMapBO Get(TblUserAuth userAuth, dbWorldCCityContext db = null)
        {
            if (db != null)
            {
                UserMapRepository userMapRepository = new UserMapRepository();
                return userMapRepository.GetMap(userAuth);
            }
            else
            {
                using (db = new dbWorldCCityContext())
                {
                    using (var transaction = db.Database.BeginTransaction())
                    {
                        UserMapRepository userMapRepository = new UserMapRepository();
                        UserInfoRepository userInfoRepository = new UserInfoRepository();

                        UserMapBO userMap = userMapRepository.GetMap(userAuth);
                        userMap.title = userInfoRepository.Get(userAuth, db).Email;
                        return userMap;
                    }
                }
            }
        }
    }
}
