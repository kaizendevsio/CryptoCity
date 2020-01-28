using System;
using System.Text;
using System.Linq;
using System.Security.Cryptography;
using CryptoCityWallet.Entities.DTO;
using CryptoCityWallet.Entities.BO;
using CryptoCityWallet.Entities.Enums;
using CryptoCityWallet.DataAccessLayer;
using CryptoCityWallet.ExternalUtilities;
using CryptoCityWallet.ExternalUtilities.Models;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace CryptoCityWallet.AppService
{
   public class UserWalletAddressAppService
    {
        public async Task<bool> Create(TblUserAuth userAuth, string walletCode, string appendAddress = null, dbWorldCCityContext db = null)
        {
            if (db != null)
            {
                UserWalletAddressRepository userWalletAddressRepository = new UserWalletAddressRepository();
                WalletTypeRepository walletTypeRepository = new WalletTypeRepository();
                TblUserWalletAddress userWalletAddress = new TblUserWalletAddress();

                TblWalletType walletType = walletTypeRepository.Get(new UserWalletBO { WalletCode = walletCode, WalletTypeId = 0 }, db);

                if (appendAddress == null)
                {
                    Blockchain blockchain = new Blockchain();
                    BlockchainResponse _br = await blockchain.NewPaymentAddress("").ConfigureAwait(true);
                    userWalletAddress.Address = _br.Address;
                }
                else
                {
                    userWalletAddress.Address = appendAddress;
                }
                userWalletAddress.UserAuthId = userAuth.Id;
                userWalletAddress.Balance = 0m;
                userWalletAddress.WalletTypeId = walletType.Id;

                userWalletAddressRepository.Create(userWalletAddress, db);
            }
            else
            {
                using (db = new dbWorldCCityContext())
                {
                    using (var transaction = db.Database.BeginTransaction())
                    {
                        UserWalletAddressRepository userWalletAddressRepository = new UserWalletAddressRepository();
                        WalletTypeRepository walletTypeRepository = new WalletTypeRepository();
                        TblUserWalletAddress userWalletAddress = new TblUserWalletAddress();

                        TblWalletType walletType = walletTypeRepository.Get(new UserWalletBO { WalletCode = walletCode, WalletTypeId = 0 }, db);

                        if (appendAddress == null)
                        {
                            Blockchain blockchain = new Blockchain();
                            BlockchainResponse _br = await blockchain.NewPaymentAddress("").ConfigureAwait(true);
                            userWalletAddress.Address = _br.Address;
                        }
                        else
                        {
                            userWalletAddress.Address = appendAddress;
                        }
                        userWalletAddress.UserAuthId = userAuth.Id;
                        userWalletAddress.Balance = 0m;
                        userWalletAddress.WalletTypeId = walletType.Id;

                        userWalletAddressRepository.Create(userWalletAddress, db);

                        transaction.Commit();
                    }
                }
            }

            return true;
        }
        public List<TblUserWalletAddress> GetAll(TblUserAuth userAuth, dbWorldCCityContext db = null)
        {
            if (db != null)
            {
                UserWalletAddressRepository userWalletAddressRepository = new UserWalletAddressRepository();
                List<TblUserWalletAddress> _r = userWalletAddressRepository.GetAll(userAuth, db);
                UpdateBalance(_r, new TblWalletType {Code = "BTC" }, db);

                return _r;
            }
            else
            {
                using (db = new dbWorldCCityContext())
                {
                    using (var transaction = db.Database.BeginTransaction())
                    {
                        UserWalletAddressRepository userWalletAddressRepository = new UserWalletAddressRepository();
                        List<TblUserWalletAddress> _r = userWalletAddressRepository.GetAll(userAuth, db);
                        UpdateBalance(_r, new TblWalletType { Code = "BTC" }, db);

                        transaction.Commit();
                        return _r;
                    }
                }
            }
        }
        public bool UpdateBalance(List<TblUserWalletAddress> userWalletAddresses, TblWalletType walletType, dbWorldCCityContext db)
        {

            UserWalletAddressRepository userWalletAddressRepository = new UserWalletAddressRepository();
            UserWalletAppService userWalletAppService = new UserWalletAppService();
            Blockchain blockchain = new Blockchain();
            BlockchainTx _br;
            decimal _bal;

            List<TblUserWalletAddress> _btcUserWalletAddresses = userWalletAddresses.FindAll(i => i.WalletType.Code == walletType.Code);

            foreach (var item in _btcUserWalletAddresses)
            {
                _br = blockchain.GetAddressTransactions(item.Address).Result;
                _bal = (_br.Txrefs.Sum(i => i.Value) / 100000000m);
                
                if (_bal != item.Balance)
                {
                    item.Balance = _bal;
                    userWalletAppService.Adjust(new UserWalletBO { UserAuthId = item.UserAuthId, WalletTypeId = item.WalletType.Id}, new WalletTransactionBO { Amount = _bal }, db);
                    userWalletAddressRepository.Update(item, db);
                }               
                
            }

            return true;
        }
    }
}
