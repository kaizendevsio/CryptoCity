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
        public async Task<bool> Create(TblUserAuth userAuth, string appendAddress = null, dbWorldCCityContext db = null)
        {
            if (db != null)
            {
                UserWalletAddressRepository userWalletAddressRepository = new UserWalletAddressRepository();
                TblUserWalletAddress userWalletAddress = new TblUserWalletAddress();

                if (appendAddress == null)
                {
                    Blockchain blockchain = new Blockchain();
                    BlockchainResponse _br = await blockchain.GenerateNewAddressAsync("").ConfigureAwait(true);
                    userWalletAddress.Address = _br.Address;
                }
                else
                {
                    userWalletAddress.Address = appendAddress;
                }
                userWalletAddress.UserAuthId = userAuth.Id;
                userWalletAddress.Balance = 0m;

                userWalletAddressRepository.Create(userWalletAddress, db);
            }
            else
            {
                using (db = new dbWorldCCityContext())
                {
                    using (var transaction = db.Database.BeginTransaction())
                    {
                        UserWalletAddressRepository userWalletAddressRepository = new UserWalletAddressRepository();
                        TblUserWalletAddress userWalletAddress = new TblUserWalletAddress();

                        if (appendAddress == null)
                        {
                            Blockchain blockchain = new Blockchain();
                            BlockchainResponse _br = await blockchain.GenerateNewAddressAsync("").ConfigureAwait(true);
                            userWalletAddress.Address = _br.Address;
                        }
                        else
                        {
                            userWalletAddress.Address = appendAddress;
                        }
                        userWalletAddress.UserAuthId = userAuth.Id;
                        userWalletAddress.Balance = 0m;

                        userWalletAddressRepository.Create(userWalletAddress, db);
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

                        return _r;
                    }
                }
            }
        }
    }
}
