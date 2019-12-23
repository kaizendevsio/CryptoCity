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
    public class AdminController : Controller
    {
        public readonly string Env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");


        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Account()
        {
            return View();
        }

         
        [Route("Admin/TradeCurrency")] 
        public IActionResult TradeCurrency()
        {
            return View();
        }

        //[Route("Admin/Deposit")]
        //public IActionResult Deposit()
        //{
        //    return View();
        //}

        [Route("Admin/Wallet")]
        public IActionResult Wallet()
        {
            return View();
        }


        [Route("Admin/Ledger")]
        public IActionResult Ledger()
        {
            return View();
         }


        [Route("Admin/Map")]
        public IActionResult Map()
        {
            return View();
        }
         



        [Route("Admin/Members")]
        public IActionResult Members()
        {
            return View();
        }
        [Route("Admin/Convert")]
        public IActionResult Convert()
        {
            return View();
        }

        [Route("Admin/MemberRegistration")]
        public IActionResult MemberRegistration()
        {
            return View();
        }


        [Route("Admin/Withdrawal")]
        public IActionResult WithdrawalList()
        {
            return View();
        }
        [Route("Admin/Trade")]
        public IActionResult Trade()
        {
            return View();
        }
        [Route("Admin/Close")]
        public IActionResult Close()
        {
            return View();
        }
   
        [Route("Admin/Settings")]
        public IActionResult Settings()
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
