using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using CryptoCityWallet.Entities.DTO;

namespace CryptoCityWallet.Wrapper.Models
{
   public class SessionBO
    {
        public TblUserInfo UserInfo { get; set; }
        public CookieCollection SessionCookies { get; set; }
    }
}
