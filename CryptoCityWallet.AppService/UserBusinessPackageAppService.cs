using System;
using System.Collections.Generic;
using System.Text;
using CryptoCityWallet.Entities.DTO;
using CryptoCityWallet.Entities.BO;
using CryptoCityWallet.Entities.Enums;
using CryptoCityWallet.DataAccessLayer;

namespace CryptoCityWallet.AppService
{
   public class UserBusinessPackageAppService
    {
        public bool Create(UserBusinessPackageBO userBusinessPackage, dbWorldCCityContext db = null)
        {
            if (db != null)
            {
                WalletTypeRepository walletTypeRepository = new WalletTypeRepository();
                TblWalletType walletType = walletTypeRepository.Get(new UserWalletBO { WalletCode = userBusinessPackage.FromWalletCode }, db);

                UserWalletAppService userWalletAppService = new UserWalletAppService();
                TblUserWallet userWallet = userWalletAppService.GetSingle(new TblUserAuth { Id = userBusinessPackage.Id }, walletType);

                CurrencyTypeRepository currencyTypeRepository = new CurrencyTypeRepository();
                TblCurrency currency = currencyTypeRepository.Get(new TblCurrency { CurrencyIsoCode3 = userBusinessPackage.FromCurrencyIso3 }, db);

                if (userWallet.Balance >= userBusinessPackage.AmountPaid)
                {
                    UserDepositRequestRepository userDepositRequestRepository = new UserDepositRequestRepository();
                    TblUserDepositRequest userDepositRequest = new TblUserDepositRequest();

                    userDepositRequest.Address = userBusinessPackage.PaymentAddress;
                    userDepositRequest.Amount = userBusinessPackage.AmountPaid;
                    userDepositRequest.DepositStatus = (short)DepositStatus.PendingPayment;
                    userDepositRequest.CreatedOn = DateTime.Now;
                    userDepositRequest.SourceCurrencyId = currency.Id;
                    userDepositRequest.TargetWalletTypeId = walletType.Id;
                    userDepositRequest.UserAuthId = userBusinessPackage.Id;

                    TblUserDepositRequest x = userDepositRequestRepository.Create(userDepositRequest, db);

                    UserBusinessPackageRepository userBusinessPackageRepository = new UserBusinessPackageRepository();
                    TblUserBusinessPackage tblUserBusinessPackage = new TblUserBusinessPackage();
                    tblUserBusinessPackage.IsEnabled = true;
                    tblUserBusinessPackage.CreatedOn = DateTime.Now;
                    tblUserBusinessPackage.BusinessPackageId = 1;
                    tblUserBusinessPackage.UserAuthId = userBusinessPackage.Id;
                    tblUserBusinessPackage.PackageStatus = (short)PackageStatus.Activated;
                    tblUserBusinessPackage.UserDepositRequestId = x.Id;

                    db.TblUserBusinessPackage.Add(tblUserBusinessPackage);
                    db.SaveChanges();

                    return true;
                }
                else { return false; }
            }
            else
            {
                using (db = new dbWorldCCityContext())
                {
                    using (var transaction = db.Database.BeginTransaction())
                    {
                        WalletTypeRepository walletTypeRepository = new WalletTypeRepository();
                        TblWalletType walletType = walletTypeRepository.Get(new UserWalletBO { WalletCode = userBusinessPackage.FromWalletCode }, db);

                        UserWalletAppService userWalletAppService = new UserWalletAppService();
                        TblUserWallet userWallet = userWalletAppService.GetSingle(new TblUserAuth { Id = userBusinessPackage.Id }, walletType);

                        CurrencyTypeRepository currencyTypeRepository = new CurrencyTypeRepository();
                        TblCurrency currency = currencyTypeRepository.Get(new TblCurrency { CurrencyIsoCode3 = userBusinessPackage.FromCurrencyIso3 }, db);

                        if (userWallet.Balance >= userBusinessPackage.AmountPaid)
                        {
                            UserDepositRequestRepository userDepositRequestRepository = new UserDepositRequestRepository();
                            TblUserDepositRequest userDepositRequest = new TblUserDepositRequest();

                            userDepositRequest.Address = userBusinessPackage.PaymentAddress;
                            userDepositRequest.Amount = userBusinessPackage.AmountPaid;
                            userDepositRequest.DepositStatus = (short)DepositStatus.PendingPayment;
                            userDepositRequest.CreatedOn = DateTime.Now;
                            userDepositRequest.SourceCurrencyId = currency.Id;
                            userDepositRequest.TargetWalletTypeId = walletType.Id;
                            userDepositRequest.UserAuthId = userBusinessPackage.Id;

                            TblUserDepositRequest x = userDepositRequestRepository.Create(userDepositRequest, db);

                            UserBusinessPackageRepository userBusinessPackageRepository = new UserBusinessPackageRepository();
                            TblUserBusinessPackage tblUserBusinessPackage = new TblUserBusinessPackage();
                            tblUserBusinessPackage.IsEnabled = true;
                            tblUserBusinessPackage.CreatedOn = DateTime.Now;
                            tblUserBusinessPackage.BusinessPackageId = 1;
                            tblUserBusinessPackage.UserAuthId = userBusinessPackage.Id;
                            tblUserBusinessPackage.PackageStatus = (short)PackageStatus.Activated;
                            tblUserBusinessPackage.UserDepositRequestId = x.Id;

                            db.TblUserBusinessPackage.Add(tblUserBusinessPackage);
                            db.SaveChanges();

                            transaction.Commit();
                            return true;
                        }
                        else { return false; }
                    }
                }
                return true;
            }




        }
    }
}
