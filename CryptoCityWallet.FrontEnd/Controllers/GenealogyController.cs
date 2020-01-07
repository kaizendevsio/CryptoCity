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
        public readonly string Env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

        [Route("Genealogy")]
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

                _res = await apiRequest.GetAsync(Env, "User/Affiliate/Counters", session.SessionCookies);
                AffiliateCountersBO apiResponse2 = JsonConvert.DeserializeObject<AffiliateCountersBO>(_res.ResponseResult);

                AffiliateCountersBO affiliateCountersBO = new AffiliateCountersBO { DirectPartners = apiResponse2.DirectPartners, InvestmentSum = apiResponse2.InvestmentSum };

                if (apiResponse.HttpStatusCode == "200")
                {
                    GenealogyVM genealogyVM = new GenealogyVM();
                    genealogyVM.Fullname = String.Format("{0} {1}", userInfo.FirstName, userInfo.LastName);
                    genealogyVM.Username = userAuth.UserName;
                    genealogyVM.TotalInvestment = (double)affiliateCountersBO.InvestmentSum;
                    genealogyVM.DirectPartners = (int)userWallets.Find(i => i.WalletCode == "DLN").Balance;
                    genealogyVM.DirectVolume = affiliateCountersBO.DirectPartners;
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

        [Route("Genealogy/Unilevel")]
        public async Task<IActionResult> Unilevel()
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

                _res = await apiRequest.GetAsync(Env, "User/Affiliate/Counters", session.SessionCookies);
                AffiliateCountersBO apiResponse2 = JsonConvert.DeserializeObject<AffiliateCountersBO>(_res.ResponseResult);

                AffiliateCountersBO affiliateCountersBO = new AffiliateCountersBO { DirectPartners = apiResponse2.DirectPartners, InvestmentSum = apiResponse2.InvestmentSum };

                if (apiResponse.HttpStatusCode == "200")
                {
                    GenealogyVM genealogyVM = new GenealogyVM();
                    genealogyVM.Fullname = String.Format("{0} {1}", userInfo.FirstName, userInfo.LastName);
                    genealogyVM.Username = userAuth.UserName;
                    genealogyVM.TotalInvestment = (double)affiliateCountersBO.InvestmentSum;
                    genealogyVM.DirectPartners = (int)userWallets.Find(i => i.WalletCode == "DLN").Balance;
                    genealogyVM.DirectVolume = affiliateCountersBO.DirectPartners;
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

        [HttpGet("GetMapBinary")]
        public async Task<IActionResult> GetMapBinary()
        {
            try
            {
                // GET SESSIONS
                SessionController sessionController = new SessionController();
                SessionBO session = sessionController.GetSession(HttpContext.Session);

                ApiRequest apiRequest = new ApiRequest();
                ResponseBO _res = await apiRequest.GetAsync(Env, "User/BinaryMap", session.SessionCookies);
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

        [HttpGet("GetMapUnilevel")]
        public async Task<IActionResult> GetMapUnilevel()
        {
            try
            {
                // GET SESSIONS
                SessionController sessionController = new SessionController();
                SessionBO session = sessionController.GetSession(HttpContext.Session);

                ApiRequest apiRequest = new ApiRequest();
                ResponseBO _res = await apiRequest.GetAsync(Env, "User/UnilevelMap", session.SessionCookies);
                UserResponseBO apiResponse = JsonConvert.DeserializeObject<UserResponseBO>(_res.ResponseResult);

                if (apiResponse.HttpStatusCode == "200")
                {
                    return Ok(JsonConvert.SerializeObject(apiResponse));
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

        [HttpPost("GetAffiliateLink")]
        public async Task<IActionResult> GetAffiliateLink([FromBody] AffiliateMapBO affiliateMapBO)
        {
            try
            {
                // GET SESSIONS
                SessionController sessionController = new SessionController();
                SessionBO session = sessionController.GetSession(HttpContext.Session);

                ApiRequest apiRequest = new ApiRequest();
                ResponseBO _res = await apiRequest.PostAsync(Env, "Affiliate/InvitationLink",affiliateMapBO, session.SessionCookies);
                AffiliateLinkResponseBO apiResponse = JsonConvert.DeserializeObject<AffiliateLinkResponseBO>(_res.ResponseResult);

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
