using System.Collections.Generic;
using CryptoCityWallet.BO;
using CryptoCityWallet.AppService;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CryptoCityWallet.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserCreateController : ControllerBase
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
            ApiResponse _apiResponse = new ApiResponse();
                       
            try
            {
                userAppService.Create(userBO);

                _apiResponse.HttpStatusCode = "200";
                _apiResponse.Message = "User successfully created";
                _apiResponse.Status = "Success";
            }
            catch (Exception ex)
            {
                _apiResponse.HttpStatusCode = "500";
                _apiResponse.Message = ex.InnerException.Message;
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
