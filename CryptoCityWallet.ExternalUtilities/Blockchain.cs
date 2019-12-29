using System;
using Info.Blockchain.API.Receive;
using CryptoCityWallet.ExternalUtilities.Models;
using Info.Blockchain.API.Models;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Linq;
using Newtonsoft.Json;
using System.Text;

namespace CryptoCityWallet.ExternalUtilities
{

    public class Blockchain
    {
        public BlockchainApiSettings GetSettings()
        {
            BlockchainApiSettings blockchainApiSettings = new BlockchainApiSettings();
            blockchainApiSettings.ApiKey = "9004fe40-5fd0-411a-ac42-4e820562c673";
            blockchainApiSettings.XpubKey = "xpub6Chiu7mVhgUjHGHasTxukV9scfYmm6UvPNa2MVSRjZCST2A9cTd3a6GGtE5NkCzpGHsN9wDJdFufSAGQMB3wGeVMEguhuLUHhS6HUgKgk3r";
            //blockchainApiSettings.XpubKey = "xpub6Chiu7mVhgUjF5V7FDB1ni8YCjDyhG7ib5p8iKVMssRDsSLU1qSi5U511DoK9TDBM8YezTJrarmvBRciHPo4E6LDt6omoEfshhyrH3niT6C";
            blockchainApiSettings.CallbackURL = "https%3A%2F%2Fwww.urlencoder.org%2F";
            blockchainApiSettings.ApiUri = new Uri("https://api.blockchain.info/");
            blockchainApiSettings.BlockCypherApiUri = new Uri("https://api.blockcypher.com/");

            return blockchainApiSettings;
        }

        public async Task<BlockchainResponse> GenerateNewAddressAsync(string CallBackUrl)

        {
            HttpUtilities httpUtilities = new HttpUtilities();
            BlockchainApiSettings blockchainApiSettings = GetSettings();
            ResponseBO _res = await httpUtilities.GetAsync(blockchainApiSettings.ApiUri, "v2/receive", new { xpub = blockchainApiSettings.XpubKey, callback = blockchainApiSettings.CallbackURL, key = blockchainApiSettings.ApiKey });
            ReceivePaymentResponse receivePayment = JsonConvert.DeserializeObject<ReceivePaymentResponse>(_res.ResponseResult);

            BlockchainResponse blockchainResponse = new BlockchainResponse();
            blockchainResponse.Address = receivePayment.Address;
            blockchainResponse.XpubKey = blockchainApiSettings.XpubKey;

            return blockchainResponse;
            //return "123";
        }

        public async Task<BlockchainTx> GetAddressTransactionsAsync(string _walletAddress)
        {
            HttpUtilities httpUtilities = new HttpUtilities();
            BlockchainApiSettings blockchainApiSettings = GetSettings();
            ResponseBO _res = await httpUtilities.GetAsync(blockchainApiSettings.BlockCypherApiUri, "v1/btc/main/addrs/" + _walletAddress, new object{});
            BlockchainTx _blockchainTx = JsonConvert.DeserializeObject<BlockchainTx>(_res.ResponseResult);

            return _blockchainTx;
        }


    }
}
