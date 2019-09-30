using System.Collections.Generic;
using CryptoCityWallet.BO;
using CryptoCityWallet.AppService;
using Microsoft.AspNetCore.Mvc;
using CryptoCityWallet.DTO;
using System;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Text;

namespace CryptoCityWallet.API.Controllers
{
    public class SessionController : ControllerBase
    {
        public string USER_SESSION { get; private set; } = "USER_SESSION";
        public bool CreateSession([FromBody] UserAuthResponse userAuthResponse, ISession session)
        {
            session.SetString(USER_SESSION, JsonConvert.SerializeObject(userAuthResponse.UserAuth));
            return true;
        }

        public TblUserAuth GetSession(ISession session)
        {
            string _currentUserSession = session.GetString(USER_SESSION);
            TblUserAuth userAuth = JsonConvert.DeserializeObject<TblUserAuth>(_currentUserSession);

            return userAuth;
        }
    }
}
