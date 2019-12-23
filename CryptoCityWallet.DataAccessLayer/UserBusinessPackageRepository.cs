using System.Text;
using System.Linq;
using System.Security.Cryptography;
using CryptoCityWallet.Entities.DTO;
using CryptoCityWallet.Entities.BO;
using CryptoCityWallet.Entities.Enums;
using AutoMapper;
using System;
using System.Collections.Generic;

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

        public List<TblUserBusinessPackage> GetAll(TblUserAuth userAuth, dbWorldCCityContext db)
        {
            var _qUi = from a in db.TblUserAuth
                       join b in db.TblUserBusinessPackage on a.Id equals b.UserAuthId
                       join c in db.TblUserDepositRequest on b.UserDepositRequestId equals c.Id
                       join d in db.TblBusinessPackage on b.BusinessPackageId equals d.Id
                       join e in db.TblBusinessPackageType on d.PackageTypeId equals e.Id
                       join f in db.TblCurrency on c.SourceCurrencyId equals f.Id
                       //join g in db.TblWalletType on c.TargetWalletTypeId equals g.Id

                       where a.Id == userAuth.Id
                       select new TblUserBusinessPackage
                       {
                         Id = b.Id,
                         ActivationDate = b.ActivationDate,
                         UserDepositRequest = new TblUserDepositRequest { Address = c.Address, Amount = c.Amount, CreatedOn = c.CreatedOn, DepositStatus = c.DepositStatus, ExpiryDate = c.ExpiryDate, Id = c.Id, IsEnabled = c.IsEnabled, Remarks = c.Remarks, SourceCurrency = f},
                         IsEnabled = b.IsEnabled,
                         CreatedOn = b.CreatedOn,
                         PackageStatus = b.PackageStatus,
                         CancellationDate = b.CancellationDate,
                         BusinessPackage =  new TblBusinessPackage { PackageType = e, PackageName = d.PackageName, PackageCode = d.PackageCode, Id = d.Id, CreatedOn = d.CreatedOn, IsEnabled = d.IsEnabled, ValueFrom = d.ValueFrom, ValueTo = d.ValueTo, PackageDescription = d.PackageDescription}
                       };

            List<TblUserBusinessPackage> _ubp = _qUi.ToList<TblUserBusinessPackage>();

            return _ubp;
        }
    }
}
