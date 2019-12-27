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

            return blockchainApiSettings;
        }

        public async Task<BlockchainResponse> GenerateNewAddressAsync(string CallBackUrl)

        {
            BlockchainApiSettings blockchainApiSettings = GetSettings();
            ResponseBO _res = await GetAsync("receive", new { xpub = blockchainApiSettings.XpubKey, callback = blockchainApiSettings.CallbackURL, key = blockchainApiSettings.ApiKey });
            ReceivePaymentResponse receivePayment = JsonConvert.DeserializeObject<ReceivePaymentResponse>(_res.ResponseResult);

            BlockchainResponse blockchainResponse = new BlockchainResponse();
            blockchainResponse.Address = receivePayment.Address;
            blockchainResponse.XpubKey = blockchainApiSettings.XpubKey;

            return blockchainResponse;
            //return "123";
        }
        private Uri ApiUri { get; set; } = new Uri("https://api.blockchain.info/");
        public async Task<ResponseBO> PostAsync(string url, object param, CookieCollection requestCookies = null, string contentType = "application/json")
        {
            CookieContainer cookies = new CookieContainer();
            HttpClientHandler handler = new HttpClientHandler();
            handler.CookieContainer = cookies;

            if (requestCookies != null)
            {
                int cookieCount = requestCookies.Count();
                for (int i = 0; i < cookieCount; i++)
                {
                    handler.CookieContainer.Add(ApiUri, new Cookie(requestCookies.ElementAt(i).Name, requestCookies.ElementAt(i).Value));
                }
            }

            using (HttpClient _client = new HttpClient(handler) { BaseAddress = ApiUri, Timeout = TimeSpan.FromHours(2) })
            {
                //_client.DefaultRequestHeaders.Clear();
                HttpResponseMessage x = await _client.PostAsync(ApiUri.AbsoluteUri + "v2/" + url, new StringContent(JsonConvert.SerializeObject(param), Encoding.UTF8, "application/json"));
                CookieCollection responseCookies = cookies.GetCookies(ApiUri);

                if (x.IsSuccessStatusCode)
                {
                    ResponseBO response = new ResponseBO();
                    response.ResponseCookies = responseCookies;
                    response.ResponseResult = await x.Content.ReadAsStringAsync();

                    return response;
                }
                else
                {
                    throw new System.ArgumentException(String.Format("{0}", x.ReasonPhrase));
                }

            }
        }

        public async Task<ResponseBO> GetAsync(string url, object param, CookieCollection requestCookies = null, string contentType = "application/json")
        {
            CookieContainer cookies = new CookieContainer();
            HttpClientHandler handler = new HttpClientHandler();
            handler.CookieContainer = cookies;

            if (requestCookies != null)
            {
                int cookieCount = requestCookies.Count();
                for (int i = 0; i < cookieCount; i++)
                {
                    handler.CookieContainer.Add(ApiUri, new Cookie(requestCookies.ElementAt(i).Name, requestCookies.ElementAt(i).Value));
                }
            }

            using (HttpClient _client = new HttpClient(handler) { BaseAddress = ApiUri, Timeout = TimeSpan.FromHours(2) })
            {
                //_client.DefaultRequestHeaders.Clear();
                var requestModelJson = JsonConvert.SerializeObject(param);
                HttpResponseMessage x = await _client.GetAsync(ApiUri.AbsoluteUri + "v2/" + url + JsonToQuery(requestModelJson));
                CookieCollection responseCookies = cookies.GetCookies(ApiUri);

                if (x.IsSuccessStatusCode)
                {
                    ResponseBO response = new ResponseBO();
                    response.ResponseCookies = responseCookies;
                    response.ResponseResult = await x.Content.ReadAsStringAsync();
                    return response;
                }
                else
                {
                    throw new System.ArgumentException(String.Format("{0}", x.ReasonPhrase));
                }



            }
        }

        public string JsonToQuery(string jsonQuery)
        {
            string str = "?";
            str += jsonQuery.Replace(":", "=").Replace("{", "").
                        Replace("}", "").Replace(",", "&").
                            Replace("\"", "");
            return str;
        }


    }
}
