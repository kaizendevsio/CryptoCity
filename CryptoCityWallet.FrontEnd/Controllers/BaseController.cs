using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CryptoCityWallet.Entities.BO;
using CryptoCityWallet.Entities.DTO;
using CryptoCityWallet.Entities.Enums;
using CryptoCityWallet.Wrapper;
using CryptoCityWallet.Wrapper.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CryptoCityWallet.FrontEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : Controller
    {
        public readonly string Env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

        public async Task<UserResponseBO> SessionStartAsync(ISession _isession, AccessRole accessRole)
        {
            // GET SESSIONS
            SessionController sessionController = new SessionController();
            SessionBO session = sessionController.GetSession(_isession);

            ApiRequest apiRequest = new ApiRequest();
            ResponseBO _res = await apiRequest.GetAsync(Env, "User/Profile", session.SessionCookies);
            UserResponseBO apiResponse = JsonConvert.DeserializeObject<UserResponseBO>(_res.ResponseResult);

            UserResponseBO userToken = new UserResponseBO();
            userToken.UserInfo =  apiResponse.UserInfo;
            userToken.UserAuth =  apiResponse.UserAuth;
            userToken.UserRole = apiResponse.UserRole;

            if (userToken.UserRole.AccessRole != accessRole.ToString())
            {
                throw new ArgumentException("Access Denied");
            }

            return userToken;

        }
    }
}