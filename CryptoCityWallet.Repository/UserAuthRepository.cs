using System.Text;
using System.Linq;
using System.Security.Cryptography;
using CryptoCityWallet.DTO;
using CryptoCityWallet.BO;
using CryptoCityWallet.Enums;

namespace CryptoCityWallet.Repository
{
    public class UserAuthRepository
    {
        public TblUserAuth Create(UserBO userBO, TblUserInfo userInfo, dbWorldCCityContext db)
        {
            TblUserAuth _userAuth = new TblUserAuth();
            byte[] _passwordByte = Encoding.ASCII.GetBytes(userBO.PasswordString);
            byte[] _hashPasswordByte;
            SHA512 shaM = new SHA512Managed();
            _hashPasswordByte = shaM.ComputeHash(_passwordByte);
            string base64Password = System.Convert.ToBase64String(_hashPasswordByte);

            _userAuth.UserName = userBO.UserName;
            _userAuth.PasswordByte = _hashPasswordByte;
            _userAuth.IsTempPassword = false;
            _userAuth.IsEnabled = true;
            _userAuth.LoginStatus = 1;
            _userAuth.UserInfoId = userInfo.Id;

            db.TblUserAuth.Add(_userAuth);

            db.SaveChanges();

            return _userAuth;

        }

        public TblUserAuth Get(UserBO userBO, dbWorldCCityContext db)
        {
            byte[] _passwordByte = Encoding.ASCII.GetBytes(userBO.PasswordString);
            byte[] _hashPasswordByte;
            SHA512 shaM = new SHA512Managed();
            _hashPasswordByte = shaM.ComputeHash(_passwordByte);
            string base64Password = System.Convert.ToBase64String(_hashPasswordByte);

            var _qAuth = from a in db.TblUserAuth
                         where a.UserName == userBO.UserName && a.PasswordByte == _hashPasswordByte
                         select new TblUserAuth
                         {
                             UserName = a.UserName,
                             PasswordByte = a.PasswordByte, 
                             IsEnabled = a.IsEnabled,
                             UserInfoId = a.UserInfoId,
                             Id = a.Id
                         };

            TblUserAuth tblUserAuth = _qAuth.FirstOrDefault();

            if (tblUserAuth == null)
            {
                var _qAuth2 = from a in db.TblUserAuth
                             where a.UserName == userBO.UserName
                             select new TblUserAuth
                             {
                                 UserName = a.UserName,
                                 PasswordByte = a.PasswordByte,
                                 IsEnabled = a.IsEnabled,
                                 UserInfoId = a.UserInfoId,
                                 Id = a.Id
                             };
                tblUserAuth = _qAuth2.FirstOrDefault();

                UserAuthHistoryRepository userAuthHistoryRepository = new UserAuthHistoryRepository();
                userAuthHistoryRepository.Create((int)AuthStatus.Invalid_User, tblUserAuth, db);
                throw new System.ArgumentException("User Authentication Failed");
            }
            else
            {         
                UserAuthHistoryRepository userAuthHistoryRepository = new UserAuthHistoryRepository();
                userAuthHistoryRepository.Create((int)AuthStatus.Success, tblUserAuth, db);
                return tblUserAuth;
            }
           
        }
    }
}
