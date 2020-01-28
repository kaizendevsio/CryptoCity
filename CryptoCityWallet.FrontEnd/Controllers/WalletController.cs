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
using CryptoCityWallet.Entities.Enums;
using CryptoCityWallet.ExternalUtilities.Models;

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
                    walletVM.TransactionHistory = new TransactionVM { UserWalletTransactions = userWalletTransactions };
                    walletVM.UserWallets = userWallets.FindAll(item => item.WalletType.Code == "BTC" || item.WalletType.Code == "ETH" || item.WalletType.Code == "USDT");
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
        public async Task<IActionResult> MyBitcoinAsync()
        {
            try
            {
                // GET SESSIONS
                SessionController sessionController = new SessionController();
                SessionBO session = sessionController.GetSession(HttpContext.Session);

                ApiRequest apiRequest = new ApiRequest();
                ResponseBO _res = await apiRequest.GetAsync(Env, "User/Profile", session.SessionCookies);
                WalletAddressResponseBO apiResponse = JsonConvert.DeserializeObject<WalletAddressResponseBO>(_res.ResponseResult);

                TblUserInfo userInfo = apiResponse.UserInfo;
                TblUserAuth userAuth = apiResponse.UserAuth;

                _res = await apiRequest.GetAsync(Env, "User/Wallet", session.SessionCookies);
                apiResponse = JsonConvert.DeserializeObject<WalletAddressResponseBO>(_res.ResponseResult);
                List<TblUserWalletAddress> userWalletAddresses = apiResponse.UserWalletAddress;
                List<UserWalletBO> userWallets = apiResponse.UserWallet;

                _res = await apiRequest.GetAsync(Env, "Wallet/Address/Transactions/" + "?currency=BTC", session.SessionCookies);
                WalletAddressResponseBO walletApiResponse = JsonConvert.DeserializeObject<WalletAddressResponseBO>(_res.ResponseResult);

                BlockchainTx blockchainTx = JsonConvert.DeserializeObject<BlockchainTx>(walletApiResponse.AddressTransactions);
                //IEnumerable<ExternalUtilities.Models.Txref> txrefs = blockchainTx.Txrefs.Distinct();

                if (apiResponse.HttpStatusCode == "200")
                {
                    WalletVM walletVM = new WalletVM();
                    walletVM.Fullname = String.Format("{0} {1}", userInfo.FirstName, userInfo.LastName);
                    walletVM.Username = userAuth.UserName;
                    walletVM.WalletCode = "BTC";
                    walletVM.WalletName = "Bitcoin";
                    walletVM.PaymentAddress = userWalletAddresses.Find(i => i.WalletType.Code == "BTC").Address;
                    walletVM.UserWallets = userWallets.FindAll(item => item.WalletType.Type == (short)WalletType.CurrencyValue);
                    walletVM.UserWalletAddresses = userWalletAddresses;
                    walletVM.UserWalletAddressTxs = blockchainTx;
                    walletVM.UserWalletAddressTxs.Txrefs = blockchainTx.Txrefs == null ? new List<ExternalUtilities.Models.Txref>() : blockchainTx.Txrefs;

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

                TblUserInfo userInfo = apiResponse.UserInfo;
                TblUserAuth userAuth = apiResponse.UserAuth;

                if (apiResponse.HttpStatusCode == "200")
                {
                    WalletVM walletVM = new WalletVM();
                    walletVM.Fullname = String.Format("{0} {1}", userInfo.FirstName, userInfo.LastName);
                    walletVM.Username = userAuth.UserName;
                    walletVM.WalletCode = "ETH";
                    walletVM.WalletName = "Ethereum";
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

                TblUserInfo userInfo = apiResponse.UserInfo;
                TblUserAuth userAuth = apiResponse.UserAuth;

                if (apiResponse.HttpStatusCode == "200")
                {
                    WalletVM walletVM = new WalletVM();
                    walletVM.Fullname = String.Format("{0} {1}", userInfo.FirstName, userInfo.LastName);
                    walletVM.Username = userAuth.UserName;
                    walletVM.WalletCode = "USDT";
                    walletVM.WalletName = "Tether";
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

        [HttpPost("/Wallet/NewAddress")]
        public async Task<IActionResult> NewAddress([FromBody] UserWalletBO walletBO)
        {
            try
            {
                // GET SESSIONS
                SessionController sessionController = new SessionController();
                SessionBO session = sessionController.GetSession(HttpContext.Session);

                ApiRequest apiRequest = new ApiRequest();
                ResponseBO _res = await apiRequest.GetAsync(Env, "User/Profile", session.SessionCookies);
                WalletAddressResponseBO apiResponse = JsonConvert.DeserializeObject<WalletAddressResponseBO>(_res.ResponseResult);

                _res = await apiRequest.GetAsync(Env, "Wallet/Address/" + walletBO.WalletCode + "/New", session.SessionCookies);
                WalletAddressResponseBO walletApiResponse = JsonConvert.DeserializeObject<WalletAddressResponseBO>(_res.ResponseResult);
                apiResponse.Address = walletApiResponse.Address;
                //apiResponse.XpubKey = walletApiResponse.XpubKey;

                TblUserInfo userInfo = apiResponse.UserInfo;
                TblUserAuth userAuth = apiResponse.UserAuth;

                if (apiResponse.HttpStatusCode == "200")
                {
                    apiResponse.Address = apiResponse.Address;
                    apiResponse.XpubKey = apiResponse.XpubKey;
                    apiResponse.Message = null;
                }
                else
                {
                    apiResponse.RedirectUrl = "/User/Login";
                }
                return Ok(apiResponse);

            }
            catch (System.Exception e)
            {
                WalletAddressResponseBO apiResponse = new WalletAddressResponseBO();
                apiResponse.RedirectUrl = "/User/Login";
                return BadRequest(apiResponse);

            }
        }

        [HttpPost("Send")]
        public async Task<ActionResult> SendAsync([FromBody] WalletTransactionVM walletTransaction)
        {
            try
            {
                // GET SESSIONS
                SessionController sessionController = new SessionController();
                SessionBO session = sessionController.GetSession(HttpContext.Session);

                ApiRequest apiRequest = new ApiRequest();
                ResponseBO _res = await apiRequest.PostAsync(Env, "Wallet/Send", new WalletTransactionBO { From = walletTransaction.From, To = walletTransaction.To, Amount = decimal.Parse(walletTransaction.Amount)}, session.SessionCookies);
               
                ApiResponseBO apiResponse = JsonConvert.DeserializeObject<ApiResponseBO>(_res.ResponseResult);

                if (apiResponse.HttpStatusCode == "200")
                {
                    apiResponse.Message = apiResponse.Status;
                    return Ok(apiResponse);
                }
                else
                {
                    return BadRequest(apiResponse);
                }

            }
            catch (System.Exception e)
            {
                ApiResponseBO apiResponse = new ApiResponseBO();
                return BadRequest(apiResponse);
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
