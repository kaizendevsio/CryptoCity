using CryptoCityWallet.DTO;
using CryptoCityWallet.BO;
using CryptoCityWallet.Repository;
using CryptoCityWallet.Enums;
using System.Collections.Generic;

namespace CryptoCityWallet.AppService
{
    public class UserAppService
    {

        public UserAuthResponse Authenticate(UserBO userBO)
        {
            using (var db = new dbWorldCCityContext())
            {
                UserAuthRepository userAuthRepository = new UserAuthRepository();
                TblUserAuth userAuth = userAuthRepository.Get(userBO, db);

                UserInfoRepository userInfoRepository = new UserInfoRepository();
                TblUserInfo userInfo = userInfoRepository.Get(userAuth, db);

                UserWalletRepository userWalletRepository = new UserWalletRepository();
                List<UserWalletBO> userWallet = userWalletRepository.GetBO(userAuth, db);

                UserAuthResponse userAuthResponse = new UserAuthResponse();

                userAuthResponse.UserInfo = userInfo;
                userAuthResponse.UserWallet = userWallet;
                userAuthResponse.UserAuth = userAuth;

                return userAuthResponse;
            }
        }

        public bool Create(UserBO userBO)
        {
            using (var db = new dbWorldCCityContext())
            {
                using (var transaction = db.Database.BeginTransaction())
                {

                    UserInfoRepository userInfoRepository = new UserInfoRepository();
                    TblUserInfo userInfo = userInfoRepository.Create(userBO, db);

                    UserAuthRepository userAuthRepository = new UserAuthRepository();
                    TblUserAuth userAuth = userAuthRepository.Create(userBO, userInfo, db);

                    // CREATE USER WALLETS
                    UserWalletAppService userWallet = new UserWalletAppService();
                    userWallet.Create(userAuth, db);

                    transaction.Commit();

                    return true;
                }
            }
        }
    }
}
