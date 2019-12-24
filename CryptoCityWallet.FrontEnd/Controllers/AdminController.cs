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


        //[HttpPost]
        //[Route("Admin/MemberRegistration")]
        //public IActionResult MemberRegistration(SignUpVM data)
        //{
            //List<byte[]> files = new List<byte[]>();
            //List<string> filenames = new List<string>();
            //if (file_.ContentType == "application/pdf" || file_.ContentType == "image/jpeg" || file_.ContentType == "application/msword" || file_.ContentType == "text/csv" || file_.ContentType == "application/vnd.ms-excel" || file_.ContentType == "image/png" || file_.ContentType == "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet" || file_.ContentType == "application/vnd.openxmlformats-officedocument.wordprocessingml.document")
            //{
            //    var b = file_.ContentType;

            //    files.Add(ConvertToByte(file_));
            //    filenames.Add(file_.FileName);
            //}
        //    return View();
        //}


        //[Route("Admin/Withdrawal")]
        //public IActionResult WithdrawalList()
        //{
        //    return View();
        //}
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

        //public byte[] ConvertToByte(HttpPostedFileBase file_)
        //{
        //    byte[] fileByte = null;
        //    BinaryReader rdr = new BinaryReader(file_.InputStream);
        //    fileByte = rdr.ReadBytes((int)file_.ContentLength);
        //    return fileByte;
        //}
    }
}
