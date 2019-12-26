using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CryptoCityWallet.FrontEnd.Models;
using CryptoCityWallet.Entities.BO;
using CryptoCityWallet.Entities.Enums;

namespace CryptoCityWallet.FrontEnd.Controllers
{
    public class AdminController : Controller
    {
        public readonly string Env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
        public BaseController SessionHelper = new BaseController();

        public async Task<IActionResult> IndexAsync()
        {
            try
            {
                UserResponseBO userResponseBO = await SessionHelper.SessionStartAsync(HttpContext.Session,AccessRole.Admin);
                UserVM userVM = new UserVM { UserInfo = new UserBO { FirstName = userResponseBO.UserInfo.FirstName, LastName = userResponseBO.UserInfo.LastName, UserName = userResponseBO.UserAuth.UserName } };

                return View(userVM);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Login", "Home");

            }

        }
        public async Task<IActionResult> AccountAsync()
        {
            try
            {
                UserResponseBO userResponseBO = await SessionHelper.SessionStartAsync(HttpContext.Session,AccessRole.Admin);
                UserVM userVM = new UserVM { UserInfo = new UserBO { FirstName = userResponseBO.UserInfo.FirstName, LastName = userResponseBO.UserInfo.LastName, UserName = userResponseBO.UserAuth.UserName } };

                return View(userVM);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Login", "Home");

            }
        }


        [Route("Admin/TradeCurrency")]
        public async Task<IActionResult> TradeCurrencyAsync()
        {
            try
            {
                UserResponseBO userResponseBO = await SessionHelper.SessionStartAsync(HttpContext.Session,AccessRole.Admin);
                ConvertVM convertVM = new ConvertVM();
                convertVM.UserInfo = new UserBO { FirstName = userResponseBO.UserInfo.FirstName, LastName = userResponseBO.UserInfo.LastName, UserName = userResponseBO.UserAuth.UserName };

                return View(convertVM);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Login", "Home");

            }
        }

        //[Route("Admin/Deposit")]
        //public IActionResult Deposit()
        //{
        //    return View();
        //}

        [Route("Admin/Wallet")]
        public async Task<IActionResult> WalletAsync()
        {
            try
            {
                UserResponseBO userResponseBO = await SessionHelper.SessionStartAsync(HttpContext.Session,AccessRole.Admin);
                WalletMVMList userVM = new WalletMVMList { UserInfo = new UserBO { FirstName = userResponseBO.UserInfo.FirstName, LastName = userResponseBO.UserInfo.LastName, UserName = userResponseBO.UserAuth.UserName } };

                return View(userVM);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Login", "Home");

            }
        }


        [Route("Admin/Ledger")]
        public async Task<IActionResult> LedgerAsync()
        {
            try
            {
                UserResponseBO userResponseBO = await SessionHelper.SessionStartAsync(HttpContext.Session,AccessRole.Admin);
                UserVM userVM = new UserVM { UserInfo = new UserBO { FirstName = userResponseBO.UserInfo.FirstName, LastName = userResponseBO.UserInfo.LastName, UserName = userResponseBO.UserAuth.UserName } };

                return View(userVM);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Login", "Home");

            }
        }


        [Route("Admin/UniLevelMap")]
        public async Task<IActionResult> UniLevelMapAsync()
        {
            try
            {
                UserResponseBO userResponseBO = await SessionHelper.SessionStartAsync(HttpContext.Session,AccessRole.Admin);
                UserVM userVM = new UserVM { UserInfo = new UserBO { FirstName = userResponseBO.UserInfo.FirstName, LastName = userResponseBO.UserInfo.LastName, UserName = userResponseBO.UserAuth.UserName } };

                return View(userVM);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Login", "Home");

            }
        }


        [Route("Admin/Map")]
        public async Task<IActionResult> MapAsync()
        {
            try
            {
                UserResponseBO userResponseBO = await SessionHelper.SessionStartAsync(HttpContext.Session, AccessRole.Admin);
                UserVM userVM = new UserVM { UserInfo = new UserBO { FirstName = userResponseBO.UserInfo.FirstName, LastName = userResponseBO.UserInfo.LastName, UserName = userResponseBO.UserAuth.UserName } };

                return View(userVM);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Login", "Home");

            }
        }


        [Route("Admin/Members")]
        public async Task<IActionResult> MembersAsync()
        {
            try
            {
                UserResponseBO userResponseBO = await SessionHelper.SessionStartAsync(HttpContext.Session,AccessRole.Admin);
                MembersVM userVM = new MembersVM { UserInfo = new UserBO { FirstName = userResponseBO.UserInfo.FirstName, LastName = userResponseBO.UserInfo.LastName, UserName = userResponseBO.UserAuth.UserName } };

                return View(userVM);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Login", "Home");

            }
        }

        [Route("Admin/Convert")]
        public async Task<IActionResult> ConvertAsync()
        {
            try
            {
                UserResponseBO userResponseBO = await SessionHelper.SessionStartAsync(HttpContext.Session,AccessRole.Admin);
                UserVM userVM = new UserVM { UserInfo = new UserBO { FirstName = userResponseBO.UserInfo.FirstName, LastName = userResponseBO.UserInfo.LastName, UserName = userResponseBO.UserAuth.UserName } };

                ConvertVM convertVM = new ConvertVM();
                convertVM.UserInfo = new UserBO { FirstName = userResponseBO.UserInfo.FirstName, LastName = userResponseBO.UserInfo.LastName, UserName = userResponseBO.UserAuth.UserName };

                return View(convertVM);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Login", "Home");

            }
        }

        [Route("Admin/MemberRegistration")]
        public async Task<IActionResult> MemberRegistrationAsync()
        {
            try
            {
                UserResponseBO userResponseBO = await SessionHelper.SessionStartAsync(HttpContext.Session,AccessRole.Admin);
                UserVM userVM = new UserVM { UserInfo = new UserBO { FirstName = userResponseBO.UserInfo.FirstName, LastName = userResponseBO.UserInfo.LastName, UserName = userResponseBO.UserAuth.UserName } };

                return View(userVM);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Login", "Home");

            }
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
        public async Task<IActionResult> TradeAsync()
        {
            try
            {
                UserResponseBO userResponseBO = await SessionHelper.SessionStartAsync(HttpContext.Session,AccessRole.Admin);
                UserVM userVM = new UserVM { UserInfo = new UserBO { FirstName = userResponseBO.UserInfo.FirstName, LastName = userResponseBO.UserInfo.LastName, UserName = userResponseBO.UserAuth.UserName } };

                return View(userVM);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Login", "Home");

            }
        }
        [Route("Admin/Close")]
        public async Task<IActionResult> CloseAsync()
        {
            try
            {
                UserResponseBO userResponseBO = await SessionHelper.SessionStartAsync(HttpContext.Session,AccessRole.Admin);
                UserVM userVM = new UserVM { UserInfo = new UserBO { FirstName = userResponseBO.UserInfo.FirstName, LastName = userResponseBO.UserInfo.LastName, UserName = userResponseBO.UserAuth.UserName } };

                return View(userVM);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Login", "Home");

            }
        }

        [Route("Admin/Settings")]
        public async Task<IActionResult> SettingsAsync()
        {
            try
            {
                UserResponseBO userResponseBO = await SessionHelper.SessionStartAsync(HttpContext.Session,AccessRole.Admin);
                UserVM userVM = new UserVM { UserInfo = new UserBO { FirstName = userResponseBO.UserInfo.FirstName, LastName = userResponseBO.UserInfo.LastName, UserName = userResponseBO.UserAuth.UserName } };

                return View(userVM);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Login", "Home");

            }
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
