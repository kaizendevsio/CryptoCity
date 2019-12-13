using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CryptoCityWallet.FrontEnd.Models;

namespace CryptoCityWallet.FrontEnd.Controllers
{
    public class WalletController : Controller
    {
         

        public IActionResult Index()
        {
            return View();
        }
        [Route("/Wallet/MyBitcoin")]
        [HttpGet]
        public IActionResult MyBitcoin()
        {
            return View();
        }
        [Route("/Wallet/MyEthereum")]
        [HttpGet]
        public IActionResult MyEthereum()
        {
            return View();
        }
        [Route("/Wallet/MyTether")]
        [HttpGet]
        public IActionResult MyTether()
        {
            return View();
        }



        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
