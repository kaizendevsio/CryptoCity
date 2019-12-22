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
     

        public IActionResult Index()
        {
            return View();
        }

        [Route("Admin/Trade")]
        public IActionResult Trade()
        {
            return View();
        }

        [Route("Admin/Members")]
        public IActionResult Members()
        {
            return View();
        }

        [Route("Admin/Ledger")]
        public IActionResult Ledger()
        {
            return View();
        }


        [Route("Admin/KYCList")]
        public IActionResult KYCList()
        {
            return View();
        }

        [Route("Admin/Users")]
        public IActionResult Users()
        {
            return View();
        }


        [Route("Admin/Transactions")]
        public IActionResult Transactions()
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
