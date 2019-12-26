using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CryptoCityWallet.FrontEnd.Models;
using CryptoCityWallet.Entities.BO;
using CryptoCityWallet.Wrapper;
using CryptoCityWallet.Wrapper.Models;
using Newtonsoft.Json;
using CryptoCityWallet.Entities.DTO;
using CryptoCityWallet.Entities.Enums;

namespace CryptoCityWallet.FrontEnd.Controllers
{
    public class HomeController : Controller
    {
        public readonly string Env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
        private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<TransactionController> logger)
        //{
        //    _logger = logger;
        //}

        public IActionResult Index()
        {
            return View();
        }
        [Route("ForgotPassword")]
        [HttpGet]
        public IActionResult ForgotPassword()
        {

            return View();
        }

        [Route("Login")]
        [HttpGet]
        public IActionResult LogIn()
        {

            return View();
        }
        [Route("SignUp")]
        [HttpGet]
        public IActionResult SignUp(string dsi, string bsi, int bp)
        {
            SignUpVM signUpVM = new SignUpVM();
            signUpVM.BinaryPosition = bp;
            signUpVM.BinarySponsorID = bsi;
            signUpVM.DirectSponsorID = dsi;

            return View(signUpVM);
        }
        //[Route("Logout")]
        //[HttpGet]
        //public async Task<IActionResult> LogOut()
        //{

        //    try
        //    {
        //        // GET SESSIONS
        //        SessionsController sessionController = new SessionsController();
        //        SessionBO session = sessionController.GetSession(HttpContext.Session);

        //        ApiRequest apiRequest = new ApiRequest();
        //        ResponseBO _res = await apiRequest.GetAsync(Env,"User/Profile", session.SessionCookies);
        //        UserResponseBO apiResponse = JsonConvert.DeserializeObject<UserResponseBO>(_res.ResponseResult);

        //        if (apiResponse.HttpStatusCode == "200")
        //        {
        //            _res = await apiRequest.GetAsync(Env,"User/Wallet", session.SessionCookies);
        //            UserResponseBO apiResponse_userWallet = JsonConvert.DeserializeObject<UserResponseBO>(_res.ResponseResult);

        //            TblUserInfo tblUserInfo = apiResponse.UserInfo;
        //            TblUserAuth tblUserAuth = apiResponse.UserAuth;
        //            List<UserWalletBO> userWallets = apiResponse_userWallet.UserWallet;
        //            //HttpContext.Session.Abandon();

        //            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        //            Response.Cookies.Delete(".AspNetCore.Session");
        //            return RedirectToAction("LogIn", "User");
        //        }

        //        else
        //        {
        //            //    apiResponse.RedirectUrl = "/User/Login/Failed";
        //            return RedirectToAction("FailedAttempt", "User");
        //        }
        //    }
        //    catch (System.Exception e)
        //    {
        //        return Redirect("/User/Login/Failed");

        //    }
        //    return Ok;
        //}


        [Route("Login")]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] UserBO userBO)
        {
            try
            {
                ApiRequest apiRequest = new ApiRequest();
                ResponseBO _res = await apiRequest.PostAsync(Env,"User/Authenticate", userBO);

                UserResponseBO apiResponse = JsonConvert.DeserializeObject<UserResponseBO>(_res.ResponseResult);

                if (apiResponse.HttpStatusCode == "200")
                {
                    SessionController sessionController = new SessionController();
                    sessionController.CreateSession(apiResponse, _res.ResponseCookies, HttpContext.Session);

                    TblUserInfo tblUserInfo = apiResponse.UserInfo;
                    TblUserAuth tblUserAuth = apiResponse.UserAuth;
                    TblUserRole tblUserRole = apiResponse.UserRole;

                    if (tblUserRole.AccessRole == AccessRole.Admin.ToString())
                    {
                        apiResponse.RedirectUrl = "/Admin/";
                    }
                    else if (tblUserRole.AccessRole == AccessRole.Client.ToString())
                    {
                        apiResponse.RedirectUrl = "/Wallet/";
                    }


                    apiResponse.Message = null;
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



        [Route("SignUp")]
        [HttpPost]
        public async Task<IActionResult> SignUp([FromBody] UserBO userBO)
        {
            try
            {


                ApiRequest apiRequest = new ApiRequest();
                ResponseBO _res = await apiRequest.PostAsync(Env, "User/Create", userBO);

                UserResponseBO apiResponse = JsonConvert.DeserializeObject<UserResponseBO>(_res.ResponseResult);

                if (apiResponse.HttpStatusCode == "200")
                {
                    SessionController sessionController = new SessionController();
                    sessionController.CreateSession(apiResponse, _res.ResponseCookies, HttpContext.Session);

                    TblUserInfo tblUserInfo = apiResponse.UserInfo;
                    TblUserAuth tblUserAuth = apiResponse.UserAuth;
                    TblUserRole tblUserRole = apiResponse.UserRole;



                    apiResponse.RedirectUrl = "Login/";
                    apiResponse.Message = "Signup Successful. You will be redirected to Login.";


                    return Ok(apiResponse);
                }
                else
                {
                    apiResponse.RedirectUrl = "Login/Failed";
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

        [Route("Logout")]
        [HttpGet]
        public IActionResult Logout()
        {
            SessionController sessionController = new SessionController();
            sessionController.DestroySession(HttpContext.Session);

            return Redirect("~/Login");
        }

    }
}
