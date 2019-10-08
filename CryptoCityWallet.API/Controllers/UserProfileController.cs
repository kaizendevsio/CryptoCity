using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using CryptoCityWallet.DTO;
using CryptoCityWallet.BO;
using CryptoCityWallet.AppService;

namespace CryptoCityWallet.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserProfileController : ControllerBase
    {
        [HttpGet]
        public ActionResult Get()
        {   
            UserAuthResponse _apiResponse = new UserAuthResponse();

            try
            {
                // GET SESSIONS
                SessionController sessionController = new SessionController();
                TblUserAuth userAuth = sessionController.GetSession(HttpContext.Session);

                UserAppService userAppService = new UserAppService();
                TblUserInfo userInfo = userAppService.Get(userAuth);

                _apiResponse.UserInfo = userInfo;

                _apiResponse.HttpStatusCode = "200";
                _apiResponse.Message = "UserProfile GET";
                _apiResponse.Status = "Success";
            }
            catch (Exception ex)
            {
                _apiResponse.HttpStatusCode = "500";
                _apiResponse.Message = ex.Message;
                _apiResponse.Status = "Error";

            }

            return Ok(_apiResponse);
        }

        // POST api/values
        [HttpPost]
        public ActionResult<IEnumerable<string>> Post([FromBody] UserBO userBO)
        {
            return new string[] { "hehe" };

        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

    }
}
