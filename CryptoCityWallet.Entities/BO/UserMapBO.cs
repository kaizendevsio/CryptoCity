using System;
using System.Collections.Generic;
using System.Text;
using CryptoCityWallet.Entities.DTO;

namespace CryptoCityWallet.Entities.BO
{
   public class UserMapBO
    {
        public TblUserAuth UserAuth { get; set; }
        public string name { get; set; }
        public string title { get; set; }
        public List<UserMapBO> children { get; set; }
        public string relationship { get; set; }

    }
}
