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
                TblWalletType walletType = walletTypeRepository.Get(new UserWalletBO { WalletCode = userBusinessPackage.FromWalletCode, WalletTypeId = 0 }, db);

                UserWalletAppService userWalletAppService = new UserWalletAppService();
                UserWalletBO userWallet = userWalletAppService.GetBO(new UserWalletBO { UserAuthId = userBusinessPackage.Id, WalletTypeId = walletType.Id }, db);

                CurrencyTypeRepository currencyTypeRepository = new CurrencyTypeRepository();
                TblCurrency currency = currencyTypeRepository.Get(new TblCurrency { CurrencyIsoCode3 = userBusinessPackage.FromCurrencyIso3 }, db);

                BusinessPackageRepository businessPackageRepository = new BusinessPackageRepository();
                TblBusinessPackage businessPackage = businessPackageRepository.Get(new TblBusinessPackage { Id = long.Parse(userBusinessPackage.BusinessPackageID) }, db);

                ExchangeRateRepository exchangeRateRepository = new ExchangeRateRepository();
                ExchangeRateBO exchangeRateBO = exchangeRateRepository.Get(new TblExchangeRate { SourceCurrencyId = (long)walletType.CurrencyId, TargetCurrencyId = (long)businessPackage.CurrencyId }, db);

                decimal _amountPaid = decimal.Parse(userBusinessPackage.AmountPaid);

                if (_amountPaid < businessPackage.ValueFrom)
                {
                    throw new ArgumentException("Payment is below the minimum package requirements");
                }

                if (userWallet.BalanceFiat >= _amountPaid)
                {
                    UserDepositRequestRepository userDepositRequestRepository = new UserDepositRequestRepository();
                    TblUserDepositRequest userDepositRequest = new TblUserDepositRequest
                    {
                        Address = userBusinessPackage.PaymentAddress,
                        Amount = _amountPaid,
                        DepositStatus = (short)DepositStatus.Paid,
                        CreatedOn = DateTime.Now,
                        SourceCurrencyId = currency.Id,
                        TargetWalletTypeId = walletType.Id,
                        UserAuthId = userBusinessPackage.Id
                    };

                    TblUserDepositRequest x = userDepositRequestRepository.Create(userDepositRequest, db);

                    UserBusinessPackageRepository userBusinessPackageRepository = new UserBusinessPackageRepository();
                    TblUserBusinessPackage tblUserBusinessPackage = new TblUserBusinessPackage
                    {
                        IsEnabled = true,
                        CreatedOn = DateTime.Now,
                        ActivationDate = DateTime.Now,
                        BusinessPackageId = 1,
                        UserAuthId = userBusinessPackage.Id,
                        PackageStatus = PackageStatus.Activated,
                        UserDepositRequestId = x.Id
                    };

                    db.TblUserBusinessPackage.Add(tblUserBusinessPackage);

                    userWalletAppService.Decrement(new UserWalletBO { UserAuthId = userWallet.UserAuthId, WalletCode = userWallet.WalletType.Code, WalletTypeId = userWallet.WalletTypeId }, new WalletTransactionBO { Amount = (_amountPaid * exchangeRateBO.OppositeValue) });

                    db.SaveChanges();

                    return true;
                }
                else { throw new ArgumentException("Insufficient wallet funds"); }
            }
            else
            {
                using (db = new dbWorldCCityContext())
                {
                    using var transaction = db.Database.BeginTransaction();
                    WalletTypeRepository walletTypeRepository = new WalletTypeRepository();
                    TblWalletType walletType = walletTypeRepository.Get(new UserWalletBO { WalletCode = userBusinessPackage.FromWalletCode, WalletTypeId = 0 }, db);

                    UserWalletAppService userWalletAppService = new UserWalletAppService();
                    UserWalletBO userWallet = userWalletAppService.GetBO(new UserWalletBO { UserAuthId = userBusinessPackage.Id, WalletTypeId = walletType.Id }, db);

                    CurrencyTypeRepository currencyTypeRepository = new CurrencyTypeRepository();
                    TblCurrency currency = currencyTypeRepository.Get(new TblCurrency { CurrencyIsoCode3 = userBusinessPackage.FromCurrencyIso3 }, db);

                    BusinessPackageRepository businessPackageRepository = new BusinessPackageRepository();
                    TblBusinessPackage businessPackage = businessPackageRepository.Get(new TblBusinessPackage { Id = long.Parse(userBusinessPackage.BusinessPackageID) }, db);

                    ExchangeRateRepository exchangeRateRepository = new ExchangeRateRepository();
                    ExchangeRateBO exchangeRateBO = exchangeRateRepository.Get(new TblExchangeRate { SourceCurrencyId = (long)walletType.CurrencyId, TargetCurrencyId = (long)businessPackage.CurrencyId }, db);

                    decimal _amountPaid = decimal.Parse(userBusinessPackage.AmountPaid);

                    if (_amountPaid < businessPackage.ValueFrom)
                    {
                        throw new ArgumentException("Payment is below the minimum package requirements");
                    }

                    if (userWallet.BalanceFiat >= _amountPaid)
                    {
                        UserDepositRequestRepository userDepositRequestRepository = new UserDepositRequestRepository();
                        TblUserDepositRequest userDepositRequest = new TblUserDepositRequest
                        {
                            Address = userBusinessPackage.PaymentAddress,
                            Amount = _amountPaid,
                            DepositStatus = (short)DepositStatus.PendingPayment,
                            CreatedOn = DateTime.Now,
                            SourceCurrencyId = currency.Id,
                            TargetWalletTypeId = walletType.Id,
                            UserAuthId = userBusinessPackage.Id
                        };

                        TblUserDepositRequest x = userDepositRequestRepository.Create(userDepositRequest, db);

                        UserBusinessPackageRepository userBusinessPackageRepository = new UserBusinessPackageRepository();
                        TblUserBusinessPackage tblUserBusinessPackage = new TblUserBusinessPackage
                        {
                            IsEnabled = true,
                            CreatedOn = DateTime.Now,
                            ActivationDate = DateTime.Now,
                            BusinessPackageId = 1,
                            UserAuthId = userBusinessPackage.Id,
                            PackageStatus = PackageStatus.Activated,
                            UserDepositRequestId = x.Id
                        };

                        db.TblUserBusinessPackage.Add(tblUserBusinessPackage);

                        userWalletAppService.Decrement(new UserWalletBO { UserAuthId = userWallet.UserAuthId, WalletCode = userWallet.WalletType.Code, WalletTypeId = userWallet.WalletTypeId }, new WalletTransactionBO { Amount = (_amountPaid * exchangeRateBO.OppositeValue) });

                        db.SaveChanges();

                        transaction.Commit();
                        return true;
                    }
                    else { throw new ArgumentException("Insufficient wallet funds"); }
                }
            }




        }

        public List<TblUserBusinessPackage> GetAll(TblUserAuth userAuth, dbWorldCCityContext db = null)
        {

            if (db != null)
            {
                UserBusinessPackageRepository userBusinessPackageRepository = new UserBusinessPackageRepository();
                return userBusinessPackageRepository.GetAll(userAuth, db);
            }
            else
            {
                using (db = new dbWorldCCityContext())
                {
                    using var transaction = db.Database.BeginTransaction();
                    UserBusinessPackageRepository userBusinessPackageRepository = new UserBusinessPackageRepository();
                    return userBusinessPackageRepository.GetAll(userAuth, db);
                }
            }
        }
    }
}
