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
    public class AffiliateController : ControllerBase
    {
        [HttpPost("InvitationLink")]
        public ActionResult InvitationLink([FromBody] AffiliateMapBO affiliateMapBO)
        {
            AffiliateAppService affiliateAppService = new AffiliateAppService();
            AffiliateLinkResponseBO _apiResponse = new AffiliateLinkResponseBO();

            try
            {
                _apiResponse.AffiliateMapBO = affiliateAppService.GetAffiliateLink(affiliateMapBO);

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