using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CryptoCityWallet.API.Controllers;
using CryptoCityWallet.AppService;
using CryptoCityWallet.Entities.BO;
using CryptoCityWallet.Entities.DTO;
using Newtonsoft.Json;

namespace CryptoCityWallet.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StructureMapInjectionController : ControllerBase
    {
        [HttpPost("Parse")]
        public ActionResult Create([FromBody] StructureMapInjection structureMap)
        {
            UserAppService userAppService = new UserAppService();
            ApiResponseBO _apiResponse = new ApiResponseBO();

            try
            {
                userAppService.StructureMapTesting(structureMap);

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