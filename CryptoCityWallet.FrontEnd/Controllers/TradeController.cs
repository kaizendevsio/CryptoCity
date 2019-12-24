using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CryptoCityWallet.FrontEnd.Models;
using CryptoCityWallet.Wrapper.Models;
using CryptoCityWallet.Entities.BO;
using CryptoCityWallet.Entities.Enums;
using Newtonsoft.Json;
using CryptoCityWallet.Entities.DTO;
using CryptoCityWallet.Wrapper;

namespace CryptoCityWallet.FrontEnd.Controllers
{
    public class TradeController : Controller
    {
        public readonly string Env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");


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

                _res = await apiRequest.GetAsync(Env, "User/BusinessPackages", session.SessionCookies);
                apiResponse = JsonConvert.DeserializeObject<UserResponseBO>(_res.ResponseResult);

                List<TblUserBusinessPackage> UserBusinessPackages = apiResponse.BusinessPackages;

                if (apiResponse.HttpStatusCode == "200")
                {
                    TradeVM tradeVM = new TradeVM();
                    tradeVM.Fullname = String.Format("{0} {1}", userInfo.FirstName, userInfo.LastName);
                    tradeVM.Username = userAuth.UserName;
                    tradeVM.TotalInvestment = (double)userWallets.Find(i => i.WalletCode == "TLI").Balance;
                    tradeVM.WCCPBalance = (double)userWallets.Find(i => i.WalletCode == "WCCP").Balance;
                    tradeVM.YesterdayProfit = 0;
                    tradeVM.UserWallets = userWallets.FindAll(item => item.WalletType.Type == (short)WalletType.CurrencyValue);
                    tradeVM.UserBusinessPackages = UserBusinessPackages;

                    return View(tradeVM);
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

        [HttpPost("Trade/BuyPackage")]
        public async Task<IActionResult> BuyPackage([FromBody] UserBusinessPackageBO userBusinessPackage)
        {
            try
            {
                // GET SESSIONS
                SessionController sessionController = new SessionController();
                SessionBO session = sessionController.GetSession(HttpContext.Session);

                ApiRequest apiRequest = new ApiRequest();
                ResponseBO _res = await apiRequest.GetAsync(Env, "User/Profile", session.SessionCookies);
                UserResponseBO apiResponse = JsonConvert.DeserializeObject<UserResponseBO>(_res.ResponseResult);

                TblUserAuth userAuth = apiResponse.UserAuth;
                userBusinessPackage.Id = userAuth.Id;

                _res = await apiRequest.PostAsync(Env, "BusinessPackage/Buy", userBusinessPackage, session.SessionCookies);
                apiResponse = JsonConvert.DeserializeObject<UserResponseBO>(_res.ResponseResult);


                if (apiResponse.HttpStatusCode == "200")
                {

                    //apiResponse.RedirectUrl = "/Wallet/";
                    apiResponse.Message = apiResponse.Message;
                    return Ok(apiResponse);
                }
                else
                {
                    apiResponse.RedirectUrl = "/User/Login/Failed";
                    return BadRequest(apiResponse);
                }
            }
            catch (System.Exception e)
            {
                UserResponseBO apiResponse = new UserResponseBO();
                apiResponse.RedirectUrl = "/User/Login/Failed";
                apiResponse.Message = e.Message;
                return BadRequest(apiResponse);
                //return Redirect("~/User/Login/Failed");

            }
        }

        [Route("Trade/History")]
        public async Task<IActionResult> HistoryAsync()
        {
            try
            {
                // GET SESSIONS
                SessionController sessionController = new SessionController();
                SessionBO session = sessionController.GetSession(HttpContext.Session);

                ApiRequest apiRequest = new ApiRequest();
                ResponseBO _res = await apiRequest.GetAsync(Env, "User/Profile", session.SessionCookies);
                UserAffiliateProfitsResponseBO apiResponse = JsonConvert.DeserializeObject<UserAffiliateProfitsResponseBO>(_res.ResponseResult);

                TblUserInfo userInfo = apiResponse.UserInfo;
                TblUserAuth userAuth = apiResponse.UserAuth;

                _res = await apiRequest.GetAsync(Env, "User/Affiliate/TradeTransactions", session.SessionCookies);
                apiResponse = JsonConvert.DeserializeObject<UserAffiliateProfitsResponseBO>(_res.ResponseResult);

                List<TblDividend> dividends = apiResponse.TradeTransactions;

                if (apiResponse.HttpStatusCode == "200")
                {
                    TradeVM tradeVM = new TradeVM();
                    tradeVM.Fullname = String.Format("{0} {1}", userInfo.FirstName, userInfo.LastName);
                    tradeVM.Username = userAuth.UserName;
                    tradeVM.YesterdayProfit = 0;
                    tradeVM.TradeTransactions = dividends;

                    return View(tradeVM);
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
