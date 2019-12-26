using System;
using System.Collections.Generic;
using System.Text;
using CryptoCityWallet.Entities.DTO;

namespace CryptoCityWallet.Entities.BO
{
   public class UserMapTblBO : TblUserMap
    {
        public TblUserAuth UserAuth { get; set; }
    }
}
