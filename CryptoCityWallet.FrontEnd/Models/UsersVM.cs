using System;
using System.Collections.Generic;

namespace CryptoCityWallet.FrontEnd.Models
{
    public class UsersVM
    {

        public IEnumerable<UsersVM> UsersList { get; set; }


        public UsersVM() {
            UsersList = new List<UsersVM>();
        
        
        }
 
    }
}
