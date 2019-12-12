using System.Text;
using System.Linq;
using System.Security.Cryptography;
using CryptoCityWallet.Entities.DTO;
using CryptoCityWallet.Entities.BO;
using CryptoCityWallet.Entities.Enums;

namespace CryptoCityWallet.DataAccessLayer
{
   public class UserRoleRepository
    {
        public TblUserRole Get(TblUserAuth userAuth, dbWorldCCityContext db)
        {
            var _qObj= from a in db.TblUserRole
                         where a.UserAuthId == userAuth.Id
                         select new TblUserRole
                         {
                             AccessRole = a.AccessRole,
                             IsEnabled = a.IsEnabled,
                             CreatedOn = a.CreatedOn,
                             Id = a.Id
                         };

            TblUserRole userRole = _qObj.FirstOrDefault();

            return userRole;
        }

        public TblUserRole Create(TblUserAuth userAuth, dbWorldCCityContext db)
        {
            TblUserRole userRole = new TblUserRole();
            userRole.UserAuthId = userAuth.Id;
            userRole.IsEnabled = true;
            userRole.AccessRole = UserRole.Client.ToString();
            
            db.TblUserRole.Add(userRole);
            db.SaveChanges();

            return userRole;
        }
    }
}
