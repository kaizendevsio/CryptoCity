using CryptoCityWallet.Entities.DTO;
using CryptoCityWallet.Entities.BO;
using CryptoCityWallet.Entities.Enums;
using CryptoCityWallet.DataAccessLayer;
using System.Collections.Generic;
using System;
using SendGrid;
using System.Threading.Tasks;

namespace CryptoCityWallet.AppService
{
    public class UserAppService
    {

        public UserResponseBO Authenticate(UserBO userBO)
        {
            using (var db = new dbWorldCCityContext())
            {
                UserAuthRepository userAuthRepository = new UserAuthRepository();
                TblUserAuth userAuth = userAuthRepository.Get(userBO, db);

                UserInfoRepository userInfoRepository = new UserInfoRepository();
                TblUserInfo userInfo = userInfoRepository.Get(userAuth, db);

                UserWalletRepository userWalletRepository = new UserWalletRepository();
                List<UserWalletBO> userWallet = userWalletRepository.GetAllBO(userAuth, db);

                UserRoleRepository userRoleRepository = new UserRoleRepository();
                TblUserRole userRole = userRoleRepository.Get(userAuth, db);

                UserResponseBO userAuthResponse = new UserResponseBO();

                userAuthResponse.UserInfo = userInfo;
                userAuthResponse.UserWallet = userWallet;
                userAuthResponse.UserAuth = userAuth;
                userAuthResponse.UserRole = userRole;

                return userAuthResponse;
            }
        }
        public async Task<bool> CreateAsync(UserBO userBO, dbWorldCCityContext db = null)
        {
            if (db != null)
            {
                UserInfoRepository userInfoRepository = new UserInfoRepository();

                TblUserInfo userInfo = userInfoRepository.Create(userBO, db);
                userBO.Uid = userInfo.Uid;

                UserAuthRepository userAuthRepository = new UserAuthRepository();
                TblUserAuth userAuth = userAuthRepository.Create(userBO, userInfo, db);

                UserRoleRepository userRoleRepository = new UserRoleRepository();
                userRoleRepository.Create(userAuth, db);

                // CREATE USER WALLETS
                UserWalletAppService userWallet = new UserWalletAppService();
                userWallet.Create(userAuth, db);

                ExternalRecordsRepository externalRecordsRepository = new ExternalRecordsRepository();
                externalRecordsRepository.CreateUserVolume(userAuth,db);

                UserWalletAddressAppService userWalletAddressAppService = new UserWalletAddressAppService();
                bool r = await userWalletAddressAppService.Create(userAuth,"BTC");

                UserMapAppService userMapAppService = new UserMapAppService();
                userMapAppService.Create(userBO, userAuth, db);

                return true;
            }
            else
            {
                using (db = new dbWorldCCityContext())
                {
                    using (var transaction = db.Database.BeginTransaction())
                    {
                        UserInfoRepository userInfoRepository = new UserInfoRepository();
                        MailAppService mailAppService = new MailAppService();

                        TblUserInfo userInfo = userInfoRepository.Create(userBO, db);
                        userBO.Uid = userInfo.Uid;

                        UserAuthRepository userAuthRepository = new UserAuthRepository();
                        TblUserAuth userAuth = userAuthRepository.Create(userBO, userInfo, db);

                        UserRoleRepository userRoleRepository = new UserRoleRepository();
                        userRoleRepository.Create(userAuth, db);

                        // CREATE USER WALLETS
                        UserWalletAppService userWallet = new UserWalletAppService();
                        userWallet.Create(userAuth, db);

                        ExternalRecordsRepository externalRecordsRepository = new ExternalRecordsRepository();
                        externalRecordsRepository.CreateUserVolume(userAuth, db);

                        UserWalletAddressAppService userWalletAddressAppService = new UserWalletAddressAppService();
                        bool r = await userWalletAddressAppService.Create(userAuth, "BTC", "", db);

                        UserMapAppService userMapAppService = new UserMapAppService();
                        userMapAppService.Create(userBO, userAuth, db);

                        transaction.Commit();
                        return true;
                    }
                }
            }

        }
        public TblUserInfo Get(TblUserAuth userAuth)
        {
            using (var db = new dbWorldCCityContext())
            {
                using (var transaction = db.Database.BeginTransaction())
                {

                    UserInfoRepository userInfoRepository = new UserInfoRepository();
                    TblUserInfo userInfo = userInfoRepository.Get(userAuth, db);

                    return userInfo;
                }
            }
        }
        public TblUserRole GetUserRole(TblUserAuth userAuth)
        {
            using (var db = new dbWorldCCityContext())
            {
                using (var transaction = db.Database.BeginTransaction())
                {

                    UserRoleRepository userRoleRepository = new UserRoleRepository();
                    TblUserRole userRole = userRoleRepository.Get(userAuth, db);

                    return userRole;
                }
            }
        }
        public bool Activate()
        {
            return true;
        }
        public bool StructureMapTesting(StructureMapInjection structureMap)
        {
            UserAppService userAppService = new UserAppService();

            int BinaryCount = structureMap.BinarySponsorDataArray.Count;
            int UnilevelCount = structureMap.DirectSponsorDataArray.Count;
            TblUserInfo userInfoBinarySponsor = new TblUserInfo();
            TblUserInfo userInfoDirectSponsor = new TblUserInfo();
            TblUserAuth userAuth = new TblUserAuth();

            using (var db = new dbWorldCCityContext())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    for (int i = 0; i < BinaryCount; i++)
                    {
                        if (structureMap.BinarySponsorDataArray[i].Parent == 0)
                        {
                            userInfoBinarySponsor = new TblUserInfo();
                        }
                        else
                        {
                            userAuth.UserName = structureMap.BinarySponsorDataArray[structureMap.BinarySponsorDataArray[i].Parent - 1].Name;
                            userInfoBinarySponsor = userAppService.Get(userAuth);
                        }
                        if (structureMap.DirectSponsorDataArray[i].Parent == 0)
                        {
                            userInfoDirectSponsor = new TblUserInfo();
                        }
                        else
                        {
                            userAuth.UserName = structureMap.DirectSponsorDataArray[structureMap.DirectSponsorDataArray[i].Parent - 1].Name;
                            userInfoDirectSponsor = userAppService.Get(userAuth);
                        }

                        UserBO user = new UserBO();
                        user.FirstName = structureMap.BinarySponsorDataArray[i].Name;
                        user.LastName = "User";
                        user.UserName = structureMap.BinarySponsorDataArray[i].Name;
                        user.Email = String.Format("{0}{1}", structureMap.BinarySponsorDataArray[i].Name, "@mail.com");
                        user.PasswordString = "123";
                        user.DirectSponsorID = userInfoDirectSponsor.Uid;
                        user.BinarySponsorID = userInfoBinarySponsor.Uid;
                        user.BinaryPosition = structureMap.BinarySponsorDataArray[i].Comments;

                        userAppService.CreateAsync(user);
                    }

                    transaction.Commit();
                }
            }



            return true;
        }
    }
}
