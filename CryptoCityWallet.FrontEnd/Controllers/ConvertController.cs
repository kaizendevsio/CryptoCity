using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CryptoCityWallet.FrontEnd.Models;
using CryptoCityWallet.Wrapper.Models;
using CryptoCityWallet.Wrapper;
using Newtonsoft.Json;
using CryptoCityWallet.Entities.BO;
using CryptoCityWallet.Entities.DTO;
using CryptoCityWallet.Entities.Enums;

namespace CryptoCityWallet.FrontEnd.Controllers
{
    public class ConvertController : Controller
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
                ResponseBO _res = await apiRequest.GetAsync(Env, "User/Profile", session.SessionCookies);
                UserResponseBO apiResponse = JsonConvert.DeserializeObject<UserResponseBO>(_res.ResponseResult);

                TblUserInfo userInfo = apiResponse.UserInfo;
                TblUserAuth userAuth = apiResponse.UserAuth;

                _res = await apiRequest.GetAsync(Env, "User/Wallet", session.SessionCookies);
                apiResponse = JsonConvert.DeserializeObject<UserResponseBO>(_res.ResponseResult);

                List<UserWalletBO> userWallets = apiResponse.UserWallet;

                _res = await apiRequest.GetAsync(Env, "User/BusinessPackages", session.SessionCookies);
                apiResponse = JsonConvert.DeserializeObject<UserResponseBO>(_res.ResponseResult);

                List<TblUserBusinessPackage> UserBusinessPackages = apiResponse.BusinessPackages;

                if (apiResponse.HttpStatusCode == "200")
                {
                    ConvertVM convertVM = new ConvertVM();
                    convertVM.Fullname = String.Format("{0} {1}", userInfo.FirstName, userInfo.LastName);
                    convertVM.Username = userAuth.UserName;
                    convertVM.UserWallets = userWallets.FindAll(item => item.WalletType.Code == "WCCP");

                    return View(convertVM);
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
