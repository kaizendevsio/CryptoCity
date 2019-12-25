using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CryptoCityWallet.FrontEnd.Models;
using CryptoCityWallet.Wrapper;
using CryptoCityWallet.Wrapper.Models;
using CryptoCityWallet.Entities.BO;
using CryptoCityWallet.Entities.DTO;
using Newtonsoft.Json;

namespace CryptoCityWallet.FrontEnd.Controllers
{
    public class WalletController : Controller
    {
        public readonly string Env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                // GET SESSIONS
                SessionController sessionController = new SessionController();
                SessionBO session = sessionController.GetSession(HttpContext.Session);

                ApiRequest apiRequest = new ApiRequest();
                ResponseBO _res = await apiRequest.GetAsync(Env,"User/Profile", session.SessionCookies);
                UserResponseBO apiResponse = JsonConvert.DeserializeObject<UserResponseBO>(_res.ResponseResult);

                TblUserInfo userInfo = apiResponse.UserInfo;
                TblUserAuth userAuth = apiResponse.UserAuth;

                _res = await apiRequest.GetAsync(Env,"User/Wallet", session.SessionCookies);
                apiResponse = JsonConvert.DeserializeObject<UserResponseBO>(_res.ResponseResult);

                List<UserWalletBO> userWallets = apiResponse.UserWallet;

                _res = await apiRequest.GetAsync(Env, "User/Wallet/Transactions", session.SessionCookies);
                apiResponse = JsonConvert.DeserializeObject<UserResponseBO>(_res.ResponseResult);

                List<TblUserWalletTransaction> userWalletTransactions = apiResponse.UserWalletTransactions;

                if (apiResponse.HttpStatusCode == "200")
                {
                    WalletVM walletVM = new WalletVM();
                    walletVM.Fullname = String.Format("{0} {1}", userInfo.FirstName, userInfo.LastName);
                    walletVM.Username = userAuth.UserName;
                    walletVM.BTCBalance = (decimal)userWallets.Find(i => i.WalletCode == "BTC").Balance;
                    walletVM.ETHBalance = (decimal)userWallets.Find(i => i.WalletCode == "ETH").Balance;
                    walletVM.TTHBalance = (decimal)userWallets.Find(i => i.WalletCode == "USDT").Balance;
                    walletVM.TransactionHistory = new TransactionVM { UserWalletTransactions = userWalletTransactions };
                    //walletVM.TransactionHistory = new TransactionVM { UserWalletTransactions = userWalletTransactions.FindAll(i => i.CreatedOn >= DateTime.Today)};

                    return View(walletVM);
                }
                else
                {
                    return RedirectToAction("Login", "Home");
                }


            }
            catch (System.Exception e)
            {
                return RedirectToAction("Login", "Home");

            }

        }
        [Route("/Wallet/MyBitcoin")]
        [HttpGet]
        public async Task<IActionResult> MyBitcoinAsync(int GenLink)
        {
            try
            {
                // GET SESSIONS
                SessionController sessionController = new SessionController();
                SessionBO session = sessionController.GetSession(HttpContext.Session);

                ApiRequest apiRequest = new ApiRequest();
                ResponseBO _res = await apiRequest.GetAsync(Env, "User/Profile", session.SessionCookies);
                WalletAddressResponseBO apiResponse = JsonConvert.DeserializeObject<WalletAddressResponseBO>(_res.ResponseResult);

                if (GenLink != 0)
                {
                    _res = await apiRequest.GetAsync(Env, "Wallet/Address/Btc/New", session.SessionCookies);
                    WalletAddressResponseBO walletApiResponse = JsonConvert.DeserializeObject<WalletAddressResponseBO>(_res.ResponseResult);
                    apiResponse.Address = walletApiResponse.Address;
                }

                TblUserInfo userInfo = apiResponse.UserInfo;
                TblUserAuth userAuth = apiResponse.UserAuth;

                if (apiResponse.HttpStatusCode == "200")
                {
                    WalletVM walletVM = new WalletVM();
                    walletVM.Fullname = String.Format("{0} {1}", userInfo.FirstName, userInfo.LastName);
                    walletVM.Username = userAuth.UserName;
                    walletVM.GenLink = GenLink;
                    walletVM.PaymentAddress = apiResponse.Address;

                    return View(walletVM);
                }
                else
                {
                    return RedirectToAction("Login", "Home");
                }


            }
            catch (System.Exception e)
            {
                return RedirectToAction("Login", "Home");

            }

        }
        [Route("/Wallet/MyEthereum")]
        [HttpGet]
        public async Task<IActionResult> MyEthereumAsync(int GenLink)
        {
            try
            {
                // GET SESSIONS
                SessionController sessionController = new SessionController();
                SessionBO session = sessionController.GetSession(HttpContext.Session);

                ApiRequest apiRequest = new ApiRequest();
                ResponseBO _res = await apiRequest.GetAsync(Env, "User/Profile", session.SessionCookies);
                WalletAddressResponseBO apiResponse = JsonConvert.DeserializeObject<WalletAddressResponseBO>(_res.ResponseResult);
                if (GenLink != 0)
                {
                    _res = await apiRequest.GetAsync(Env, "Wallet/Address/Eth/New", session.SessionCookies);
                    WalletAddressResponseBO walletApiResponse = JsonConvert.DeserializeObject<WalletAddressResponseBO>(_res.ResponseResult);
                    apiResponse.Address = walletApiResponse.Address;
                }

                TblUserInfo userInfo = apiResponse.UserInfo;
                TblUserAuth userAuth = apiResponse.UserAuth;

                if (apiResponse.HttpStatusCode == "200")
                {
                    WalletVM walletVM = new WalletVM();
                    walletVM.Fullname = String.Format("{0} {1}", userInfo.FirstName, userInfo.LastName);
                    walletVM.Username = userAuth.UserName;
                    walletVM.GenLink = GenLink;
                    walletVM.PaymentAddress = apiResponse.Address;

                    return View(walletVM);
                }
                else
                {
                    return RedirectToAction("Login", "Home");
                }


            }
            catch (System.Exception e)
            {
                return RedirectToAction("Login", "Home");

            }
        }
        [Route("/Wallet/MyTether")]
        [HttpGet]
        public async Task<IActionResult> MyTetherAsync(int GenLink)
        {
            try
            {
                // GET SESSIONS
                SessionController sessionController = new SessionController();
                SessionBO session = sessionController.GetSession(HttpContext.Session);

                ApiRequest apiRequest = new ApiRequest();
                ResponseBO _res = await apiRequest.GetAsync(Env, "User/Profile", session.SessionCookies);
                WalletAddressResponseBO apiResponse = JsonConvert.DeserializeObject<WalletAddressResponseBO>(_res.ResponseResult);
                if (GenLink != 0)
                {
                    _res = await apiRequest.GetAsync(Env, "Wallet/Address/Usdt/New", session.SessionCookies);
                    WalletAddressResponseBO walletApiResponse = JsonConvert.DeserializeObject<WalletAddressResponseBO>(_res.ResponseResult);
                    apiResponse.Address = walletApiResponse.Address;
                }

                TblUserInfo userInfo = apiResponse.UserInfo;
                TblUserAuth userAuth = apiResponse.UserAuth;

                if (apiResponse.HttpStatusCode == "200")
                {
                    WalletVM walletVM = new WalletVM();
                    walletVM.Fullname = String.Format("{0} {1}", userInfo.FirstName, userInfo.LastName);
                    walletVM.Username = userAuth.UserName;
                    walletVM.GenLink = GenLink;
                    walletVM.PaymentAddress = apiResponse.Address;

                    return View(walletVM);
                }
                else
                {
                    return RedirectToAction("Login", "Home");
                }


            }
            catch (System.Exception e)
            {
                return RedirectToAction("Login", "Home");

            }
        }



        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
