using System.Collections.Generic;
using CryptoCityWallet.BO;
using CryptoCityWallet.AppService;
using Microsoft.AspNetCore.Mvc;
using CryptoCityWallet.DTO;
using System;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace CryptoCityWallet.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAuthController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "hehe", "hehe" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public ActionResult Post([FromBody] UserBO userBO)
        {
            UserAppService userAppService = new UserAppService();
            UserAuthResponse _apiResponse = new UserAuthResponse();

            try
            {
                UserAuthResponse userAuthResponse = userAppService.Authenticate(userBO);

                _apiResponse.UserInfo = userAuthResponse.UserInfo;
                _apiResponse.UserWallet = userAuthResponse.UserWallet;
                
                // SET SESSIONS
                SessionController sessionController = new SessionController();
                sessionController.CreateSession(userAuthResponse, HttpContext.Session);
                
                _apiResponse.Status = "Success";
                _apiResponse.HttpStatusCode = "200";
                _apiResponse.Message = "User successfully authenticated";
                
            }
            catch (Exception ex)
            {
                _apiResponse.HttpStatusCode = "500";
                _apiResponse.Message = ex.Message;
                _apiResponse.Status = "Error";
            }

            return Ok(_apiResponse);

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
