using System.Text;
using System.Linq;
using System.Security.Cryptography;
using CryptoCityWallet.Entities.DTO;
using CryptoCityWallet.Entities.BO;
using CryptoCityWallet.Entities.Enums;
using AutoMapper;
using System;

namespace CryptoCityWallet.DataAccessLayer
{
   public class UserDepositRequestRepository
    {
        public TblUserDepositRequest Create(TblUserDepositRequest tblUserDepositRequest,dbWorldCCityContext db)
        {
            db.TblUserDepositRequest.Add(tblUserDepositRequest);
            db.SaveChanges();

            return tblUserDepositRequest;
        }
    }
}
