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
using Newtonsoft.Json;
using CryptoCityWallet.Entities.DTO;
using CryptoCityWallet.Wrapper;

namespace CryptoCityWallet.FrontEnd.Controllers
{
    public class GenealogyController : Controller
    { 
        public async Task<IActionResult> Index()
        {
            try
            {
                // GET SESSIONS
                SessionController sessionController = new SessionController();
                SessionBO session = sessionController.GetSession(HttpContext.Session);

                ApiRequest apiRequest = new ApiRequest();
                ResponseBO _res = await apiRequest.GetAsync("User/Profile", session.SessionCookies);
                UserResponseBO apiResponse = JsonConvert.DeserializeObject<UserResponseBO>(_res.ResponseResult);

                TblUserInfo userInfo = apiResponse.UserInfo;
                TblUserAuth userAuth = apiResponse.UserAuth;

                _res = await apiRequest.GetAsync("User/Wallet", session.SessionCookies);
                apiResponse = JsonConvert.DeserializeObject<UserResponseBO>(_res.ResponseResult);

                List<UserWalletBO> userWallets = apiResponse.UserWallet;

                if (apiResponse.HttpStatusCode == "200")
                {
                    GenealogyVM genealogyVM = new GenealogyVM();
                    genealogyVM.Fullname = String.Format("{0} {1}", userInfo.FirstName, userInfo.LastName);
                    genealogyVM.Username = userAuth.UserName;
                    genealogyVM.TotalInvestment = (double)userWallets.Find(i => i.WalletCode == "TLI").Balance;
                    genealogyVM.DirectPartners = (int)userWallets.Find(i => i.WalletCode == "DLN").Balance;
                    genealogyVM.DirectVolume = (int)userWallets.Find(i => i.WalletCode == "DVL").Balance;
                    genealogyVM.TotalGroupVolume = (int)userWallets.Find(i => i.WalletCode == "TGV").Balance;
                    genealogyVM.UserInfo = new UserBO { Uid = userInfo.Uid };

                    return View(genealogyVM);
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

        [HttpGet("GetMap")]
        public async Task<IActionResult> GetMap()
        {
            try
            {
                // GET SESSIONS
                SessionController sessionController = new SessionController();
                SessionBO session = sessionController.GetSession(HttpContext.Session);

                ApiRequest apiRequest = new ApiRequest();
                ResponseBO _res = await apiRequest.GetAsync("User/Map", session.SessionCookies);
                UserResponseBO apiResponse = JsonConvert.DeserializeObject<UserResponseBO>(_res.ResponseResult);

                if (apiResponse.HttpStatusCode == "200")
                {
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
