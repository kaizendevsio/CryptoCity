using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CryptoCityWallet.FrontEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseController
    {
       public readonly string Env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
    }
}