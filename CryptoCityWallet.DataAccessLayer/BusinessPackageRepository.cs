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
   public class BusinessPackageRepository
    {
        public TblBusinessPackage Get(TblBusinessPackage businessPackageQuery, dbWorldCCityContext db)
        {
            TblBusinessPackage businessPackage = db.TblBusinessPackage.FirstOrDefault(item => item.Id == businessPackageQuery.Id || item.PackageCode == businessPackageQuery.PackageCode);
            return businessPackage;
        }
    }
}
