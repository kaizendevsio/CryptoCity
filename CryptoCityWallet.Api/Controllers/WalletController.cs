using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CryptoCityWallet.API.Controllers;
using CryptoCityWallet.AppService;
using CryptoCityWallet.Entities.BO;
using CryptoCityWallet.Entities.DTO;
using CryptoCityWallet.ExternalUtilities;
using CryptoCityWallet.ExternalUtilities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CryptoCityWallet.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalletController : ControllerBase
    {
        [HttpGet("Address/Btc/New")]
        public async Task<ActionResult> NewBtcAddressAsync()
        {
            WalletAddressResponseBO _apiResponse = new WalletAddressResponseBO();

            try
            {
                // GET SESSIONS
                SessionController sessionController = new SessionController();
                Blockchain blockchain = new Blockchain();
                UserAppService userAppService = new UserAppService();

                TblUserAuth userAuth = sessionController.GetSession(HttpContext.Session);
                TblUserInfo userInfo = userAppService.Get(userAuth);

                string PaymentAddress = await blockchain.GenerateNewAddressAsync("").ConfigureAwait(true);

                _apiResponse.UserAuth = userAuth;
                _apiResponse.UserInfo = userInfo;
                _apiResponse.Address = PaymentAddress;
                _apiResponse.HttpStatusCode = "200";
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

        [HttpGet("Address/Eth/New")]
        public ActionResult NewEthAddress()
        {
            WalletAddressResponseBO _apiResponse = new WalletAddressResponseBO();

            try
            {
                // GET SESSIONS
                SessionController sessionController = new SessionController();
                Changelly changelly = new Changelly();
                UserAppService userAppService = new UserAppService();

                TblUserAuth userAuth = sessionController.GetSession(HttpContext.Session);
                TblUserInfo userInfo = userAppService.Get(userAuth);

                ChangellyResponse PaymentAddress = changelly.CreateTransaction("eth", "btc", 0.1m);

                _apiResponse.UserAuth = userAuth;
                _apiResponse.UserInfo = userInfo;
                _apiResponse.changellyResponse = PaymentAddress;
                _apiResponse.Address = PaymentAddress.result.payinAddress;
                _apiResponse.HttpStatusCode = "200";
                _apiResponse.Status = "Success";

                return Ok(_apiResponse);
            }
            catch (Exception ex)
            {
                _apiResponse.HttpStatusCode = "500";
                _apiResponse.Message = ex.Message;
                _apiResponse.Status = "Error";

            }

            return Ok(_apiResponse);
        }

        [HttpGet("Address/Usdt/New")]
        public ActionResult NewUsdtAddress()
        {
            WalletAddressResponseBO _apiResponse = new WalletAddressResponseBO();

            try
            {
                // GET SESSIONS
                SessionController sessionController = new SessionController();
                Changelly changelly = new Changelly();
                UserAppService userAppService = new UserAppService();

                TblUserAuth userAuth = sessionController.GetSession(HttpContext.Session);
                TblUserInfo userInfo = userAppService.Get(userAuth);

                ChangellyResponse PaymentAddress = changelly.CreateTransaction("usdt", "btc", 20m);

                _apiResponse.UserAuth = userAuth;
                _apiResponse.UserInfo = userInfo;
                _apiResponse.changellyResponse = PaymentAddress;
                _apiResponse.Address = PaymentAddress.result.payinAddress;
                _apiResponse.HttpStatusCode = "200";
                _apiResponse.Status = "Success";

                return Ok(_apiResponse);
            }
            catch (Exception ex)
            {
                _apiResponse.HttpStatusCode = "500";
                _apiResponse.Message = ex.Message;
                _apiResponse.Status = "Error";

            }

            return Ok(_apiResponse);
        }
    }
}