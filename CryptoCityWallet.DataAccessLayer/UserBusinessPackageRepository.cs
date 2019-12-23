using System.Text;
using System.Linq;
using System.Security.Cryptography;
using CryptoCityWallet.Entities.DTO;
using CryptoCityWallet.Entities.BO;
using CryptoCityWallet.Entities.Enums;
using AutoMapper;
using System;

namespace CryptoCityWallet.DataAccessLayer
{
   public class UserBusinessPackageRepository
    {
        public bool Create(TblUserBusinessPackage tblUserBusinessPackage, dbWorldCCityContext db)
        {
            db.TblUserBusinessPackage.Add(tblUserBusinessPackage);
            db.SaveChanges();

            return true;
        }
    }
}
