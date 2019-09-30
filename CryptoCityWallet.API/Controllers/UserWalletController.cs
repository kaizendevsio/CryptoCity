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
            UserWalletAppService userWalletAppService = new UserWalletAppService();
            UserAuthResponse _apiResponse = new UserAuthResponse();

            try
            {
                // GET SESSIONS
                SessionController sessionController = new SessionController();
                TblUserAuth userAuth = sessionController.GetSession(HttpContext.Session);

                UserAuthResponse userAuthResponse = new UserAuthResponse();


                userAuthResponse.UserWallet = userWalletAppService.Get(userAuth);

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
