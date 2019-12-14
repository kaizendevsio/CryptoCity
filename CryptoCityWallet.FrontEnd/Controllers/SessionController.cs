using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CryptoCityWallet.FrontEnd.Models;
using CryptoCityWallet.Entities.BO;
using System.Net;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using CryptoCityWallet.Wrapper.Models;
using CryptoCityWallet.Entities.DTO;

namespace CryptoCityWallet.FrontEnd.Controllers
{
    public class SessionController : ControllerBase
    {
        public string USER_SESSION { get; private set; } = "USER_SESSION";
        public string USER_SESSION_COOKIE { get; private set; } = "USER_SESSION_COOKIE";

        public bool CreateSession([FromBody] UserResponseBO UserResponseBO, CookieCollection ResponseCookies, ISession session)
        {
            session.SetString(USER_SESSION, JsonConvert.SerializeObject(UserResponseBO.UserInfo));
            session.SetString(USER_SESSION_COOKIE, JsonConvert.SerializeObject(ResponseCookies));
            return true;
        }

        public SessionBO GetSession(ISession session)
        {
            string _currentUserSession = session.GetString(USER_SESSION);
            string _currentUserSessionCookie = session.GetString(USER_SESSION_COOKIE);

            if (_currentUserSession != null)
            {
                SessionBO sessionBO = new SessionBO();
                sessionBO.SessionCookies = JsonConvert.DeserializeObject<CookieCollection>(_currentUserSessionCookie);
                sessionBO.UserInfo = JsonConvert.DeserializeObject<TblUserInfo>(_currentUserSession);

                return sessionBO;
            }
            else
            {
                throw new System.ArgumentException("User session invalid or expired.");
            }

        }

        public bool DestroySession(ISession session)
        {
            session.Clear();
            return true;
        }
    }
}
