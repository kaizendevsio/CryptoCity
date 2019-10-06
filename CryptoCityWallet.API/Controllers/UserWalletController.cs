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
    public class UserWalletController : ControllerBase
    {

        [HttpGet]
        public ActionResult Get()
        {
            UserWalletAppService userWalletAppService = new UserWalletAppService();
            UserAuthResponse _apiResponse = new UserAuthResponse();

            try
            {
                // GET SESSIONS
                SessionController sessionController = new SessionController();
                TblUserAuth userAuth = sessionController.GetSession(HttpContext.Session);

                _apiResponse.UserWallet = userWalletAppService.GetBO(userAuth);

                _apiResponse.HttpStatusCode = "200";
                _apiResponse.Message = "User successfully authenticated";
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
