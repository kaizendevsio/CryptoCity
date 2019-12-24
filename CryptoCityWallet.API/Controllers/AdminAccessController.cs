using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CryptoCityWallet.AppService;
using CryptoCityWallet.Entities.BO;
using CryptoCityWallet.Entities.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CryptoCityWallet.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminAccessController : ControllerBase
    {
        [HttpGet("UserList")]
        public ActionResult UserList()
        {
            dynamic _apiResponse = new object();
            try
            {
                AdminAccessAppService adminAccessAppService = new AdminAccessAppService();
                _apiResponse.UserList = adminAccessAppService.GetAllUsers();

                _apiResponse.HttpStatusCode = "200";
                _apiResponse.Status = "Success";

                return Ok(_apiResponse);
            }
            catch (Exception ex)
            {
                _apiResponse.HttpStatusCode = "500";
                _apiResponse.Message = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                _apiResponse.Status = "Error";
                return Ok(_apiResponse);
            }

        }
    }
}