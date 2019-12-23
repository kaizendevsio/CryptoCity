using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using CryptoCityWallet.Wrapper.Models;
using System.IO;

namespace CryptoCityWallet.Wrapper
{
    public class ApiRequest
    {
        private Uri ApiUri_Live { get; set; } = new Uri("http://13.251.181.208:8096/");
        private Uri ApiUri_Local { get; set; } = new Uri("https://localhost:55007/");
        public Uri ApiUri { get; set; }

        public Uri ApiUriInit(string Environment)
        {
            if (Environment == "Development")
            {
                ApiUri = ApiUri_Local;
            }
            else
            {
                ApiUri = ApiUri_Live;
            }
            //string Environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            return ApiUri;

        }

        public async Task<ResponseBO> PostAsync(string env, string url, object param,  CookieCollection requestCookies = null, string contentType = "application/json")
        {
            CookieContainer cookies = new CookieContainer();
            HttpClientHandler handler = new HttpClientHandler();
            handler.CookieContainer = cookies;
            ApiUriInit(env);

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
                HttpResponseMessage x = await _client.PostAsync(ApiUri.AbsoluteUri + "api/" + url, new StringContent(JsonConvert.SerializeObject(param), Encoding.UTF8, "application/json"));
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

        public async Task<ResponseBO> GetAsync(string env, string url, CookieCollection requestCookies = null, string contentType = "application/json")
        {
            CookieContainer cookies = new CookieContainer();
            HttpClientHandler handler = new HttpClientHandler();
            handler.CookieContainer = cookies;
            ApiUriInit(env);

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
                HttpResponseMessage x = await _client.GetAsync(ApiUri.AbsoluteUri + "api/" + url);
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
    }
}
