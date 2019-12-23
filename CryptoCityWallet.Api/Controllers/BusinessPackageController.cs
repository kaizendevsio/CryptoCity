using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CryptoCityWallet.AppService;
using CryptoCityWallet.Entities.BO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CryptoCityWallet.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusinessPackageController : ControllerBase
    {
        [HttpPost("Buy")]
        public ActionResult Create([FromBody]  UserBusinessPackageBO userBusinessPackageBO)
        {
            UserBusinessPackageAppService userBusinessPackageAppService = new UserBusinessPackageAppService();
            ApiResponseBO _apiResponse = new ApiResponseBO();

            try
            {
                userBusinessPackageAppService.Create(userBusinessPackageBO);

                _apiResponse.HttpStatusCode = "200";
                _apiResponse.Message = "User successfully created";
                _apiResponse.Status = "Success";

                return Ok(_apiResponse);
            }
            catch (Exception ex)
            {
                _apiResponse.HttpStatusCode = "500";
                _apiResponse.Message = ex.InnerException.Message;
                _apiResponse.Status = "Error";
                return Ok(_apiResponse);
            }

        }
    }
}