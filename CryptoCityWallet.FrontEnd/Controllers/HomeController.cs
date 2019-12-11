using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CryptoCityWallet.FrontEnd.Models;

namespace CryptoCityWallet.FrontEnd.Controllers
{
    public class HomeController : Controller
    {

        private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<TransactionController> logger)
        //{
        //    _logger = logger;
        //}

        public IActionResult Index()
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
        public IActionResult SignUp()
        {

            return View();
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
        //        ResponseBO _res = await apiRequest.GetAsync("User/Profile", session.SessionCookies);
        //        UserResponseBO apiResponse = JsonConvert.DeserializeObject<UserResponseBO>(_res.ResponseResult);

        //        if (apiResponse.HttpStatusCode == "200")
        //        {
        //            _res = await apiRequest.GetAsync("User/Wallet", session.SessionCookies);
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


        //[Route("Login")]
        //    [HttpPost]
        //    public async Task<IActionResult> Login([FromBody] UserBO userBO)
        //    {
        //        try
        //        {
        //            ApiRequest apiRequest = new ApiRequest();
        //            ResponseBO _res = await apiRequest.PostAsync("User/Authenticate", userBO);

        //            UserResponseBO apiResponse = JsonConvert.DeserializeObject<UserResponseBO>(_res.ResponseResult);

        //            if (apiResponse.HttpStatusCode == "200")
        //            {
        //                SessionsController sessionController = new SessionsController();
        //                sessionController.CreateSession(apiResponse, _res.ResponseCookies, HttpContext.Session);

        //                TblUserInfo tblUserInfo = apiResponse.UserInfo;
        //                TblUserAuth tblUserAuth = apiResponse.UserAuth;
        //                TblUserRole tblUserRole = apiResponse.UserRole;



        //                if (tblUserRole.AccessRole.Equals("Admin") || tblUserRole.AccessRole.Equals("SuperAdmin"))
        //                {
        //                    apiResponse.RedirectUrl = "/Admin/";
        //                }
        //                else
        //                {
        //                    apiResponse.RedirectUrl = "/Dashboard/";
        //                }
        //                apiResponse.RedirectUrl = "Dashboard";
        //                return Ok(apiResponse);
        //            }
        //            else
        //            {
        //                apiResponse.RedirectUrl = "Login/Failed";
        //                return Ok(apiResponse);
        //            }
        //        }
        //        catch (System.Exception e)
        //        {
        //            return Redirect("Login/Failed");

        //        }

        //    }



        //    [Route("SignUp")]
        //    [HttpPost]
        //    public async Task<IActionResult> SignUp([FromBody] UserBO userBO)
        //    {
        //        try
        //        {
        //            ApiRequest apiRequest = new ApiRequest();
        //            ResponseBO _res = await apiRequest.PostAsync("User/Create", userBO);

        //            UserResponseBO apiResponse = JsonConvert.DeserializeObject<UserResponseBO>(_res.ResponseResult);

        //            if (apiResponse.HttpStatusCode == "200")
        //            {
        //                SessionsController sessionController = new SessionsController();
        //                sessionController.CreateSession(apiResponse, _res.ResponseCookies, HttpContext.Session);

        //                TblUserInfo tblUserInfo = apiResponse.UserInfo;
        //                TblUserAuth tblUserAuth = apiResponse.UserAuth;
        //                TblUserRole tblUserRole = apiResponse.UserRole;



        //                apiResponse.RedirectUrl = "SuccessfulRegistration/";



        //                return Ok(apiResponse);
        //            }
        //            else
        //            {
        //                apiResponse.RedirectUrl = "Login/Failed";
        //                return Unauthorized(apiResponse);
        //            }
        //        }
        //        catch (System.Exception e)
        //        {
        //            return Redirect("Login/Failed");

        //        }

        //    }


        //public byte[] ConvertToByte(HttpPostedFileBase file_)
        //{
        //    //byte[] fileByte = null;
        //    //BinaryReader rdr = new BinaryReader(file_.InputStream);
        //    //fileByte = rdr.ReadBytes((int)file_.ContentLength);
        //    //return fileByte;
        //}






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
